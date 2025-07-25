Describe 'Update-AzKustoDatabase' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzKustoDatabase.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
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
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $attachedDatabaseConfigurationName = "testdbconf" + $env.rstr4
        $followerClusterName = $env.kustoFollowerClusterName
        $DefaultPrincipalsModificationKind = "Union"
        $clusterResourceId = $env.kustoClusterResourceId
        $followerClusterResourceId = $env.kustoFollowerClusterResourceId
        $databaseFullName = $followerClusterName + "/" + $databaseName

        New-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName -Location $location -ClusterResourceId $clusterResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $DefaultPrincipalsModificationKind
        $databaseItem = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $databaseName

        $softDeletePeriodInDaysUpdated = $databaseItem.SoftDeletePeriod
        $hotCachePeriodInDaysUpdated = $databaseItem.HotCachePeriod.Add((New-TimeSpan -Days 1))
        $databaseUpdatedWithParameters = Update-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $databaseName -Location $env.location -Kind "ReadOnlyFollowing" -HotCachePeriod $hotCachePeriodInDaysUpdated

        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location "Microsoft.Kusto/Clusters/Databases" $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated

        { Invoke-AzKustoDetachClusterFollowerDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -AttachedDatabaseConfigurationName $attachedDatabaseConfigurationName -ClusterResourceId $followerClusterResourceId } | Should -Not -Throw
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
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $attachedDatabaseConfigurationName = "testdbconf" + $env.rstr4
        $followerClusterName = $env.kustoFollowerClusterName
        $DefaultPrincipalsModificationKind = "Union"
        $clusterResourceId = $env.kustoClusterResourceId
        $followerClusterResourceId = $env.kustoFollowerClusterResourceId
        $databaseFullName = $followerClusterName + "/" + $databaseName

        New-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName -Location $location -ClusterResourceId $clusterResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $DefaultPrincipalsModificationKind
        $databaseItem = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $databaseName

        $softDeletePeriodInDaysUpdated = $databaseItem.SoftDeletePeriod
        $hotCachePeriodInDaysUpdated = $databaseItem.HotCachePeriod.Add((New-TimeSpan -Days -1))
        $databaseUpdatedWithParameters = Update-AzKustoDatabase -InputObject $databaseItem -Location $env.location -Kind "ReadOnlyFollowing" -HotCachePeriod $hotCachePeriodInDaysUpdated

        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location "Microsoft.Kusto/Clusters/Databases" $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated

        { Invoke-AzKustoDetachClusterFollowerDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -AttachedDatabaseConfigurationName $attachedDatabaseConfigurationName -ClusterResourceId $followerClusterResourceId } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpandedCMK' {
        $clusterName = $env.kustoClusterName
        $resourceGroupName = $env.resourceGroupName
        $databaseName = "testcmkdatabase" + $env.rstr6
        $databaseFullName = $clusterName + "/" + $databaseName

        $keyVaultPropertyKeyName = $env.keyName
        $keyVaultPropertyKeyVaultUri = $env.keyVaultUrl
        $keyVaultPropertyKeyVersion = $env.keyVersion
        $keyVaultPropertyUserIdentity = $env.userAssignedManagedIdentityResourceId

        New-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $databaseName -Location $env.location -Kind ReadWrite -KeyVaultPropertyKeyName $keyVaultPropertyKeyName -KeyVaultPropertyKeyVaultUri $keyVaultPropertyKeyVaultUri -KeyVaultPropertyKeyVersion $keyVaultPropertyKeyVersion -KeyVaultPropertyUserIdentity $keyVaultPropertyUserIdentity
        
        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        
        $softDeletePeriodInDaysUpdated = (New-TimeSpan -Days 5)
        $hotCachePeriodInDaysUpdated = (New-TimeSpan -Days 10)
        
        $databaseUpdatedWithParameters = Update-AzKustoDatabase -InputObject $database -Location $env.location -Kind "ReadWrite" -KeyVaultPropertyKeyName $keyVaultPropertyKeyName -KeyVaultPropertyKeyVaultUri $keyVaultPropertyKeyVaultUri -KeyVaultPropertyKeyVersion $keyVaultPropertyKeyVersion -KeyVaultPropertyUserIdentity $keyVaultPropertyUserIdentity -SoftDeletePeriod $softDeletePeriodInDaysUpdated -HotCachePeriod $hotCachePeriodInDaysUpdated

        Validate_CMKDatabase $databaseUpdatedWithParameters $databaseFullName $env.location "Microsoft.Kusto/Clusters/Databases" $keyVaultPropertyKeyName $keyVaultPropertyKeyVaultUri $keyVaultPropertyKeyVersion $keyVaultPropertyUserIdentity $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated

        { Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $databaseName } | Should -Not -Throw
    }
}
