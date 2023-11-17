param (
    [Parameter(Mandatory, Position = 0)]
    [ValidateNotNullOrEmpty()]
    [guid] $TenantId,

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
    [string] $ClusterRegion
)

$ltDir = Join-Path -Path ${env:DATALOCATION} -ChildPath "LiveTestAnalysis" | Join-Path -ChildPath "Raw"
$ltResults = Get-ChildItem -Path $ltDir -Filter "*.csv" -File -ErrorAction SilentlyContinue | Select-Object -ExpandProperty FullName

if (![string]::IsNullOrEmpty($ltResults)) {
    Import-Module "./tools/TestFx/Utilities/KustoUtility.psd1" -ArgumentList $TenantId, $ServicePrincipalId, $ServicePrincipalSecret, $ClusterName, $ClusterRegion -Force
    Add-KustoData -DatabaseName ${env:LIVETESTDATABASENAME} -TableName ${env:LIVETESTTABLENAME} -CsvFile $ltResults
}
else {
    Write-Host "##[warning]No live test data was found."
}
