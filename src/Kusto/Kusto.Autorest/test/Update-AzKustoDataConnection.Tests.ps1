Describe 'Update-AzKustoDataConnection' {
    BeforeAll{
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzKustoDataConnection.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'UpdateExpandedEventHub' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "event-hub-dc"
        $eventHubResourceId = $env.eventHubResourceId
        $kind = "EventHub"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "None"
        $dataConnectionUpdated = Update-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "None" -DatabaseRouting "Multi"

        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
        $dataConnectionUpdated.Location | Should -Be $location
        $dataConnectionUpdated.EventHubResourceId | Should -Be $eventHubResourceId
        $dataConnectionUpdated.Kind | Should -Be $kind

        Remove-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'UpdateExpandedEventGrid' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "event-grid-dc"
        $eventHubResourceId = $env.eventHubResourceId
        $storageAccountName = $env.storageAccountResourceId
        $storageAccountResourceId = $env.storageAccountResourceId
        $kind = "EventGrid"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup '$Default'
        $dataConnectionUpdated = Update-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup '$Default'

        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
        $dataConnectionUpdated.Location | Should -Be $location
        $dataConnectionUpdated.EventHubResourceId | Should -Be $eventHubResourceId
        $dataConnectionUpdated.StorageAccountResourceId | Should -Be $storageAccountResourceId
        $dataConnectionUpdated.Kind | Should -Be $kind

        Remove-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'UpdateExpandedIotHub' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "iot-hub-dc"
        $iotHubResourceId = $env.iotHubResourceId
        $sharedAccessPolicyName = "registryRead"
        $kind = "IotHub"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -ConsumerGroup '$Default'
        $dataConnectionUpdated = Update-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -ConsumerGroup '$Default'

        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
        $dataConnectionUpdated.Location | Should -Be $location
        $dataConnectionUpdated.IotHubResourceId | Should -Be $iotHubResourceId
        $dataConnectionUpdated.SharedAccessPolicyName | Should -Be $sharedAccessPolicyName
        $dataConnectionUpdated.Kind | Should -Be $kind

        Remove-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'UpdateExpandedCosmosDb' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $tableName = $env.kustoTableName
        $dataConnectionName = "cosmos-db-dc"
        $cosmosDbAccountResourceId = $env.cosmosDbResourceId
        $cosmosDbDatabaseName = $env.cosmosDbDatabaseName
        $cosmosDbContainerName = $env.cosmosDbContainerName
        $managedIdentityResourceId = $env.kustoClusterResourceId
        $kind = "CosmosDb"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -TableName $tableName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -CosmosDbAccountResourceId $cosmosDbAccountResourceId -CosmosDbDatabase $cosmosDbDatabaseName -CosmosDbContainer $cosmosDbContainerName -ManagedIdentityResourceId $managedIdentityResourceId
        $dataConnectionUpdated = Update-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -TableName $tableName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -CosmosDbAccountResourceId $cosmosDbAccountResourceId -CosmosDbDatabase $cosmosDbDatabaseName -CosmosDbContainer $cosmosDbContainerName -ManagedIdentityResourceId $managedIdentityResourceId

        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
        $dataConnectionUpdated.Location | Should -Be $location
        $dataConnectionUpdated.Kind | Should -Be $kind

        Remove-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'UpdateViaIdentityExpandedEventHub' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "event-hub-dc"
        $eventHubResourceId = $env.eventHubResourceId
        $kind = "EventHub"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "None"
        $dataConnection = Get-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -Name $dataConnectionName
        $dataConnectionUpdated = Update-AzKustoDataConnection -InputObject $dataConnection -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "None"

        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
        $dataConnectionUpdated.Location | Should -Be $location
        $dataConnectionUpdated.EventHubResourceId | Should -Be $eventHubResourceId
        $dataConnectionUpdated.Kind | Should -Be $kind

        Remove-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'UpdateViaIdentityExpandedEventGrid' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "event-grid-dc"
        $eventHubResourceId = $env.eventHubResourceId
        $storageAccountName = $env.storageAccountResourceId
        $storageAccountResourceId = $env.storageAccountResourceId
        $kind = "EventGrid"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup '$Default'
        $dataConnection = Get-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -Name $dataConnectionName
        $dataConnectionUpdated = Update-AzKustoDataConnection -InputObject $dataConnection -location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup '$Default'

        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
        $dataConnectionUpdated.Location | Should -Be $location
        $dataConnectionUpdated.EventHubResourceId | Should -Be $eventHubResourceId
        $dataConnectionUpdated.StorageAccountResourceId | Should -Be $storageAccountResourceId
        $dataConnectionUpdated.Kind | Should -Be $kind

        Remove-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'UpdateViaIdentityExpandedIotHub' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "iot-hub-dc"
        $iotHubResourceId = $env.iotHubResourceId
        $sharedAccessPolicyName = "registryRead"
        $kind = "IotHub"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -ConsumerGroup '$Default'
        $dataConnection = Get-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -Name $dataConnectionName
        $dataConnectionUpdated = Update-AzKustoDataConnection -InputObject $dataConnection -location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -ConsumerGroup '$Default'

        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
        $dataConnectionUpdated.Location | Should -Be $location
        $dataConnectionUpdated.IotHubResourceId | Should -Be $iotHubResourceId
        $dataConnectionUpdated.SharedAccessPolicyName | Should -Be $sharedAccessPolicyName
        $dataConnectionUpdated.Kind | Should -Be $kind

        Remove-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'UpdateViaIdentityExpandedCosmosDb' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $tableName = $env.kustoTableName
        $dataConnectionName = "cosmos-db-dc"
        $cosmosDbAccountResourceId = $env.cosmosDbResourceId
        $cosmosDbDatabaseName = $env.cosmosDbDatabaseName
        $cosmosDbContainerName = $env.cosmosDbContainerName
        $managedIdentityResourceId = $env.kustoClusterResourceId
        $kind = "CosmosDb"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -TableName $tableName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -CosmosDbAccountResourceId $cosmosDbAccountResourceId -CosmosDbDatabase $cosmosDbDatabaseName -CosmosDbContainer $cosmosDbContainerName -ManagedIdentityResourceId $managedIdentityResourceId
        $dataConnection = Get-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -Name $dataConnectionName
        $dataConnectionUpdated = Update-AzKustoDataConnection -InputObject $dataConnection -CosmosDbAccountResourceId $cosmosDbAccountResourceId -CosmosDbContainer $cosmosDbContainerName -CosmosDbDatabase $cosmosDbDatabaseName -Kind $kind -Location $location -ManagedIdentityResourceId $managedIdentityResourceId -TableName $tableName

        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
        $dataConnectionUpdated.Location | Should -Be $location
        $dataConnectionUpdated.Kind | Should -Be $kind

        Remove-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }
}
