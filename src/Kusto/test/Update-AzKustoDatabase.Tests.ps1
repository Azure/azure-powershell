Describe 'Update-AzKustoDatabase' {
    BeforeAll{
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
    }
    It 'UpdateExpandedReadWrite' {
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $resourceGroupName = $env.resourceGroupName
        $databaseFullName = $clusterName + "/" + $databaseName

        $databaseItem = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $softDeletePeriodInDaysUpdated = $databaseItem.SoftDeletePeriod.Add((New-TimeSpan -Days 1))
        $hotCachePeriodInDaysUpdated = $databaseItem.HotCachePeriod.Add((New-TimeSpan -Days 1))

        $databaseUpdatedWithParameters = Update-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Location $env.location -Kind "ReadWrite" -SoftDeletePeriod $softDeletePeriodInDaysUpdated -HotCachePeriod $hotCachePeriodInDaysUpdated
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location "Microsoft.Kusto/Clusters/Databases" $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }

    It 'UpdateExpandedReadOnlyFollowing' {
        $clusterName = $env.kustoFollowerClusterName
        $resourceGroupName = $env.resourceGroupName
        $databaseName = $env.kustoDatabaseName
        $databaseFullName = $clusterName + "/" + $databaseName

        $databaseItem = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $softDeletePeriodInDaysUpdated = $databaseItem.SoftDeletePeriod
        $hotCachePeriodInDaysUpdated = $databaseItem.HotCachePeriod.Add((New-TimeSpan -Days 1))

        $databaseUpdatedWithParameters = Update-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Location $env.location -Kind "ReadOnlyFollowing" -HotCachePeriod $hotCachePeriodInDaysUpdated
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location "Microsoft.Kusto/Clusters/Databases" $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }

    It 'UpdateViaIdentityExpandedReadWrite' {
        $clusterName = $env.kustoClusterName
        $resourceGroupName = $env.resourceGroupName
        $databaseName = $env.kustoDatabaseName
        $databaseFullName = $clusterName + "/" + $databaseName

        $databaseItem = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $softDeletePeriodInDaysUpdated = $databaseItem.SoftDeletePeriod.Add((New-TimeSpan -Days -1))
        $hotCachePeriodInDaysUpdated = $databaseItem.HotCachePeriod.Add((New-TimeSpan -Days -1))

        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $databaseUpdatedWithParameters = Update-AzKustoDatabase -InputObject $database -Location $env.location -Kind "ReadWrite" -SoftDeletePeriod $softDeletePeriodInDaysUpdated -HotCachePeriod $hotCachePeriodInDaysUpdated
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location "Microsoft.Kusto/Clusters/Databases" $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }

    It 'UpdateViaIdentityExpandedReadOnlyFollowing' {
        $clusterName = $env.kustoFollowerClusterName
        $resourceGroupName = $env.resourceGroupName
        $databaseName = $env.kustoDatabaseName
        $databaseFullName = $clusterName + "/" + $databaseName

        $databaseItem = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $softDeletePeriodInDaysUpdated = $databaseItem.SoftDeletePeriod
        $hotCachePeriodInDaysUpdated = $databaseItem.HotCachePeriod.Add((New-TimeSpan -Days -1))

        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $databaseUpdatedWithParameters = Update-AzKustoDatabase -InputObject $database -Location $env.location -Kind "ReadOnlyFollowing" -HotCachePeriod $hotCachePeriodInDaysUpdated
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location "Microsoft.Kusto/Clusters/Databases" $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }
}
