param (
    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $RunPlatform,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $RunPowerShell,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $PowerShellLatest,

    [Parameter(Mandatory)]
    [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
    [string] $RepoLocation,

    [Parameter(Mandatory)]
    [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
    [string] $DataLocation
)

if ($RunPowerShell -eq "latest") {
    $curPSVer = (Get-Variable -Name PSVersionTable -ValueOnly).PSVersion
    $curMajorVer = $curPSVer.Major
    $curMinorVer = $curPSVer.Minor
    $curSimpleVer = "$curMajorVer.$curMinorVer"
    if ($curSimpleVer -eq $PowerShellLatest) {
        Write-Host "##[section]Skipping live tests for PowerShell $curSimpleVer as it has already been explicitly specified in the pipeline." -ForegroundColor Green
        return
    }
}

$srcDir = Join-Path -Path $RepoLocation -ChildPath "src"
$liveScenarios = Get-ChildItem -Path $srcDir -Directory -Exclude "Accounts" | Get-ChildItem -Directory -Filter "LiveTests" -Recurse | Get-ChildItem -File -Filter "TestLiveScenarios.ps1" | Select-Object -ExpandProperty FullName
$liveScenarios | ForEach-Object {
    $moduleName = [regex]::match($_, "[\\|\/]src[\\|\/](?<ModuleName>[a-zA-Z]+)[\\|\/]").Groups["ModuleName"].Value
    Import-Module "./tools/TestFx/Assert.ps1" -Force
    Import-Module "./tools/TestFx/Live/LiveTestUtility.psd1" -ArgumentList $moduleName, $RunPlatform, $PowerShellLatest, $DataLocation -Force
    . $_
}

$accountsDir = Join-Path -Path $srcDir -ChildPath "Accounts"
$accountsLiveScenario = Get-ChildItem -Path $accountsDir -Directory -Filter "LiveTests" -Recurse | Get-ChildItem -File -Filter "TestLiveScenarios.ps1" | Select-Object -ExpandProperty FullName
if ($null -ne $accountsLiveScenario) {
    Import-Module "./tools/TestFx/Assert.ps1" -Force
    Import-Module "./tools/TestFx/Live/LiveTestUtility.psd1" -ArgumentList "Accounts", $RunPlatform, $PowerShellLatest, $DataLocation -Force
    . $accountsLiveScenario
}

Write-Host "##[section]Waiting for all cleanup jobs to be completed." -ForegroundColor Green
while (Get-Job -State Running) {
    Start-Sleep -Seconds 30
}
Write-Host "##[section]All cleanup jobs are completed." -ForegroundColor Green

Write-Host "##[group]Cleanup jobs information." -ForegroundColor Magenta

Write-Host
$cleanupJobs = Get-Job
$cleanupJobs | Select-Object Name, Command, State, PSBeginTime, PSEndTime, Output
Write-Host

Write-Host "##[endgroup]" -ForegroundColor Magenta

$cleanupJobs | Remove-Job
