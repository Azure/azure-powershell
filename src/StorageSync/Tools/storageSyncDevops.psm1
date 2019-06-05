$global:ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest
$scriptDirectory = Split-Path ($MyInvocation.MyCommand.Path)  

# This function can be used from outside of devshell
# to bootstrap the environment.
# it is only safe to use functions from within this library.
# do not use anything from devshell as it might not be available, yet.
function Setup-DevShell
{    
    $libraryDir = Join-Path $scriptDirectory "lib"
    $devShellModuleName = "Microsoft.Utility.DevShell"
    $devShellModuleVersion = "1.0.0.6"
    $devShellModuleDirectoryName = "$($devShellModuleName).$($devShellModuleVersion)"
    
    $nugetPath = Join-Path $libraryDir "nuget.exe"
    if (! (Test-Path $nugetPath))
    {
        mkdir $libraryDir -Force | Out-Null
        Write-Output "Downloading latest nuget.exe to $nugetPath"
        Invoke-WebRequest -Uri "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile $nugetPath
        if (!(Test-Path $nugetPath))
        {
            throw "nuget.exe is not available at $nugetPath"
        }
    }

    $devShellPath = Join-Path $libraryDir $devShellModuleDirectoryName
    if (!(Test-Path $devShellPath))
    {
        $output = & $nugetPath install $devShellModuleName -Version $devShellModuleVersion -OutputDirectory ($libraryDir) -Source "https://msazure.pkgs.visualstudio.com/DefaultCollection/_apis/packaging/ManualMirror/nuget/index.json"

        if (!(Test-Path $devShellPath))
        {
            throw "DevShell is not available at $($devShellPath)`nNuget was supposed to install it. Check out of command 'nuget install $devShellModuleName -Version $devShellModuleVersion' below:`n`n$output"
        }
        else
        {
            Write-Output "DevShell has been successfully downloaded to $($devShellPath)"

            $env:DevShellPath = $devShellPath
            $envVar = "DevShellPath"
            [environment]::SetEnvironmentVariable($envVar, $devShellPath, "MACHINE") | Out-Null
            Write-Output "Environment variable $($envVar) has been setup appropriately"
            
            Write-Warning "You might need to restart you command shell..."
        }
    }
}

function Get-MsBuild
{
    $options = @( "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin" )
    $options += ($env:PATH -split ";")
    
    foreach ($option in $options)
    {
        $candidate = Join-Path $option "msbuild.exe"
        if (Test-Path $candidate)
        {
            return $candidate
        }
    }

    return "msbuild.exe"
}

function Get-RepositoryRootDirectory
{
    return $env:AzurePSRoot
}

function Get-BuildOutputDirectory
{
    return (Join-Path (Get-RepositoryRootDirectory) "artifacts")
}

function Build-StorageSync
{
<#  
.SYNOPSIS 
Performs Repo-Tasks' based build scoped to StorageSync.
.EXAMPLE
Build-StorageSync
Performs build.
#>    
    Start-Build -BuildScope StorageSync
}

function MsBuild-StorageSync
{
<#  
.SYNOPSIS 
Performs msbuild scoped to StorageSync.
.PARAMETER BuildConfig
Build Configuration
.PARAMETER Target
Build Target
.PARAMETER SkipHelp
Switch to skip Help processing.
.EXAMPLE
MsBuild-StorageSync -BuildConfig DEBUG -Target Clean -Verbose
Performs build output directory cleanup.
.EXAMPLE
MsBuild-StorageSync -BuildConfig DEBUG -Target Build -SkipHelp -Verbose
Performs DEBUG build skipping Help processing.
#>    
    param(
        [Parameter(Mandatory = $true)]
        [ValidateSet("DEBUG", "RELEASE")]
        [string]$BuildConfig = "DEBUG",

        [Parameter(Mandatory = $true)]
        [ValidateSet("Clean","Build","Test","Publish")]
        [string]$Target = "Build",

        [Parameter(Mandatory = $false)]
        [string]$Scope,

        [switch]$SkipHelp)

    Write-Verbose "BuildConfig is $BuildConfig"
    Write-Verbose "Target is $Target"
    Write-Verbose "SkipHelp is $SkipHelp"

    if ([string]::IsNullOrEmpty($Scope))
    {
        $Scope = "StorageSync"
    }

    Write-Verbose "Scope is $Scope"

    $buildProj = Join-Path (Get-RepositoryRootDirectory) build.proj
    $msbuildPath = Get-MsBuild
    & $msbuildPath $buildProj /p:SkipHelp=$SkipHelp /t:$Target /p:Scope=$Scope /p:Configuration=$BuildConfig
}

