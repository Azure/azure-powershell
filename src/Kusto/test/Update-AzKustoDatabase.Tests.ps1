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
    It 'UpdateExpandedReadWrite' {
        $clusterName = $env.clusterName
        $databaseFullName = $clusterName + "/" + $env.databaseName
        
        $softDeletePeriodInDaysUpdated = Get-Updated-Soft-Delete-Period-In-Days
        $hotCachePeriodInDaysUpdated = Get-Updated-Hot-Cache-Period-In-Days
        
        $databaseUpdatedWithParameters = Update-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $env.databaseName -Location $env.location -Kind "ReadWrite" -SoftDeletePeriod $softDeletePeriodInDaysUpdated -HotCachePeriod $hotCachePeriodInDaysUpdated
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location $env.databaseType $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }

    It 'UpdateExpandedReadOnlyFollowing' {
        $clusterName = $env.followerClusterName
        $databaseFullName = $clusterName + "/" + $env.databaseName
        
        $softDeletePeriodInDaysUpdated = Get-Updated-Soft-Delete-Period-In-Days
        $hotCachePeriodInDaysUpdated = Get-Updated-Hot-Cache-Period-In-Days
        
        $databaseUpdatedWithParameters = Update-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $env.databaseName -Location $env.location -Kind "ReadOnlyFollowing" -HotCachePeriod $hotCachePeriodInDaysUpdated
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location $env.databaseType $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }

    It 'UpdateViaIdentityExpandedReadWrite' {
        $clusterName = $env.clusterName
        $databaseFullName = $clusterName + "/" + $env.databaseName
        
        $softDeletePeriodInDaysUpdated = Get-Updated-Soft-Delete-Period-In-Days
        $hotCachePeriodInDaysUpdated = Get-Updated-Hot-Cache-Period-In-Days
        
        $database = Get-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $env.databaseName
        $databaseUpdatedWithParameters = Update-AzKustoDatabase -InputObject $database -Location $env.location -Kind "ReadWrite" -SoftDeletePeriod $softDeletePeriodInDaysUpdated -HotCachePeriod $hotCachePeriodInDaysUpdated
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location $env.databaseType $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }

    It 'UpdateViaIdentityExpandedReadOnlyFollowing' {
        $clusterName = $env.followerClusterName
        $databaseFullName = $clusterName + "/" + $env.databaseName
        
        $softDeletePeriodInDaysUpdated = Get-Updated-Soft-Delete-Period-In-Days
        $hotCachePeriodInDaysUpdated = Get-Updated-Hot-Cache-Period-In-Days
        
        $database = Get-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $env.databaseName
        $databaseUpdatedWithParameters = Update-AzKustoDatabase -InputObject $database -Location $env.location -Kind "ReadOnlyFollowing" -HotCachePeriod $hotCachePeriodInDaysUpdated
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location $env.databaseType $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }
}
