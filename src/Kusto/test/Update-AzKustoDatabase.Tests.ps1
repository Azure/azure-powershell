$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzKustoDatabase.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzKustoDatabase' {
    It 'UpdateExpandedReadWrite' {
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $resourceGroupName = $env.resourceGroupName
        $databaseFullName = $clusterName + "/" + $databaseName

        $databaseItem = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $softDeletePeriodInDaysUpdated = $databaseItem.SoftDeletePeriod.Add((New-TimeSpan -Days 1))
        $hotCachePeriodInDaysUpdated = $databaseItem.HotCachePeriod.Add((New-TimeSpan -Days 1))

        $databaseUpdatedWithParameters = Update-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Location $env.location -Kind "ReadWrite" -SoftDeletePeriod $softDeletePeriodInDaysUpdated -HotCachePeriod $hotCachePeriodInDaysUpdated
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location $env.databaseType $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }

    It 'UpdateExpandedReadOnlyFollowing' {
        $clusterName = $env.followerClusterName
        $resourceGroupName = $env.resourceGroupName
        $databaseName = $env.databaseName
        $databaseFullName = $clusterName + "/" + $databaseName

        $databaseItem = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $softDeletePeriodInDaysUpdated = $databaseItem.SoftDeletePeriod
        $hotCachePeriodInDaysUpdated = $databaseItem.HotCachePeriod.Add((New-TimeSpan -Days 1))

        $databaseUpdatedWithParameters = Update-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Location $env.location -Kind "ReadOnlyFollowing" -HotCachePeriod $hotCachePeriodInDaysUpdated
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location $env.databaseType $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }

    It 'UpdateViaIdentityExpandedReadWrite' {
        $clusterName = $env.clusterName
        $resourceGroupName = $env.resourceGroupName
        $databaseName = $env.databaseName
        $databaseFullName = $clusterName + "/" + $databaseName

        $databaseItem = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $softDeletePeriodInDaysUpdated = $databaseItem.SoftDeletePeriod.Add((New-TimeSpan -Days -1))
        $hotCachePeriodInDaysUpdated = $databaseItem.HotCachePeriod.Add((New-TimeSpan -Days -1))

        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $databaseUpdatedWithParameters = Update-AzKustoDatabase -InputObject $database -Location $env.location -Kind "ReadWrite" -SoftDeletePeriod $softDeletePeriodInDaysUpdated -HotCachePeriod $hotCachePeriodInDaysUpdated
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location $env.databaseType $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }

    It 'UpdateViaIdentityExpandedReadOnlyFollowing' {
        $clusterName = $env.followerClusterName
        $resourceGroupName = $env.resourceGroupName
        $databaseName = $env.databaseName
        $databaseFullName = $clusterName + "/" + $databaseName

        $databaseItem = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $softDeletePeriodInDaysUpdated = $databaseItem.SoftDeletePeriod
        $hotCachePeriodInDaysUpdated = $databaseItem.HotCachePeriod.Add((New-TimeSpan -Days -1))

        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $databaseUpdatedWithParameters = Update-AzKustoDatabase -InputObject $database -Location $env.location -Kind "ReadOnlyFollowing" -HotCachePeriod $hotCachePeriodInDaysUpdated
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location $env.databaseType $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }
}