function Build-Installer
{
    param(
        [Parameter(Mandatory = $true)]
        [ValidateSet("DEBUG", "RELEASE")]
        [string]$BuildConfig)


    & powershell.exe (Join-Path (Get-RepositoryRootDirectory) "tools\Installer\generate.ps1") $BuildConfig
}

function Update-StorageSyncHelp
{
    param(
        [Parameter(Mandatory = $true)]
        [ValidateSet("DEBUG", "RELEASE")]
        [string]$BuildConfig)

    $PathToModuleManifest = Join-Path (Get-BuildOutputDirectory) "$($BuildConfig)\Az.Accounts\Az.Accounts.psd1"
    Write-Verbose "Loading manifest: $PathToModuleManifest"
    Import-Module $PathToModuleManifest -Scope Global

    $PathToModuleManifest = Join-Path (Get-BuildOutputDirectory) "$($BuildConfig)\Az.StorageSync\Az.StorageSync.psd1"
    Write-Verbose "Loading manifest: $PathToModuleManifest"
    Import-Module $PathToModuleManifest -Scope Global

    $status = $null
    try 
    {
        Write-Verbose "Re-Loading module: platyPS"
        if (Get-Module platyPS)
        {
            Remove-Module platyPS
        }
        Import-Module platyPS

        $PathToHelpFolder = Join-Path (Get-RepositoryRootDirectory) "src\StorageSync\StorageSync\help"
        Write-Verbose "Updating help: $PathToHelpFolder"
        $status = Update-MarkdownHelpModule -Path $PathToHelpFolder -RefreshModulePage -AlphabeticParamsOrder
    }
    finally
    {
        Write-Verbose "Removing module: Az.StorageSync"
        Remove-Module -Name Az.StorageSync
    }

    return $status
}

function Generate-StorageSyncMaml
{
    param(
        [Parameter(Mandatory = $true)]
        [ValidateSet("DEBUG", "RELEASE")]
        [string]$BuildConfig,
        [switch]$WhatIf)

    $result = $null
    Push-Location (Get-BuildOutputDirectory)
    $oldProgressPreference = $ProgressPreference
    try 
    {
        $ProgressPreference = 'SilentlyContinue'

        $script = Join-Path (Get-RepositoryRootDirectory) "tools\GenerateHelp.ps1"
        
        Write-Verbose "Executing command: ValidateMarkdownHelp"
        $result = . $script -ValidateMarkdownHelp -BuildConfig $BuildConfig -FilteredModules $null

        if (! $WhatIf)
        {
            Write-Verbose "Executing command: GenerateMamlHelp"
            $result = . $script -GenerateMamlHelp -BuildConfig $BuildConfig -FilteredModules $null
        }
    } 
    catch {
        Write-Warning "Use Parse-StorageSyncHelpAnalysisResults to see validation results"
        throw $_
    }
    finally
    {
        Pop-Location
        $ProgressPreference = $oldProgressPreference
    }

    return $result
}

function Load-OutputCsv
{
    param ($Name)

    $csvPath = Join-Path (Get-BuildOutputDirectory) $Name
    
    if (Test-Path $csvPath)
    {
        Import-Csv $csvPath
    }
}

