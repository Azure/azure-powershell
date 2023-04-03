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

    [Parameter(Mandatory, Position = 7)]
    [ValidateNotNullOrEmpty()]
    [string] $DataLocation,

    [Parameter(Mandatory, Position = 8)]
    [ValidateNotNullOrEmpty()]
    [string] $BuildId,

    [Parameter(Mandatory, Position = 9)]
    [ValidateNotNullOrEmpty()]
    [string] $OSVersion,

    [Parameter(Position = 10)]
    [string] $Tag = [string]::Empty
)

$liveTestDir = Join-Path -Path $DataLocation -ChildPath "LiveTestAnalysis" | Join-Path -ChildPath "Raw"
$liveTestResults = Get-ChildItem -Path $liveTestDir -Filter "*.csv" -File -ErrorAction SilentlyContinue | Select-Object -ExpandProperty FullName

if (![string]::IsNullOrWhiteSpace($liveTestResults)) {
    if (![string]::IsNullOrEmpty($Tag)) {
        $exProps = @{ Tag = $Tag } | ConvertTo-Json -Compress
    }

    $liveTestResults | ForEach-Object {
        (Import-Csv -Path $_) |
        Select-Object `
        @{ Name = "Source"; Expression = { "LiveTest" } }, `
        @{ Name = "BuildId"; Expression = { $BuildId } }, `
        @{ Name = "OSVersion"; Expression = { $OSVersion } }, `
        @{ Name = "PSVersion"; Expression = { $_.PSVersion } }, `
        @{ Name = "Module"; Expression = { $_.Module } }, `
        @{ Name = "Name"; Expression = { $_.Name } }, `
        @{ Name = "Description"; Expression = { $_.Description } }, `
        @{ Name = "StartDateTime"; Expression = { $_.StartDateTime } }, `
        @{ Name = "EndDateTime"; Expression = { $_.EndDateTime } }, `
        @{ Name = "IsSuccess"; Expression = { $_.IsSuccess } }, `
        @{ Name = "Errors"; Expression = { $_.Errors } }, `
        @{ Name = "ExtendedProperties"; Expression = { $exProps } } |
        Export-Csv -Path $_ -Encoding utf8 -NoTypeInformation -Force
    }

    Import-Module "./tools/TestFx/Utilities/KustoUtility.psd1" -Force
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
