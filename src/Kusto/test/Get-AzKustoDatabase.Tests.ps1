$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoDatabase.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzKustoDatabase' {
    It 'List' {
        $location = Get-Location
        $resourceGroupName = Get-RG-Name
        $clusterName = Get-Cluster-Name
        $databaseName = Get-Database-Name
        $resourceType =  Get-Database-Type
        $softDeletePeriodInDays =  Get-Updated-Soft-Delete-Period-In-Days
        $hotCachePeriodInDays =  Get-Updated-Hot-Cache-Period-In-Days
        $databaseFullName = "$clusterName/$databaseName"

        [array]$databaseGet = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $databaseGetItem = $databaseGet[0]
        Validate_Database $databaseGetItem $databaseFullName $location $resourceType $softDeletePeriodInDays $hotCachePeriodInDays
    }

    It 'Get' {
        $location = Get-Location
        $resourceGroupName = Get-RG-Name
        $clusterName = Get-Cluster-Name
        $databaseName = Get-Database-Name
        $resourceType =  Get-Database-Type
        $softDeletePeriodInDays =  Get-Updated-Soft-Delete-Period-In-Days
        $hotCachePeriodInDays =  Get-Updated-Hot-Cache-Period-In-Days
        $databaseFullName = "$clusterName/$databaseName"

        $databaseGetItem = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        Validate_Database $databaseGetItem $databaseFullName $location $resourceType $softDeletePeriodInDays $hotCachePeriodInDays
    }
}