function Parse-StorageSyncHelpAnalysisResults
{
    Load-OutputCsv "ValidateHelpIssues.csv"
}

function Parse-StorageSyncStaticAnalysisResults
{
    $staticAnalysisCsvs = @( 'ExtraAssemblies.csv', 'MissingAssemblies.csv', 'SignatureIssues.csv')
    foreach ($csvName in $staticAnalysisCsvs)
    {
        $csvPath = Join-Path (Get-BuildOutputDirectory) $csvName
        if (Test-Path $csvPath)
        {
            Write-Host $csvName -ForegroundColor White
            findstr /I StorageSync $csvPath
        }
    }
}

function Get-TestAuthenticationString
{
    param(
        [Parameter(Mandatory = $True)]
        [ValidateSet('Int','Dev','Prod')]
        $Mode,
        [Parameter(Mandatory = $True)]
        [ValidateSet('Record','Playback')]
        $TestMode)

    Trace-Start

    Trace-Argument -Name Mode -Value $Mode
    Trace-Argument -Name TestMode -Value $TestMode

    switch ($Mode)
    {
        "Int" 
        {
            $secret = Get-KeyVaultTestSecret -Name "SdkTestIntAuthenticationString"
            return "$($secret);HttpRecorderMode=$($TestMode);"
        }
        "Dev" 
        {
            $secret = Get-KeyVaultTestSecret -Name "SdkTestDevAuthenticationString"
            return "$($secret);HttpRecorderMode=$($TestMode);"
        }
        "Prod" 
        {
            $secret = Get-KeyVaultTestSecret -Name "SdkTestProdAuthenticationString"
            return "$($secret);HttpRecorderMode=$($TestMode);OptimizeRecordedFile=false;"
        }
        default { throw "Unsupported mode: $Mode"}
    }    
    Trace-Exit | Out-Null
}

function Record-UnitTests
{
    param(
        [Parameter(Mandatory = $True)]
        [ValidateSet('Int','Dev','Prod')]
        $Mode)

    Trace-Start
    Trace-Argument -Name Mode -Value $Mode
    $solutionPath = Join-Path $scriptDirectory "..\StorageSync.sln"

    $authString = Get-TestAuthenticationString -Mode $Mode -TestMode Record
    [environment]::SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", $authString) | Out-Null
    [environment]::SetEnvironmentVariable("AZURE_TEST_MODE", "Record") | Out-Null

    start $solutionPath
    Trace-Exit | Out-Null
}

function Replay-UnitTests
{
    param(
        [Parameter(Mandatory = $True)]
        [ValidateSet('Int','Dev','Prod')]
        $Mode)

    Trace-Start
    Trace-Argument -Name Mode -Value $Mode
    $solutionPath = Join-Path $scriptDirectory "..\StorageSync.sln"

    $authString = Get-TestAuthenticationString -Mode $Mode -TestMode Playback
    [environment]::SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", $authString) | Out-Null
    [environment]::SetEnvironmentVariable("AZURE_TEST_MODE", "Playback") | Out-Null

    start $solutionPath
    Trace-Exit | Out-Null
}

if ($null -ne $env:DevShellPath -and (Test-Path $env:DevShellPath))
{
    Import-Module (Join-Path $env:DevShellPath "DevShellCommon.psm1") -NoClobber -DisableNameChecking
    Import-Module (Find-DevShellModule "KailaniPSUtilities.psm1") -NoClobber -DisableNameChecking
    Import-Module (Find-DevShellModule "KeyVault.psm1") -NoClobber -DisableNameChecking
}
else
{
    Write-Warning "Running without DevShell - functionality is limited."
    Write-Warning "You probably want to run Setup-DevShell and restart your shell..."
}

Export-ModuleMember -Function *-StorageSync*
Export-ModuleMember -Function Build-Installer
Export-ModuleMember -Function *-UnitTests
Export-ModuleMember -Function Get-TestAuthenticationString