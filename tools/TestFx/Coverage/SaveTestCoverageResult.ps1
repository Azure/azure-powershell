param (
    [Parameter(Mandatory, Position = 0)]
    [ValidateNotNullOrEmpty()]
    [string] $Source,

    [Parameter(Mandatory, Position = 1)]
    [ValidateNotNullOrEmpty()]
    [string] $BuildId,

    [Parameter(Mandatory, Position = 2)]
    [ValidateNotNullOrEmpty()]
    [guid] $KustoServicePrincipalTenantId,

    [Parameter(Mandatory, Position = 3)]
    [ValidateNotNullOrEmpty()]
    [guid] $KustoServicePrincipalId,

    [Parameter(Mandatory, Position = 4)]
    [ValidateNotNullOrEmpty()]
    [string] $KustoServicePrincipalSecret,

    [Parameter(Mandatory, Position = 5)]
    [ValidateNotNullOrEmpty()]
    [string] $ClusterName,

    [Parameter(Mandatory, Position = 6)]
    [ValidateNotNullOrEmpty()]
    [string] $ClusterRegion,

    [Parameter(Mandatory, Position = 7)]
    [ValidateNotNullOrEmpty()]
    [string] $DatabaseName,

    [Parameter(Mandatory, Position = 8)]
    [ValidateNotNullOrEmpty()]
    [string] $TableName,

    [Parameter(Mandatory, Position = 9)]
    [ValidateNotNull()]
    [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
    [string] $DataLocation
)

$script:AzPSCommonParameters = @("-Break", "-Confirm", "-Debug", "-DefaultProfile", "-ErrorAction", "-ErrorVariable", "-HttpPipelineAppend", "-HttpPipelinePrepend", "-InformationAction", "-InformationVariable",
    "-OutBuffer", "-OutVariable", "-PassThru", "-PipelineVariable", "-Proxy", "-ProxyCredential", "-ProxyUseDefaultCredentials", "-Verbose", "-WarningAction", "-WarningVariable", "-WhatIf")

$cvgDir = Join-Path -Path $DataLocation -ChildPath "TestCoverageAnalysis" | Join-Path -ChildPath "Raw"
if (Test-Path -LiteralPath $cvgDir -PathType Container) {
    Import-Module (Join-Path -Path ($PSScriptRoot | Split-Path) -ChildPath "Utilities" | Join-Path -ChildPath "KustoUtility.psd1") -Force

    $cvgRawCsv = Get-ChildItem -Path $cvgDir -Filter "*.csv" -File | Select-Object -ExpandProperty FullName
    $cvgRawCsv | ForEach-Object {
        (Import-Csv -Path $_) |
        Select-Object `
        @{ Name = "Source"; Expression = { $Source } }, `
        @{ Name = "BuildId"; Expression = { $BuildId } }, `
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

    Import-KustoDataFromCsv `
        -ServicePrincipalTenantId $KustoServicePrincipalTenantId `
        -ServicePrincipalId $KustoServicePrincipalId `
        -ServicePrincipalSecret $KustoServicePrincipalSecret `
        -ClusterName $ClusterName `
        -ClusterRegion $ClusterRegion `
        -DatabaseName $DatabaseName `
        -TableName $TableName `
        -CsvFile $cvgRawCsv
}
else {
    Write-Host "##[warning]No test coverage data was found." -ForegroundColor Yellow
}
