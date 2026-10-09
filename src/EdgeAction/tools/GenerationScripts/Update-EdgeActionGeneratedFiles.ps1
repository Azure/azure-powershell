# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
#Requires -Version 7.3
<#
.SYNOPSIS
Runs repository preparation, build, and platyPS help refresh for EdgeAction.
.DESCRIPTION
From src/EdgeAction/EdgeAction.Autorest:
  ../tools/GenerationScripts/Update-EdgeActionGeneratedFiles.ps1
Install the prerequisites from how-to.md first. Approved build feeds are set in the child only.
On Windows, checks the known Accounts output DLL for locks before preparation.
Close shells holding built assemblies; the script never terminates processes.
Generated outputs and parent cmdlet help are replaced, without backups or Git changes.
#>
[CmdletBinding()]
param([Parameter(DontShow)][switch]$NotIsolated)

$ErrorActionPreference = 'Stop'
if (-not $NotIsolated) {
    # Keep loaded build/help assemblies and upstream directory changes out of the caller.
    $PSNativeCommandUseErrorActionPreference = $false
    & (Join-Path $PSHOME $(if ($IsWindows) { 'pwsh.exe' } else { 'pwsh' })) -NoProfile -File $PSCommandPath -NotIsolated
    if ($LASTEXITCODE -ne 0) { throw "EdgeAction generation failed (exit $LASTEXITCODE). Output may be partial; no rollback was performed." }
    return
}
$PSNativeCommandUseErrorActionPreference = $true
$global:LASTEXITCODE = 0
$root = (Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..' '..')).Path
$source = Join-Path $root 'src' 'EdgeAction' 'EdgeAction.Autorest'
$parentHelp = Join-Path $root 'src' 'EdgeAction' 'EdgeAction' 'help'
$artifact = Join-Path $root 'artifacts' 'Debug' 'Az.EdgeAction'

function Assert-EdgeActionBuildOutputAvailable {
    param([string]$Path)
    $stream = $null
    try {
        # Opening an existing file for exclusive write access detects Windows image locks without writing bytes.
        $stream = [IO.File]::Open($Path, [IO.FileMode]::Open, [IO.FileAccess]::ReadWrite, [IO.FileShare]::None)
    } catch [IO.FileNotFoundException], [IO.DirectoryNotFoundException] {
        Write-Host 'Accounts output DLL is absent; no existing file to check.'
    } catch {
        $failure = $_.Exception.GetBaseException()
        throw "Build output preflight failed for '$Path' ($($failure.GetType().Name), HRESULT $($failure.HResult)). The file is locked or inaccessible; preparation has not started. Close the PowerShell process that imported this checkout's built Az.Accounts, including older terminal tabs. A new terminal or Remove-Module does not unload its DLLs. Use Process Explorer's Find Handle or DLL search to identify an owner; if none is found, check file permissions. No process was terminated."
    } finally {
        if ($null -ne $stream) { $stream.Dispose() }
    }
}

Push-Location $root
try {
    Write-Host 'Starting build output lock preflight.'
    if ($IsWindows) {
        Assert-EdgeActionBuildOutputAvailable (Join-Path $root 'artifacts' 'Debug' 'Az.Accounts' 'Microsoft.Azure.PowerShell.AssemblyLoading.dll')
    } else {
        Write-Host 'Windows Accounts DLL lock check is not applicable on this platform.'
    }
    Write-Host 'Completed build output lock preflight.'
    Write-Host 'Starting prerequisite version checks.'
    try {
        $node = Get-Command node -CommandType Application
        $nodeVersion = [version]((& $node.Source --version).Trim().TrimStart('v') -replace '-.*$', '')
        if ($nodeVersion -lt [version]'20.0') { throw "Node.js 20+ required; found $nodeVersion." }
        $dotnet = Get-Command dotnet -CommandType Application -All -ErrorAction SilentlyContinue |
            Where-Object { -not $IsWindows -or [IO.Path]::GetExtension($_.Source) -eq '.exe' } | Select-Object -First 1
        if (-not $dotnet -and $IsWindows) {
            $nativeDotnet = Join-Path $env:ProgramFiles 'dotnet' 'dotnet.exe'
            if (Test-Path $nativeDotnet) { $dotnet = Get-Command $nativeDotnet }
        }
        if (-not $dotnet -or $dotnet.Source -match 'node_modules') { throw 'Install the native .NET SDK 8+ and add its directory to PATH; npm dotnet shims are not supported.' }
        $env:PATH = (Split-Path $dotnet.Source) + [IO.Path]::PathSeparator + $env:PATH
        if ((Get-Command dotnet).Source -ne $dotnet.Source) { throw 'Remove the shadowing dotnet shim from the native SDK directory.' }
        $sdkVersion = [version]((& $dotnet.Source --version).Trim() -replace '-.*$', '')
        if ($sdkVersion -lt [version]'8.0') { throw ".NET SDK 8+ required; found $sdkVersion." }

        # Read installed CLI metadata without starting AutoRest or downloading its core.
        $autoRest = Get-Item (Get-Command autorest).Source
        if ($autoRest.LinkType) { $autoRest = $autoRest.ResolveLinkTarget($true) }
        $autoPackage = @(
            (Join-Path $autoRest.DirectoryName 'node_modules' 'autorest' 'package.json')
            (Join-Path $autoRest.DirectoryName '..' 'package.json')
        ) | Where-Object { Test-Path $_ } | Select-Object -First 1
        if (-not $autoPackage) { throw 'Cannot locate the active AutoRest npm package; install autorest@3.8.0 using the guide.' }
        $cli = Get-Content $autoPackage -Raw | ConvertFrom-Json
        if ($cli.name -ne 'autorest' -or $cli.version -ne '3.8.0') { throw "AutoRest CLI 3.8.0 required; found $($cli.name) $($cli.version)." }
        Import-Module platyPS -RequiredVersion 0.14.2
        Write-Host "Prerequisites: PowerShell $($PSVersionTable.PSVersion); Node $nodeVersion; .NET SDK $sdkVersion ($($dotnet.Source)); AutoRest CLI $($cli.version); platyPS 0.14.2."
        Write-Host 'Completed prerequisite version checks.'
    } catch {
        throw "Generation prerequisite check failed: $($_.Exception.Message) See '$(Join-Path $source 'how-to.md')' for installation instructions."
    }
    Write-Host 'Starting process-local build feed setup.'
    $env:autorest_registry = 'https://packagefeedproxy.microsoft.io/npm/'
    $env:RestoreSources = @(
        (Join-Path $root 'tools' 'LocalFeed')
        'https://pkgs.dev.azure.com/azclitools/public/_packaging/azure-powershell/nuget/v3/index.json'
        'https://packagefeedproxy.microsoft.io/nuget/v3/index.json'
    ) -join ';'
    Write-Host 'Completed process-local build feed setup.'

    $readmePath = Join-Path $source 'README.md'
    $sections = [regex]::Matches((Get-Content $readmePath -Raw), '(?ms)^### AutoRest Configuration\r?\n(.*)\z')
    $blocks = @(if ($sections.Count -eq 1) {
        [regex]::Matches($sections[0].Groups[1].Value, '(?ms)^```[ \t]*yaml[ \t]*\r?\n(.*?)^```[ \t]*\r?$')
    })
    if ($blocks.Count -ne 1) { throw "Expected one YAML block under AutoRest Configuration in '$readmePath'; cannot report configured input unambiguously." }
    $yaml = $blocks[0].Groups[1].Value
    $commit = [regex]::Matches($yaml, '(?m)^commit:[ \t]*[^#\s][^\r\n]*')
    $inputs = [regex]::Matches($yaml, '(?m)^input-file:[^\r\n]*(?:\r?\n(?:[ \t]+[^\r\n]*|#[^\r\n]*|[ \t]*))*')
    if ($commit.Count -ne 1 -or $inputs.Count -ne 1) { throw "Expected one commit and input-file setting in '$readmePath'; cannot report configured input unambiguously." }
    Write-Host "Configured AutoRest input from '$readmePath' (README excerpt; variables are not resolved):"
    Write-Host $commit[0].Value
    $inputs[0].Value -split '\r?\n' | Where-Object { $_.Trim() -and $_ -notmatch '^\s*#' } | ForEach-Object { Write-Host $_ }
    Write-Host 'Forced regeneration is enabled. generate-info IDs are bookkeeping, not the specification commit SHA.'

    Write-Host 'Starting AutoRest preparation.'
    # Prepare preserves generation metadata; AutoRest still overwrites the maintained guide.
    $guidePath = Join-Path $source 'how-to.md'
    $guide = [IO.File]::ReadAllBytes($guidePath)
    try {
        & (Join-Path $root 'tools' 'BuildScripts' 'PrepareAutorestModule.ps1') -RepoRoot $root -ModuleRootName EdgeAction -ForceRegenerate
        if ($LASTEXITCODE -ne 0) { throw "Preparation failed (exit $LASTEXITCODE)." }
    } finally {
        [IO.File]::WriteAllBytes($guidePath, $guide)
    }
    Write-Host 'Completed AutoRest preparation.'
    Write-Host 'Starting targeted EdgeAction build.'
    Set-Location $root
    & (Join-Path $root 'tools' 'BuildScripts' 'BuildModules.ps1') -RepoRoot $root -Configuration Debug -TargetModule EdgeAction
    if ($LASTEXITCODE -ne 0) { throw "Build failed (exit $LASTEXITCODE)." }
    Write-Host 'Completed targeted EdgeAction build.'

    Write-Host 'Starting parent Markdown help refresh.'
    # Use built Accounts globally so the nested EdgeAction module resolves the same copy.
    Import-Module (Join-Path $root 'artifacts' 'Debug' 'Az.Accounts' 'Az.Accounts.psd1') -Global
    Import-Module (Join-Path $artifact 'Az.EdgeAction.psd1') -Global
    Import-Module (Join-Path $root 'tools' 'BuildScripts' 'HelpMarkDown.psm1')
    Import-Module (Join-Path $root 'tools' 'HelpGeneration' 'HelpGeneration.psm1')

    $helpRun = Join-Path $root 'artifacts' ('edgeaction-help-' + [guid]::NewGuid())
    $help = Join-Path $helpRun 'help'
    $null = New-Item $help -ItemType Directory
    $pageName = 'Az.EdgeAction.md'
    $page = Get-Content (Join-Path $parentHelp $pageName) -Raw
    Copy-Item (Join-Path $parentHelp $pageName) $help
    Copy-Item (Join-Path $source 'docs' '*-*.md') $help
    Update-MarkdownHelpModule -Path $help -RefreshModulePage -AlphabeticParamsOrder -UseFullTypeName -ExcludeDontShow | Out-Null
    foreach ($file in Get-ChildItem $help -Filter '*-*.md') {
        Remove-CommonParameterFromMarkdown -Path $file.FullName -ParameterName ProgressAction
        $text = Get-Content $file.FullName -Raw
        $command = Get-Command $file.BaseName -Module Az.EdgeAction
        if ($command.ParameterSets.Count -gt 1) {
            # platyPS 0.14.2 drops default-only syntax unless parameter blocks name every set.
            $text = $text -replace '(?m)^Parameter Sets: \(All\)\r?$', ('Parameter Sets: ' + ($command.ParameterSets.Name -join ', '))
        }
        $text = $text -replace '(?m)(?<=\S)[ \t](?=\r?$)', ''
        Set-Content $file.FullName $text -NoNewline
    }
    # Refresh command summaries without replacing the parent module identity/description.
    $prefixPattern = '(?s)\A.*?(?=## Az\.EdgeAction Cmdlets)'
    $prefix = [regex]::Match($page, $prefixPattern).Value
    if (-not $prefix) { throw 'Parent module page is missing its cmdlet section.' }
    $pagePath = Join-Path $help $pageName
    $page = [regex]::Replace((Get-Content $pagePath -Raw), $prefixPattern, [Text.RegularExpressions.MatchEvaluator]{ param($match) $prefix })
    Set-Content $pagePath $page -NoNewline
    Write-Host 'Completed parent Markdown help refresh.'
    Write-Host 'Starting XML help generation and artifact publication.'
    New-AzMamlHelp -HelpFolderPath $help | Out-Null
    $commands = @(Get-Command -Module Az.EdgeAction)
    foreach ($destination in @($parentHelp, (Join-Path $artifact 'help'))) {
        $null = New-Item $destination -ItemType Directory -Force
        Get-ChildItem $destination -Filter '*-*.md' | Where-Object BaseName -NotIn $commands.Name | Remove-Item
        Copy-Item (Join-Path $help '*.md') $destination -Force
    }
    Copy-Item (Join-Path $helpRun 'Az.EdgeAction-help.xml') $artifact -Force
    Write-Host 'Completed XML help generation and artifact publication.'
    Write-Host "Generation, build and help refresh completed. Review the diff. Help output: $helpRun"
} finally {
    Pop-Location
}
