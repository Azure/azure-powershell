#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Validates the migration to Microsoft.PowerShell.PlatyPS (v1.x) for a single Az module by
    (1) confirming the new help output is a superset of the legacy platyPS (v0.x) output and
    (2) confirming the module honors [Parameter(DontShow)] via the -ExcludeDontShow switch.

.DESCRIPTION
    Repository tooling script (PowerShell 7+). Framework-free so it runs anywhere and in CI.

    Legacy platyPS and Microsoft.PowerShell.PlatyPS depend on different, conflicting versions of
    YamlDotNet and therefore cannot be loaded in the same process. To work around that, each
    help generation runs in its own child PowerShell process (the script re-invokes itself in
    -GenerateMode), and the parent process only compares the generated markdown files.

    Checks performed:
        * SUPERSET     - every cmdlet/parameter documented by legacy platyPS is still documented
                         by the new module (no regression).
        * DONTSHOW     - generating with -ExcludeDontShow removes exactly the parameters marked
                         [Parameter(DontShow)] (cross-checked against the live cmdlet metadata).
                         -ExcludeDontShow was added in 1.0.2 (PowerShell/platyPS#845); note the
                         switch is opt-in, so generating without it still emits those parameters.

    Exit codes:
        0  all checks passed
        1  a check failed (regression, or DontShow not honored)
        2  prerequisite missing (target module not importable, or a platyPS module unavailable)

.PARAMETER TargetModule
    The Az module to validate. Default: Az.Accounts (env PLATYPS_TEST_MODULE). Must be importable
    (built under artifacts/Debug/<Module> or installed).

.PARAMETER NewModulePath
    Folder or .dll/.psd1 for Microsoft.PowerShell.PlatyPS 1.0.2 or later. If omitted, the
    installed module is used (env PLATYPS_NEW_MODULE_PATH).

.PARAMETER OldModuleName
    Name or path for the legacy platyPS module. Default: platyPS (env PLATYPS_OLD_MODULE_NAME).

.EXAMPLE
    $env:PLATYPS_NEW_MODULE_PATH = 'C:\path\to\Microsoft.PowerShell.PlatyPS'
    pwsh tools/HelpGeneration/Compare-PlatyPSHelpOutput.ps1 -TargetModule Az.Accounts
#>

[CmdletBinding()]
param(
    [string] $TargetModule = $(if ($env:PLATYPS_TEST_MODULE) { $env:PLATYPS_TEST_MODULE } else { 'Az.Accounts' }),
    [string] $NewModulePath = $env:PLATYPS_NEW_MODULE_PATH,
    [string] $OldModuleName = $(if ($env:PLATYPS_OLD_MODULE_NAME) { $env:PLATYPS_OLD_MODULE_NAME } else { 'platyPS' }),

    # Internal: when set, the script runs as a single-purpose generator in a child process.
    [ValidateSet('old', 'new')]
    [string] $GenerateMode,
    [string] $OutputFolder,
    [switch] $ExcludeDontShow
)

$ErrorActionPreference = 'Stop'

# PowerShell common parameters are excluded from comparisons. Legacy platyPS listed some of
# these (notably ProgressAction, a DontShow common parameter added in PS 7.4) as regular
# parameters, while the new module correctly omits them; they are noise for this comparison.
$script:CommonParameters = @(
    'Debug', 'ErrorAction', 'ErrorVariable', 'InformationAction', 'InformationVariable',
    'OutBuffer', 'OutVariable', 'PipelineVariable', 'Verbose', 'WarningAction',
    'WarningVariable', 'WhatIf', 'Confirm', 'ProgressAction'
)

# ---------------------------------------------------------------------------------------
# Shared helpers
# ---------------------------------------------------------------------------------------

function Get-RepoRoot {
    return (Resolve-Path ([System.IO.Path]::Combine($PSScriptRoot, '..', '..'))).Path
}

function Resolve-TargetModuleManifest {
    param([Parameter(Mandatory)] [string] $ModuleName)

    $artifactsManifest = [System.IO.Path]::Combine(
        (Get-RepoRoot), 'artifacts', 'Debug', $ModuleName, "$ModuleName.psd1")
    if (Test-Path -Path $artifactsManifest) {
        return $artifactsManifest
    }

    $available = Get-Module -Name $ModuleName -ListAvailable | Select-Object -First 1
    if ($available) {
        return $available.Path
    }

    return $null
}

function Import-NewPlatyPS {
    param([string] $Source)

    if (-not $Source) {
        Import-Module -Name 'Microsoft.PowerShell.PlatyPS' -MinimumVersion 1.0.2 -Force -ErrorAction Stop
        return
    }

    if (-not (Test-Path -Path $Source)) {
        throw "Microsoft.PowerShell.PlatyPS source '$Source' was not found."
    }

    $item = Get-Item -Path $Source
    if (-not $item.PSIsContainer) {
        Import-Module -Name $item.FullName -Force -ErrorAction Stop
        return
    }

    $moduleDir = $item.FullName
    $manifest = Join-Path -Path $moduleDir -ChildPath 'Microsoft.PowerShell.PlatyPS.psd1'
    if (-not (Test-Path -Path $manifest)) {
        throw "No Microsoft.PowerShell.PlatyPS.psd1 found under '$moduleDir'."
    }

    # Remove mark-of-the-web so the (unsigned) format file and assemblies load under RemoteSigned.
    # Unblock-File is Windows-only; it throws PlatformNotSupportedException elsewhere.
    if ($IsWindows) {
        Get-ChildItem -Path $moduleDir -Recurse -File | Unblock-File -ErrorAction SilentlyContinue
    }

    # The manifest's NestedModules expect the dependency assemblies under a 'Dependencies'
    # subfolder. Some distributions extract them flat in the module root; stage them so the
    # manifest import resolves NestedModules (matching the normal installed layout).
    $dependenciesDir = Join-Path -Path $moduleDir -ChildPath 'Dependencies'
    if (-not (Test-Path -Path $dependenciesDir)) {
        New-Item -Path $dependenciesDir -ItemType Directory -Force | Out-Null
    }
    foreach ($dependency in @('YamlDotNet.dll', 'Markdig.Signed.dll')) {
        $flat = Join-Path -Path $moduleDir -ChildPath $dependency
        $nested = Join-Path -Path $dependenciesDir -ChildPath $dependency
        if ((Test-Path -Path $flat) -and -not (Test-Path -Path $nested)) {
            Copy-Item -Path $flat -Destination $nested -Force
        }
    }

    Import-Module -Name $manifest -Force -ErrorAction Stop
}

function Get-ParameterMap {
    <#
        Maps cmdlet name -> sorted unique parameter names by parsing the per-cmdlet markdown
        files in a help folder. Parameter section headers are dash-prefixed ("### -Name") in
        both the legacy and new schemas, while example headers are not, so this works regardless
        of which module generated the files.
    #>
    param([Parameter(Mandatory)] [string] $HelpFolder)

    $map = [ordered]@{}
    $cmdletFiles = Get-ChildItem -Path $HelpFolder -Recurse -File -Filter '*-*.md' -ErrorAction SilentlyContinue
    foreach ($file in $cmdletFiles) {
        $params = Select-String -Path $file.FullName -Pattern '^###\s+-(?<name>\S+)' |
            ForEach-Object { $_.Matches[0].Groups['name'].Value } |
            Where-Object { $script:CommonParameters -notcontains $_ } |
            Sort-Object -Unique
        $map[$file.BaseName] = @($params)
    }
    return $map
}

# ---------------------------------------------------------------------------------------
# Generator mode (runs in an isolated child process)
# ---------------------------------------------------------------------------------------

if ($GenerateMode) {
    $manifest = Resolve-TargetModuleManifest -ModuleName $TargetModule
    if (-not $manifest) { throw "Target module '$TargetModule' is not importable." }
    Import-Module -Name $manifest -Force -ErrorAction Stop

    if ($GenerateMode -eq 'old') {
        Import-Module -Name $OldModuleName -Force -ErrorAction Stop
        New-MarkdownHelp -Module $TargetModule -OutputFolder $OutputFolder -Force | Out-Null
    }
    else {
        Import-NewPlatyPS -Source $NewModulePath
        if ($ExcludeDontShow) {
            New-MarkdownCommandHelp -ModuleInfo (Get-Module -Name $TargetModule) -OutputFolder $OutputFolder -Force -ExcludeDontShow | Out-Null
        }
        else {
            New-MarkdownCommandHelp -ModuleInfo (Get-Module -Name $TargetModule) -OutputFolder $OutputFolder -Force | Out-Null
        }
    }
    exit 0
}

# ---------------------------------------------------------------------------------------
# Parent orchestration
# ---------------------------------------------------------------------------------------

function Write-Result {
    param([string] $Status, [string] $Message)

    $color = switch ($Status) {
        'PASS' { 'Green' }
        'FAIL' { 'Red' }
        'SKIP' { 'Yellow' }
        default { 'Gray' }
    }
    Write-Host ("[{0}] {1}" -f $Status, $Message) -ForegroundColor $color
}

function Invoke-Generation {
    param(
        [Parameter(Mandatory)] [ValidateSet('old', 'new')] [string] $Mode,
        [Parameter(Mandatory)] [string] $OutputFolder,
        [switch] $ExcludeDontShow
    )

    New-Item -Path $OutputFolder -ItemType Directory -Force | Out-Null
    $arguments = @(
        '-NoProfile', '-File', $PSCommandPath,
        '-GenerateMode', $Mode,
        '-TargetModule', $TargetModule,
        '-OutputFolder', $OutputFolder,
        '-OldModuleName', $OldModuleName
    )
    if ($NewModulePath) { $arguments += @('-NewModulePath', $NewModulePath) }
    if ($ExcludeDontShow) { $arguments += '-ExcludeDontShow' }

    & pwsh @arguments 2>&1 | ForEach-Object { Write-Verbose $_ }
    return ($LASTEXITCODE -eq 0)
}

function Get-DontShowParameter {
    <#
        Maps cmdlet name -> parameter names marked [Parameter(DontShow)] for the live module.
        Run in the parent (no platyPS loaded) so there is no assembly conflict.
    #>
    param([Parameter(Mandatory)] [string] $ModuleName)

    $map = @{}
    foreach ($command in Get-Command -Module $ModuleName -CommandType Cmdlet, Function) {
        $dontShow = foreach ($parameter in $command.Parameters.Values) {
            if ($script:CommonParameters -contains $parameter.Name) { continue }
            $isDontShow = $parameter.Attributes | Where-Object {
                $_ -is [System.Management.Automation.ParameterAttribute] -and $_.DontShow
            }
            if ($isDontShow) { $parameter.Name }
        }
        if ($dontShow) { $map[$command.Name] = @($dontShow | Sort-Object -Unique) }
    }
    return $map
}

Write-Host "Validating Microsoft.PowerShell.PlatyPS migration for module '$TargetModule'..." -ForegroundColor Cyan

# --- Prerequisites ---------------------------------------------------------------------

$targetManifest = Resolve-TargetModuleManifest -ModuleName $TargetModule
if (-not $targetManifest) {
    Write-Result -Status 'SKIP' -Message "Target module '$TargetModule' is not importable (not built under artifacts/Debug and not installed)."
    exit 2
}

$newAvailable = if ($NewModulePath) { Test-Path -Path $NewModulePath } else { [bool](Get-Module -Name 'Microsoft.PowerShell.PlatyPS' -ListAvailable) }
if (-not $newAvailable) {
    Write-Result -Status 'SKIP' -Message "Microsoft.PowerShell.PlatyPS is not available (set PLATYPS_NEW_MODULE_PATH or install it)."
    exit 2
}

$oldAvailable = [bool](Get-Module -Name $OldModuleName -ListAvailable)

$tempRoot = Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath ("platyps-compare-" + [guid]::NewGuid())
$oldDir = Join-Path -Path $tempRoot -ChildPath 'old'
$newAllDir = Join-Path -Path $tempRoot -ChildPath 'new-all'
$newExclDir = Join-Path -Path $tempRoot -ChildPath 'new-excludedontshow'

$exitCode = 0
try {
    # --- Generate (each in an isolated process to avoid YamlDotNet conflicts) -----------

    if (-not (Invoke-Generation -Mode 'new' -OutputFolder $newAllDir)) {
        Write-Result -Status 'FAIL' -Message "New module help generation (all parameters) failed."
        exit 1
    }
    if (-not (Invoke-Generation -Mode 'new' -OutputFolder $newExclDir -ExcludeDontShow)) {
        Write-Result -Status 'FAIL' -Message "New module help generation (-ExcludeDontShow) failed."
        exit 1
    }

    $newAllMap = Get-ParameterMap -HelpFolder $newAllDir
    $newExclMap = Get-ParameterMap -HelpFolder $newExclDir

    if ($newAllMap.Keys.Count -eq 0) {
        Write-Result -Status 'SKIP' -Message "The new module generated no cmdlet markdown."
        exit 2
    }

    # --- Check 1: superset vs legacy platyPS --------------------------------------------

    if ($oldAvailable) {
        if (Invoke-Generation -Mode 'old' -OutputFolder $oldDir) {
            $oldMap = Get-ParameterMap -HelpFolder $oldDir
            $missingCmdlets = @($oldMap.Keys | Where-Object { -not $newAllMap.Contains($_) })
            $missingParams = [System.Collections.Generic.List[string]]::new()
            foreach ($cmdlet in $oldMap.Keys) {
                if (-not $newAllMap.Contains($cmdlet)) { continue }
                foreach ($param in $oldMap[$cmdlet]) {
                    if ($newAllMap[$cmdlet] -notcontains $param) { $missingParams.Add("$cmdlet/-$param") }
                }
            }

            if ($missingCmdlets.Count -eq 0 -and $missingParams.Count -eq 0) {
                Write-Result -Status 'PASS' -Message "Superset: new output documents every legacy cmdlet ($($oldMap.Keys.Count)) and parameter."
            }
            else {
                if ($missingCmdlets.Count -gt 0) { Write-Result -Status 'FAIL' -Message "New output dropped cmdlet(s): $($missingCmdlets -join ', ')" }
                if ($missingParams.Count -gt 0) { Write-Result -Status 'FAIL' -Message "New output dropped parameter(s): $($missingParams -join ', ')" }
                $exitCode = 1
            }
        }
        else {
            Write-Result -Status 'SKIP' -Message "Legacy platyPS generation failed; skipping the superset check."
        }
    }
    else {
        Write-Result -Status 'SKIP' -Message "Legacy module '$OldModuleName' is not installed; skipping the superset check."
    }

    # --- Check 2: DontShow honoring -----------------------------------------------------

    Import-Module -Name $targetManifest -Force -ErrorAction Stop
    $dontShowMap = Get-DontShowParameter -ModuleName $TargetModule

    # Parameters that -ExcludeDontShow actually removed (present in 'all' but not in 'excluded').
    $removedBySwitch = [System.Collections.Generic.List[string]]::new()
    foreach ($cmdlet in $newAllMap.Keys) {
        $exclParams = if ($newExclMap.Contains($cmdlet)) { $newExclMap[$cmdlet] } else { @() }
        foreach ($param in $newAllMap[$cmdlet]) {
            if ($exclParams -notcontains $param) { $removedBySwitch.Add("$cmdlet/-$param") }
        }
    }

    # DontShow parameters that are actually present in the full ('all') output.
    $expectedDontShow = [System.Collections.Generic.List[string]]::new()
    foreach ($cmdlet in $dontShowMap.Keys) {
        if (-not $newAllMap.Contains($cmdlet)) { continue }
        foreach ($param in $dontShowMap[$cmdlet]) {
            if ($newAllMap[$cmdlet] -contains $param) { $expectedDontShow.Add("$cmdlet/-$param") }
        }
    }

    Write-Host ""
    Write-Host "DontShow parameters present in full output : $($expectedDontShow.Count)"
    Write-Host "Parameters removed by -ExcludeDontShow      : $($removedBySwitch.Count)"
    if ($removedBySwitch.Count -gt 0) { Write-Host "  Removed: $($removedBySwitch -join ', ')" }
    Write-Host ""

    if ($expectedDontShow.Count -eq 0) {
        Write-Result -Status 'SKIP' -Message "Module '$TargetModule' exposes no DontShow parameters in its help; cannot validate DontShow honoring (try a module that has them)."
    }
    else {
        # Honored when the switch removed at least the expected DontShow params and removed nothing else.
        $notRemoved = @($expectedDontShow | Where-Object { $removedBySwitch -notcontains $_ })
        $removedButNotDontShow = @($removedBySwitch | Where-Object { $expectedDontShow -notcontains $_ })

        if ($notRemoved.Count -eq 0 -and $removedButNotDontShow.Count -eq 0) {
            Write-Result -Status 'PASS' -Message "DontShow honored: -ExcludeDontShow removed exactly the $($expectedDontShow.Count) DontShow parameter(s)."
        }
        else {
            if ($notRemoved.Count -gt 0) { Write-Result -Status 'FAIL' -Message "DontShow NOT honored: still present with -ExcludeDontShow: $($notRemoved -join ', ')" }
            if ($removedButNotDontShow.Count -gt 0) { Write-Result -Status 'FAIL' -Message "-ExcludeDontShow removed non-DontShow parameter(s): $($removedButNotDontShow -join ', ')" }
            $exitCode = 1
        }
    }

    if ($exitCode -eq 0) {
        Write-Result -Status 'PASS' -Message "All checks passed."
    }
    exit $exitCode
}
finally {
    Remove-Item -Path $tempRoot -Recurse -Force -ErrorAction SilentlyContinue
}
