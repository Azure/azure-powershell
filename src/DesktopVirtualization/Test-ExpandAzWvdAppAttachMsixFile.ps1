<#
.SYNOPSIS
    P0 parameter-binding smoke test for the new cmdlet Expand-AzWvdAppAttachMsixFile.

.DESCRIPTION
    This script does NOT talk to Azure. It validates that the newly generated
    cmdlet exposes all 6 parameter sets and that each set binds successfully.
    Every invocation is run under -WhatIf so no HTTP request is ever dispatched.

    Parameter sets exercised:
        1. ExpandExpanded              (default, flat parameters)
        2. ExpandViaJsonString
        3. ExpandViaJsonFilePath
        4. Expand                      (-Body <IExpandMsixFileRequest>)
        5. ExpandViaIdentityExpanded   (pipe a synthetic identity + flat params)
        6. ExpandViaIdentity           (pipe a synthetic identity + -Body)

    Prerequisite: load the locally-built module first, e.g. by starting a shell
    via  DesktopVirtualization.Autorest\run-module.ps1  or by
        Import-Module <repo>\artifacts\Debug\Az.DesktopVirtualization\Az.DesktopVirtualization.psd1

.PARAMETER Live
    Remove the implicit -WhatIf and actually send requests. You are fully
    responsible for providing valid resource identifiers when using this.

.PARAMETER Cases
    Which parameter sets to exercise. Default = all 6.

.EXAMPLE
    .\Test-ExpandAzWvdAppAttachMsixFile.ps1
    # Runs all 6 cases in -WhatIf mode with placeholder values.

.EXAMPLE
    .\Test-ExpandAzWvdAppAttachMsixFile.ps1 -Cases ExpandExpanded,Expand
#>
[CmdletBinding()]
param(
    # Placeholder identifiers - no real Azure resources are required in WhatIf mode.
    [string]   $SubscriptionId       = '00000000-0000-0000-0000-000000000000',
    [string]   $ResourceGroupName    = 'fake-rg',
    [string]   $AppAttachPackageName = 'fake-package',

    [string]   $HostpoolArmPath      = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/fake-rg/providers/Microsoft.DesktopVirtualization/hostPools/fake-hp',
    [string]   $MsixFileShare        = '\\fake.file.core.windows.net\apps',
    [string[]] $MsixFileUri          = @('https://fake.file.core.windows.net/apps/fake.msix'),
    [string[]] $MsixUncPath          = @('\\fake.file.core.windows.net\apps\fake.msix'),
    [string[]] $OutputFileSharePath  = @('\\fake.file.core.windows.net\apps\expanded'),
    [string]   $MsixPackageSource    = 'FileShare',
    [string]   $OutputFileType       = 'VHDX',

    [ValidateSet(
        'ExpandExpanded',
        'ExpandViaJsonString',
        'ExpandViaJsonFilePath',
        'Expand',
        'ExpandViaIdentityExpanded',
        'ExpandViaIdentity'
    )]
    [string[]] $Cases = @(
        'ExpandExpanded',
        'ExpandViaJsonString',
        'ExpandViaJsonFilePath',
        'Expand',
        'ExpandViaIdentityExpanded',
        'ExpandViaIdentity'
    ),

    # Off by default -> every call gets -WhatIf so Azure is never contacted.
    [switch]   $Live
)

$ErrorActionPreference = 'Stop'

# -------------------------------------------------------------------
# 0. Sanity checks - module must be loaded
# -------------------------------------------------------------------
$cmd = Get-Command Expand-AzWvdAppAttachMsixFile -ErrorAction SilentlyContinue
if (-not $cmd) {
    throw "Expand-AzWvdAppAttachMsixFile not found in the current session. Load the locally-built module first (e.g. via run-module.ps1)."
}
$module = Get-Module Az.DesktopVirtualization
if ($module) {
    Write-Host ("[info] Using module {0} v{1} from {2}" -f $module.Name, $module.Version, $module.ModuleBase) -ForegroundColor Cyan
}
Write-Host ("[info] Mode         : {0}" -f $(if ($Live) { 'LIVE (requests will be sent!)' } else { 'WhatIf (no HTTP)' })) -ForegroundColor Cyan
Write-Host ("[info] Cases        : {0}" -f ($Cases -join ', ')) -ForegroundColor Cyan
Write-Host ''

Write-Host '[info] Syntax:' -ForegroundColor Cyan
Get-Command Expand-AzWvdAppAttachMsixFile -Syntax
Write-Host ''

