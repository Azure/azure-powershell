#Requires -Modules Pester

<#
    .SYNOPSIS Execute pester tests

    .PARAMETER BuildConfig
        Build configuration, either Debug or Release

#>
param(
    [CmdletBinding()]

    [Parameter(Mandatory = $true)]
    [ValidateSet('Debug', 'Release')]
    [System.String]$BuildConfig,

    [Parameter(Mandatory = $true)]
    [ValidateSet('All', 'Latest', 'Stack', 'ServiceManagement', 'AzureStorage')]
    [System.String]$Scope
)

<#
    .SYNOPSIS Execute pester tests for Azure modules

    .PARAMETER BuildConfig
        Build configuration, either Debug or Release

#>
function Test-Azure {
    param(
        [CmdletBinding()]
        [Parameter(Mandatory = $true)]
        [System.String]$BuildConfig
    )
    $defaults = [System.IO.Path]::GetDirectoryName($PSScriptRoot)
    Start-Job -ScriptBlock {
        $ARMRoot = "$($using:PSScriptRoot)\..\..\src\Package\$BuildConfig\ResourceManager\AzureResourceManager"
        Import-Module "$ARMRoot\AzureRM.Profile\AzureRM.Profile.psd1;"
        Import-Module "$ARMRoot\AzureRM.Resources\AzureRM.Resources.psd1";
        Set-Location $using:defaults;
        Invoke-Pester
    } |  Receive-Job -Wait -AutoRemoveJob
}

<#
    .SYNOPSIS Execute pester tests for Azure Stack modules

    .PARAMETER BuildConfig
        Build configuration, either Debug or Release

    .PARAMETER Modules
        List of modules to test.

    .PARAMETER FailFast
        If set stop on the first failing test.

#>
function Test-Stack {
    param(
        [CmdletBinding()]
        [Parameter(Mandatory = $true)]
        [System.String]$BuildConfig,

        [Parameter(Mandatory = $false)]
        [System.String[]]$Modules,

        [Parameter(Mandatory = $false)]
        [switch]$FailFast
    )

    # Create test output
    $StackPackageRoot = "$($PSSCriptRoot)\..\..\src\Stack\"
    New-Item -Path $StackPackageRoot -ItemType Directory -Force -ErrorAction SilentlyContinue | Out-Null

    # Root folder where modules are located
    $StackSrcRoot = "$($PSSCriptRoot)\..\..\src\StackAdmin\"

    # Number of failures we have seen
    [int]$Failures = 0
    $ModulePaths = @()
    foreach ($module in $Modules) {
        $ModulePaths += $StackSrcRoot + $module
    }

    foreach ($modulePath in $ModulePaths) {
        $testLocation = $modulePath + "\Tests"
        $module = $modulePath | Split-Path -Leaf
        Write-Host "Moving to $testLocation"
        Push-Location $testLocation | Out-Null
        try {
            $OutputXML = "$($StackPackageRoot)\$($module).xml"
            Invoke-Pester ".\src" -OutputFile $OutputXML -OutputFormat NUnitXml | Out-Null
            [xml]$result = Get-Content -Path $OutputXML
            $Failures += ($result."test-results".failures)
        } catch {
            Write-Error "Pester Test failure, $_"
            $Failures += 1
        } finally {
            Pop-Location | Out-Null
        }

        # Fail fast
        if ($FailFast -and $Failures -gt 0) {
            break
        }
    }
    return $Failures
}

# Scopes
$AzureScopes = @('All', 'Latest')
$StackScopes = @('Stack')

if ($Scope -in $AzureScopes) {
    Test-Azure -BuildConfig $BuildConfig
}

if ($Scope -in $StackScopes) {

    # Download and add AzureRM.Profile 3.4.1 to PSModulePath
    [System.String]$SavePath = (Join-Path -Path $PSScriptRoot -ChildPath "tmp")
    if (-not(Test-Path $SavePath)) {
        New-Item -Path $SavePath -ItemType Directory -Force | Out-Null
        Save-Module -Name AzureRM.Profile -RequiredVersion 3.4.1 -Repository PSGallery -Path $SavePath | Out-Null
        Save-Module -Name AzureRM.Resources -RequiredVersion 4.4.1 -Repository PSGallery -Path $SavePath | Out-Null
    }

    $oldModulePath = $env:PSModulePath.Clone()
    [Environment]::SetEnvironmentVariable("PSModulePath","$env:PSModulePath;$SavePath")

    # All admin modules
    $AllStackModules = @(
        "Azs.AzureBridge.Admin",
        "Azs.Backup.Admin",
        "Azs.Commerce.Admin",
        "Azs.Compute.Admin",
        "Azs.Fabric.Admin",
        "Azs.Gallery.Admin",
        "Azs.InfrastructureInsights.Admin",
        "Azs.KeyVault.Admin",
        "Azs.Network.Admin",
        "Azs.Storage.Admin",
        "Azs.Subscriptions.Admin",
        "Azs.Subscriptions",
        "Azs.Update.Admin"
    )

    # These are broken.
    $IgnoredStackModules = @()

    [System.String[]]$ModulesToTest = $AllStackModules | Where-Object { !($_ -in $IgnoredStackModules) }
    Test-Stack -BuildConfig $BuildConfig -Modules $ModulesToTest

    [Environment]::SetEnvironmentVariable("PSModulePath",$oldModulePath)
}

