param (
    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $OSVersion,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $RunPlatform,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $RunPowerShell
)

$srcDir = Join-Path -Path ${env:BUILD_SOURCESDIRECTORY} -ChildPath "src"
$storageLiveTest = Get-ChildItem -Path $srcDir -Directory -Filter "Storage" -ErrorAction SilentlyContinue | Get-ChildItem -Directory -Filter "LiveTests" -Recurse | Get-ChildItem -File -Filter "TestLiveScenarios.ps1" -Recurse | Select-Object -ExpandProperty FullName

Import-Module "./tools/TestFx/Assert.ps1" -Force
Import-Module "./tools/TestFx/Live/LiveTestUtility.psd1" -ArgumentList 'Storage', $RunPlatform -Force
. $storageLiveTest
