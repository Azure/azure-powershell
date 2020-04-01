$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzKustoDatabase.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzKustoDatabase' {
    It 'Update' {
        $location = Get-Location
        $resourceGroupName = Get-RG-Name
        $clusterName = Get-Cluster-Name
        $databaseName = Get-Database-Name
        $resourceType =  Get-Database-Type
        $databaseFullName = "$clusterName/$databaseName"
        
        $softDeletePeriodInDaysUpdated = Get-Updated-Soft-Delete-Period-In-Days
        $hotCachePeriodInDaysUpdated = Get-Updated-Hot-Cache-Period-In-Days
        
        $databaseUpdatedWithParameters = Update-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Parameter @{SoftDeletePeriod= $softDeletePeriodInDaysUpdated; HotCachePeriod=$hotCachePeriodInDaysUpdated}
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $location $resourceType $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }
}
