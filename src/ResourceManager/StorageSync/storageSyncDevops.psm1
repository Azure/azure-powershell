function Get-BuildOutputDirectory
{
    return (Join-Path $env:AzurePSRoot "src\Package")
}

function Build-StorageSync
{
    Start-Build -BuildScope StorageSync
}

function Build-Installer
{
    param(
        [Parameter(Mandatory = $true)]
        [ValidateSet("DEBUG", "RELEASE")]
        [string]$BuildConfig)


    & powershell.exe (Join-Path $env:AzurePSRoot "tools\Installer\generate.ps1") $BuildConfig
}

function Update-StorageSyncHelp
{
    param(
        [Parameter(Mandatory = $true)]
        [ValidateSet("DEBUG", "RELEASE")]
        [string]$BuildConfig)

    $PathToModuleManifest = Join-Path (Get-BuildOutputDirectory) "$($BuildConfig)\ResourceManager\AzureResourceManager\AzureRM.StorageSync\AzureRM.StorageSync.psd1"
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

        $PathToHelpFolder = Join-Path $env:AzurePSRoot "src\ResourceManager\StorageSync\Commands.StorageSync\help"
        Write-Verbose "Updating help: $PathToHelpFolder"
        $status = Update-MarkdownHelpModule -Path $PathToHelpFolder -RefreshModulePage -AlphabeticParamsOrder
    }
    finally
    {
        Write-Verbose "Removing module: AzureRm.StorageSync"
        Remove-Module -Name AzureRm.StorageSync
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

        $script = Join-Path $env:AzurePSRoot "tools\GenerateHelp.ps1"
        
        Write-Verbose "Executing command: ValidateMarkdownHelp"
        $result = . $script -ValidateMarkdownHelp -BuildConfig $BuildConfig

        if (! $WhatIf)
        {
            Write-Verbose "Executing command: GenerateMamlHelp"
            $result = . $script -GenerateMamlHelp -BuildConfig $BuildConfig
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

Export-ModuleMember -Function *-StorageSync*
Export-ModuleMember -Function Build-Installer
