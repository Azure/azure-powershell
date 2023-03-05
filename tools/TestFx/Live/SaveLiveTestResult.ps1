param (
    [Parameter(Mandatory, Position = 0)]
    [ValidateNotNullOrEmpty()]
    [guid] $ServicePrincipalTenantId,

    [Parameter(Mandatory, Position = 1)]
    [ValidateNotNullOrEmpty()]
    [guid] $ServicePrincipalId,

    [Parameter(Mandatory, Position = 2)]
    [ValidateNotNullOrEmpty()]
    [string] $ServicePrincipalSecret,

    [Parameter(Mandatory, Position = 3)]
    [ValidateNotNullOrEmpty()]
    [string] $ClusterName,

    [Parameter(Mandatory, Position = 4)]
    [ValidateNotNullOrEmpty()]
    [string] $ClusterRegion,

    [Parameter(Mandatory, Position = 5)]
    [ValidateNotNullOrEmpty()]
    [string] $DatabaseName,

    [Parameter(Mandatory, Position = 6)]
    [ValidateNotNullOrEmpty()]
    [string] $TableName,

    [Parameter(Mandatory, Position = 8)]
    [ValidateNotNullOrEmpty()]
    [string] $DataLocation
)

Import-Module "./tools/TestFx/Utilities/KustoUtility.psd1" -Force

$liveTestDir = Join-Path -Path $DataLocation -ChildPath "LiveTestAnalysis" | Join-Path -ChildPath "Raw"
$liveTestResults = Get-ChildItem -Path $liveTestDir -Filter "*.csv" -File -ErrorAction SilentlyContinue | Select-Object -ExpandProperty FullName
if (![string]::IsNullOrWhiteSpace($liveTestResults) -and (Test-Path -LiteralPath $liveTestResults -PathType Leaf)) {
    Import-KustoDataFromCsv `
        -ServicePrincipalTenantId $ServicePrincipalTenantId `
        -ServicePrincipalId $ServicePrincipalId `
        -ServicePrincipalSecret $ServicePrincipalSecret `
        -ClusterName $ClusterName `
        -ClusterRegion $ClusterRegion `
        -DatabaseName $DatabaseName `
        -TableName $TableName `
        -CsvFile $liveTestResults
}
else {
    Write-Host "##[warning]No live test data was found."
}
