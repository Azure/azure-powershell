param (
    [Parameter(Mandatory, Position = 0)]
    [ValidateNotNullOrEmpty()]
    [string] $BuildId,

    [Parameter(Mandatory, Position = 1)]
    [ValidateNotNullOrEmpty()]
    [string] $OSVersion,

    [Parameter(Mandatory, Position = 2)]
    [ValidateNotNullOrEmpty()]
    [string] $PSVersion,

    [Parameter(Mandatory, Position = 3)]
    [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
    [string] $RepoLocation,

    [Parameter(Mandatory, Position = 4)]
    [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
    [string] $DataLocation
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
    Import-Module $testCoverageUtility
    $module = Get-Module -Name "Az.$ModuleName" -ListAvailable
    $moduleDetails = Get-TestCoverageModuleDetails -Module $module

    $testCoverageRawCsv = Join-Path -Path $TestCoverageDataLocation -ChildPath "TestCoverageAnalysis" | Join-Path -ChildPath "Raw" | Join-Path -ChildPath "Az.$ModuleName.csv"
    (Import-Csv -LiteralPath $testCoverageRawCsv) |
    Select-Object @{ Name = "BuildId"; Expression = { "$BuildId" } }, `
        @{ Name = "OSVersion"; Expression = { "$OSVersion" } }, `
        @{ Name = "PSVersion"; Expression = { "$PSVersion" } }, `
        @{ Name = "Module"; Expression = { "$ModuleName" } }, `
        "CommandName", @{ Name = "TotalCommands"; Expression = { "$($moduleDetails['TotalCommands'])" } }, `
        "ParameterSetName", @{ Name = "TotalParameterSets"; Expression = { "$($moduleDetails['TotalParameterSets'])" } }, `
        "Parameters", @{ Name = "TotalParameters"; Expression = { "$($moduleDetails['TotalParameters'])" } }, `
        "SourceScript", "LineNumber", "StartDateTime", "EndDateTime", "IsSuccess" |
    Export-Csv -LiteralPath $testCoverageRawCsv -Encoding utf8 -NoTypeInformation -Force
}

$srcDir = Join-Path -Path $RepoLocation -ChildPath "src"
$liveScenarios = Get-ChildItem -LiteralPath $srcDir -Recurse -Directory -Filter "LiveTests" | ForEach-Object {
    Get-ChildItem -Path (Join-Path -Path $_.FullName -ChildPath "TestLiveScenarios.ps1") -File
}
$liveScenarios | ForEach-Object {
    $moduleName = [regex]::match($_.FullName, "[\\|\/]src[\\|\/](?<ModuleName>[a-zA-Z]+)[\\|\/]").Groups["ModuleName"].Value
    if ($PSVersion -eq "latest") {
        $PSVersion = (Get-Variable -Name PSVersionTable).Value.PSVersion.ToString()
    }
    Import-Module "./tools/TestFx/Assert.ps1" -Force
    Import-Module "./tools/TestFx/Live/LiveTestUtility.psd1" -ArgumentList $moduleName, $BuildId, $OSVersion, $PSVersion, $DataLocation -Force
    . $_
    FillLiveTestCoverageAdditionalInfo -TestCoverageDataLocation $DataLocation -BuildId $BuildId -OSVersion $OSVersion -PSVersion $PSVersion -ModuleName $moduleName
}
