param(
    [Parameter(Mandatory)]
    [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
    [string] $RepoLocation
)

$debugDirectory = Join-Path -Path $RepoLocation -ChildPath "artifacts" | Join-Path -ChildPath "Debug"
$accountsModuleDirectory = Join-Path -Path $debugDirectory -ChildPath "Az.Accounts"
Write-Host "Start to import Azure PowerShell modules from artifacts/Debug." -ForegroundColor Green
Write-Host "If you see module import issue, please restart the PowerShell host." -ForegroundColor Magenta

Write-Host "Importing Az.Accounts." -ForegroundColor Green
Import-Module (Join-Path -Path $accountsModuleDirectory -ChildPath "Az.Accounts.psd1")
Get-ChildItem -Path $debugDirectory -Directory -Exclude "Az.Accounts" | Get-ChildItem -File -Filter "*.psd1" | ForEach-Object {
    Write-Host "Importing $($_.FullName)." -ForegroundColor Green
    Import-Module $_.FullName -Force
}
Write-Host "Successfully imported Azure PowerShell modules from artifacts/Debug" -ForegroundColor Green

$dataLocation = (Get-AzConfig -TestCoverageLocation).Value
if ([string]::IsNullOrWhiteSpace($dataLocation) -or !(Test-Path -LiteralPath $dataLocation -PathType Container)) {
    $dataLocation = Join-Path -Path $env:USERPROFILE -ChildPath ".Azure"
}
Write-Host "Data location is `"$dataLocation`"" -ForegroundColor Cyan

$srcDir = Join-Path -Path $RepoLocation -ChildPath "src"
$liveScenarios = Get-ChildItem -Path $srcDir -Recurse -Directory -Filter "LiveTests" | Get-ChildItem -Filter "TestLiveScenarios.ps1" -File
$liveScenarios | ForEach-Object {
    $moduleName = [regex]::match($_.FullName, "[\\|\/]src[\\|\/](?<ModuleName>[a-zA-Z]+)[\\|\/]").Groups["ModuleName"].Value
    Import-Module "./tools/TestFx/Assert.ps1" -Force
    Import-Module "./tools/TestFx/Live/LiveTestUtility.psd1" -ArgumentList $moduleName, "LocalDebug", "LocalDebug", "LocalDebug", $dataLocation -Force
    . $_.FullName
}
