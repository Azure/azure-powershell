param (
    [Parameter(Mandatory, Position = 0)]
    [ValidateNotNullOrEmpty()]
    [string] $Source,

    [Parameter(Mandatory, Position = 1)]
    [ValidateNotNullOrEmpty()]
    [guid] $KustoServicePrincipalTenantId,

    [Parameter(Mandatory, Position = 2)]
    [ValidateNotNullOrEmpty()]
    [guid] $KustoServicePrincipalId,

    [Parameter(Mandatory, Position = 3)]
    [ValidateNotNullOrEmpty()]
    [string] $KustoServicePrincipalSecret,

    [Parameter(Mandatory, Position = 4)]
    [ValidateNotNullOrEmpty()]
    [string] $ClusterName,

    [Parameter(Mandatory, Position = 5)]
    [ValidateNotNullOrEmpty()]
    [string] $ClusterRegion
)

$script:AzPSCommonParameters = @("-Break", "-Confirm", "-Debug", "-DefaultProfile", "-ErrorAction", "-ErrorVariable", "-HttpPipelineAppend", "-HttpPipelinePrepend", "-InformationAction", "-InformationVariable",
    "-OutBuffer", "-OutVariable", "-PassThru", "-PipelineVariable", "-Proxy", "-ProxyCredential", "-ProxyUseDefaultCredentials", "-Verbose", "-WarningAction", "-WarningVariable", "-WhatIf")

$cvgDir = Join-Path -Path ${env:TESTCOVERAGELOCATION} -ChildPath "TestCoverageAnalysis" | Join-Path -ChildPath "Raw"
if (Test-Path -LiteralPath $cvgDir -PathType Container) {
    $kustoUtil = Join-Path -Path ($PSScriptRoot | Split-Path) -ChildPath "Utilities" | Join-Path -ChildPath "KustoUtility.psd1"
    Import-Module $kustoUtil -ArgumentList $KustoServicePrincipalTenantId, $KustoServicePrincipalId, $KustoServicePrincipalSecret, $ClusterName, $ClusterRegion -Force

    $cvgRawCsv = Get-ChildItem -Path $cvgDir -Filter "*.csv" -File | Select-Object -ExpandProperty FullName
    $cvgRawCsv | ForEach-Object {
        (Import-Csv -Path $_) |
        Select-Object `
        @{ Name = "Source"; Expression = { $Source } }, `
        @{ Name = "BuildId"; Expression = { ${env:BUILD_BUILDID} } }, `
        @{ Name = "Module"; Expression = { $_.Module } }, `
        @{ Name = "CommandName"; Expression = { $_.CommandName } }, `
        @{ Name = "TotalCommands"; Expression = { $_.TotalCommands } }, `
        @{ Name = "ParameterSetName"; Expression = { $_.ParameterSetName } }, `
        @{ Name = "TotalParameterSets"; Expression = { $_.TotalParameterSets } }, `
        @{ Name = "Parameters"; Expression = { $_.Parameters } }, `
        @{ Name = "TotalParameters"; Expression = { $_.TotalParameters } }, `
        @{ Name = "SourceScript"; Expression = { $_.SourceScript } }, `
        @{ Name = "LineNumber"; Expression = { $_.LineNumber } }, `
        @{ Name = "StartDateTime"; Expression = { $_.StartDateTime } }, `
        @{ Name = "EndDateTime"; Expression = { $_.EndDateTime } }, `
        @{ Name = "IsSuccess"; Expression = { $_.IsSuccess } } |
        Export-Csv -Path $_ -Encoding utf8 -NoTypeInformation -Force
    }

    Import-KustoDataFromCsv -DatabaseName ${env:TESTCOVERAGEDATABASENAME} -TableName ${env:TESTCOVERAGETABLENAME} -CsvFile $cvgRawCsv
}
else {
    Write-Host "##[warning]No test coverage data was found." -ForegroundColor Yellow
}
