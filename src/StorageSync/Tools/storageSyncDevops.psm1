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
    & msbuild.exe $buildProj /p:SkipHelp=$SkipHelp /t:$Target /p:Scope=$Scope /p:Configuration=$BuildConfig
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
        $status = Update-MarkdownHelpModule -Path $PathToHelpFolder -RefreshModulePage -AlphabeticParamsOrder -UseFullTypeName
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
        
        Write-Verbose "Executing command: ValidateMarkdownHelp @ . $script -ValidateMarkdownHelp -BuildConfig $BuildConfig -FilteredModules $null"
        $result = . $script -ValidateMarkdownHelp -BuildConfig $BuildConfig -FilteredModules $null
        Write-Verbose "Command ValidateMarkdownHelp result: $result"

        if (! $WhatIf)
        {
            Write-Verbose "Executing command: GenerateMamlHelp"
            $result = . $script -GenerateMamlHelp -BuildConfig $BuildConfig -FilteredModules $null
        }
    } 
    catch {
        Write-Warning "Use Parse-StorageSyncHelpAnalysisResults to see validation results"
        Write-Warning $_.Exception.ToString()
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

Export-ModuleMember -Function *-StorageSync*
Export-ModuleMember -Function Build-Installer
