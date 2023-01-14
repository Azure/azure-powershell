param (
    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $BuildId,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $OSVersion,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $PSVersion,

    [Parameter(Mandatory)]
    [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
    [string] $RepoLocation
)

function FillLiveTestCoverageAdditionalInfo {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory)]
        [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
        [string] $TestCoverageDataLocation,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string] $BuildId,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string] $OSVersion,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string] $PSVersion,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string] $ModuleName
    )

    $testCoverageUtility = $PSScriptRoot | Split-Path | Join-Path -ChildPath "Coverage" | Join-Path -ChildPath "TestCoverageUtility.psd1"
    Import-Module $testCoverageUtility -Force
    $module = Get-Module -Name "Az.$ModuleName" -ListAvailable
    $moduleDetails = Get-TestCoverageModuleDetails -Module $module

    $testCoverageRawCsv = Join-Path -Path $TestCoverageDataLocation -ChildPath "TestCoverageAnalysis" | Join-Path -ChildPath "Raw" | Join-Path -ChildPath "Az.$ModuleName.csv"
    if (Test-Path -LiteralPath $testCoverageRawCsv -PathType Leaf) {
        (Import-Csv -LiteralPath $testCoverageRawCsv) |
        Select-Object `
        @{ Name = "Source"; Expression = { "LiveTest" } }, `
        @{ Name = "BuildId"; Expression = { "$BuildId" } }, `
        @{ Name = "OSVersion"; Expression = { "$OSVersion" } }, `
        @{ Name = "PSVersion"; Expression = { "$PSVersion" } }, `
        @{ Name = "Module"; Expression = { "$ModuleName" } }, `
        @{ Name = "CommandName"; Expression = { $_.CommandName } }, `
        @{ Name = "TotalCommands"; Expression = { "$($moduleDetails['TotalCommands'])" } }, `
        @{ Name = "ParameterSetName"; Expression = { $_.ParameterSetName } }, `
        @{ Name = "TotalParameterSets"; Expression = { "$($moduleDetails['TotalParameterSets'])" } }, `
        @{ Name = "Parameters"; Expression = { $_.Parameters } }, `
        @{ Name = "TotalParameters"; Expression = { "$($moduleDetails['TotalParameters'])" } }, `
        @{ Name = "SourceScript"; Expression = { $_.SourceScript } }, `
        @{ Name = "LineNumber"; Expression = { $_.LineNumber } }, `
        @{ Name = "StartDateTime"; Expression = { $_.StartDateTime } }, `
        @{ Name = "EndDateTime"; Expression = { $_.EndDateTime } }, `
        @{ Name = "IsSuccess"; Expression = { $_.IsSuccess } } |
        Export-Csv -LiteralPath $testCoverageRawCsv -Encoding utf8 -NoTypeInformation -Force
    }
    else {
        Write-Host "##[warning]No test coverage data was found. Either the test coverage is not enabled or all live test commands were failed for the module `"$ModuleName`"."
    }
}

if ($PSVersion -eq "latest") {
    $PSVersion = (Get-Variable -Name PSVersionTable).Value.PSVersion.ToString()
}

$dataLocation = (Get-AzConfig -TestCoverageLocation).Value
if ([string]::IsNullOrWhiteSpace($dataLocation) -or !(Test-Path -LiteralPath $dataLocation -PathType Container)) {
    $dataLocation = Join-Path -Path $env:USERPROFILE -ChildPath ".Azure"
}

$srcDir = Join-Path -Path $RepoLocation -ChildPath "src"
$liveScenarios = Get-ChildItem -Path $srcDir -Recurse -Directory -Filter "LiveTests" | Get-ChildItem -Filter "TestLiveScenarios.ps1" -File
$liveScenarios | ForEach-Object {
    $moduleName = [regex]::match($_.FullName, "[\\|\/]src[\\|\/](?<ModuleName>[a-zA-Z]+)[\\|\/]").Groups["ModuleName"].Value
    Import-Module "./tools/TestFx/Assert.ps1" -Force
    Import-Module "./tools/TestFx/Live/LiveTestUtility.psd1" -ArgumentList $moduleName, $BuildId, $OSVersion, $PSVersion, $dataLocation -Force
    . $_.FullName
    FillLiveTestCoverageAdditionalInfo -TestCoverageDataLocation $dataLocation -BuildId $BuildId -OSVersion $OSVersion -PSVersion $PSVersion -ModuleName $moduleName
}
