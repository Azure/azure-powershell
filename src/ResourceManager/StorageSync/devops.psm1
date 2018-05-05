function Parse-StorageSyncStaticAnalysisResults
{
    dir (Join-Path $env:AzurePSRoot "src\Package\*.csv") | %{ $_.FullName } | %{ Write-Host $_ -ForegroundColor White; findstr /I "StorageSync" $_ }
}

function Build-StorageSync
{
    Start-Build -BuildScope ResourceManager\StorageSync
}

function Build-Installer
{
    param(
        [ValidateSet("DEBUG", "RELEASE")]
        [string]$BuildConfig)


    & powershell.exe (Join-Path $env:AzurePSRoot "tools\Installer\generate.ps1") $BuildConfig
}

Export-ModuleMember -Function Parse-StorageSyncStaticAnalysisResults
Export-ModuleMember -Function Build-Installer
Export-ModuleMember -Function Build-StorageSync