# Verify all 6 parameter sets were generated
$expectedSets = @(
    'ExpandExpanded','ExpandViaJsonString','ExpandViaJsonFilePath',
    'Expand','ExpandViaIdentityExpanded','ExpandViaIdentity'
)
$actualSets = $cmd.ParameterSets.Name
$missing = $expectedSets | Where-Object { $_ -notin $actualSets }
if ($missing) {
    Write-Warning ("Missing parameter set(s) on the cmdlet: {0}" -f ($missing -join ', '))
} else {
    Write-Host "[info] All 6 expected parameter sets are present." -ForegroundColor Green
}
Write-Host ''

# -------------------------------------------------------------------
# Helpers
# -------------------------------------------------------------------
$results = [System.Collections.Generic.List[object]]::new()

function Invoke-Case {
    param(
        [string]      $Name,
        [scriptblock] $Action
    )
    Write-Host "================================================================" -ForegroundColor Yellow
    Write-Host "[case] $Name" -ForegroundColor Yellow
    Write-Host "================================================================" -ForegroundColor Yellow
    $sw = [System.Diagnostics.Stopwatch]::StartNew()
    try {
        $out = & $Action
        $sw.Stop()
        $results.Add([pscustomobject]@{
            Case = $Name; Status = 'OK'; Duration = $sw.Elapsed; Error = $null
        })
        if ($null -ne $out) {
            $out | Format-List | Out-String | Write-Host
        }
        Write-Host "[ok] $Name" -ForegroundColor Green
    } catch {
        $sw.Stop()
        $results.Add([pscustomobject]@{
            Case = $Name; Status = 'FAIL'; Duration = $sw.Elapsed; Error = $_.Exception.Message
        })
        Write-Host "[error] $($_.Exception.Message)" -ForegroundColor Red
    }
    Write-Host ''
}

# Build a synthetic identity object (no ARM call needed).
function New-SyntheticIdentity {
    $id = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.DesktopVirtualization/appAttachPackages/$AppAttachPackageName"
    try {
        $t = [type]'Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.DesktopVirtualizationIdentity'
        $o = [Activator]::CreateInstance($t)
        foreach ($pair in @(
            @{ n='SubscriptionId';       v=$SubscriptionId       },
            @{ n='ResourceGroupName';    v=$ResourceGroupName    },
            @{ n='AppAttachPackageName'; v=$AppAttachPackageName },
            @{ n='Id';                   v=$id                   }
        )) {
            $p = $t.GetProperty($pair.n, [System.Reflection.BindingFlags]'Public,Instance,IgnoreCase')
            if ($p -and $p.CanWrite) { $p.SetValue($o, $pair.v) }
        }
        return $o
    } catch {
        return [pscustomobject]@{
            Id                   = $id
            SubscriptionId       = $SubscriptionId
            ResourceGroupName    = $ResourceGroupName
            AppAttachPackageName = $AppAttachPackageName
        }
    }
}

# Request body (for -Body and JSON variants)
$bodyHash = [ordered]@{
    hostpoolArmPath     = $HostpoolArmPath
    msixPackageSource   = $MsixPackageSource
    msixFileShare       = $MsixFileShare
    msixFileUri         = $MsixFileUri
    msixUncPath         = $MsixUncPath
    outputFileSharePath = $OutputFileSharePath
    outputFileType      = $OutputFileType
}
$bodyJson = $bodyHash | ConvertTo-Json -Depth 6

# WhatIf splat (default)
$whatIf = @{}
if (-not $Live) { $whatIf['WhatIf'] = $true }

# -------------------------------------------------------------------
# 1. ExpandExpanded
# -------------------------------------------------------------------
if ($Cases -contains 'ExpandExpanded') {
    Invoke-Case 'ExpandExpanded' {
        Expand-AzWvdAppAttachMsixFile `
            -SubscriptionId       $SubscriptionId `
            -ResourceGroupName    $ResourceGroupName `
            -AppAttachPackageName $AppAttachPackageName `
            -HostpoolArmPath      $HostpoolArmPath `
            -MsixFileShare        $MsixFileShare `
            -MsixFileUri          $MsixFileUri `
            -MsixPackageSource    $MsixPackageSource `
            -MsixUncPath          $MsixUncPath `
            -OutputFileSharePath  $OutputFileSharePath `
            -OutputFileType       $OutputFileType `
            @whatIf
    }
}

# -------------------------------------------------------------------
# 2. ExpandViaJsonString
# -------------------------------------------------------------------
if ($Cases -contains 'ExpandViaJsonString') {
    Invoke-Case 'ExpandViaJsonString' {
        Expand-AzWvdAppAttachMsixFile `
            -SubscriptionId       $SubscriptionId `
            -ResourceGroupName    $ResourceGroupName `
            -AppAttachPackageName $AppAttachPackageName `
            -JsonString           $bodyJson `
            @whatIf
    }
}

# -------------------------------------------------------------------
# 3. ExpandViaJsonFilePath
# -------------------------------------------------------------------
if ($Cases -contains 'ExpandViaJsonFilePath') {
    $tmp = Join-Path ([IO.Path]::GetTempPath()) ("expand-msix-{0}.json" -f ([guid]::NewGuid()))
    Set-Content -Path $tmp -Value $bodyJson -Encoding utf8
    Invoke-Case 'ExpandViaJsonFilePath' {
        try {
            Expand-AzWvdAppAttachMsixFile `
                -SubscriptionId       $SubscriptionId `
                -ResourceGroupName    $ResourceGroupName `
                -AppAttachPackageName $AppAttachPackageName `
                -JsonFilePath         $tmp `
                @whatIf
        } finally {
            Remove-Item -Path $tmp -ErrorAction SilentlyContinue
        }
    }
}

# -------------------------------------------------------------------
# Builder for the strongly-typed -Body object.
# The generated concrete class lives at
#   Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.ExpandMsixFileRequest
# and exposes these PascalCase flattened properties (which forward onto the
# internal 'Property' bag that's auto-initialized on first access):
#   HostpoolArmPath, MsixFileShare, MsixFileUri (string[]), MsixPackageSource,
#   MsixUncPath (string[]), OutputFileSharePath (string[]), OutputFileType
# -------------------------------------------------------------------
function New-ExpandBody {
    $modelCmd = Get-Command -Name 'New-AzWvdExpandMsixFileRequestObject' -ErrorAction SilentlyContinue
    if ($modelCmd) {
        return New-AzWvdExpandMsixFileRequestObject `
                    -HostpoolArmPath     $HostpoolArmPath `
                    -MsixPackageSource   $MsixPackageSource `
                    -MsixFileShare       $MsixFileShare `
                    -MsixFileUri         $MsixFileUri `
                    -MsixUncPath         $MsixUncPath `
                    -OutputFileSharePath $OutputFileSharePath `
                    -OutputFileType      $OutputFileType
    }

    # No helper cmdlet generated -> instantiate the concrete model directly.
    $typeName = 'Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.ExpandMsixFileRequest'
    $body = New-Object -TypeName $typeName
    $body.HostpoolArmPath     = $HostpoolArmPath
    $body.MsixPackageSource   = $MsixPackageSource
    $body.MsixFileShare       = $MsixFileShare
    $body.MsixFileUri         = [string[]]$MsixFileUri
    $body.MsixUncPath         = [string[]]$MsixUncPath
    $body.OutputFileSharePath = [string[]]$OutputFileSharePath
    $body.OutputFileType      = $OutputFileType
    return $body
}

# -------------------------------------------------------------------
# 4. Expand  (strongly-typed -Body)
# -------------------------------------------------------------------
if ($Cases -contains 'Expand') {
    Invoke-Case 'Expand' {
        $body = New-ExpandBody
        Expand-AzWvdAppAttachMsixFile `
            -SubscriptionId       $SubscriptionId `
            -ResourceGroupName    $ResourceGroupName `
            -AppAttachPackageName $AppAttachPackageName `
            -Body                 $body `
            @whatIf
    }
}

# -------------------------------------------------------------------
# 5. ExpandViaIdentityExpanded
# -------------------------------------------------------------------
if ($Cases -contains 'ExpandViaIdentityExpanded') {
    Invoke-Case 'ExpandViaIdentityExpanded' {
        $identity = New-SyntheticIdentity
        $identity | Expand-AzWvdAppAttachMsixFile `
            -HostpoolArmPath     $HostpoolArmPath `
            -MsixFileShare       $MsixFileShare `
            -MsixFileUri         $MsixFileUri `
            -MsixPackageSource   $MsixPackageSource `
            -MsixUncPath         $MsixUncPath `
            -OutputFileSharePath $OutputFileSharePath `
            -OutputFileType      $OutputFileType `
            @whatIf
    }
}

# -------------------------------------------------------------------
# 6. ExpandViaIdentity
# -------------------------------------------------------------------
if ($Cases -contains 'ExpandViaIdentity') {
    Invoke-Case 'ExpandViaIdentity' {
        $identity = New-SyntheticIdentity
        $body = New-ExpandBody
        $identity | Expand-AzWvdAppAttachMsixFile -Body $body @whatIf
    }
}

# -------------------------------------------------------------------
# Summary
# -------------------------------------------------------------------
Write-Host ''
Write-Host '================================ SUMMARY ================================' -ForegroundColor Cyan
$results | Format-Table Case, Status, Duration, Error -AutoSize | Out-String | Write-Host

$failed = @($results | Where-Object Status -eq 'FAIL')
if ($failed.Count -gt 0) {
    Write-Host ("[done] {0} case(s) failed." -f $failed.Count) -ForegroundColor Red
    exit 1
} else {
    Write-Host "[done] All cases passed." -ForegroundColor Green
    exit 0
}



