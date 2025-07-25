Describe 'Update-AzSynapseKustoPoolDataConnection' {
    BeforeAll{
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSynapseKustoPoolDataConnection.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'UpdateExpandedEventHub' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName
        $eventhubNS = $env.eventhubNS
        $eventhub = $env.eventhub
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $kind = "EventHub"
        $dataConnectionFullName = "$workspaceName/$kustoPoolName/$databaseName/$dataConnectionName"

        New-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "None"
        $dataConnectionUpdated = Update-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "GZip"
        
        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
		$dataConnectionUpdated.Location | Should -Be $location
		$dataConnectionUpdated.EventHubResourceId | Should -Be $eventHubResourceId
		$dataConnectionUpdated.Kind | Should -Be $kind
        $dataConnectionUpdated.Compression | Should -Be "GZip"
        Remove-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'UpdateExpandedEventGrid' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName
        $eventhubNS = $env.eventhubNS
        $eventhub = $env.eventgrid
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $storageAccountName = $env.storageName
        $storageAccountResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Storage/storageAccounts/$storageAccountName"
        $kind = "EventGrid"
        $dataConnectionFullName = "$workspaceName/$kustoPoolName/$databaseName/$dataConnectionName"

        New-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup '$Default'
        $dataConnectionUpdated = Update-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup '$Default'
        
        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
		$dataConnectionUpdated.Location | Should -Be $location
		$dataConnectionUpdated.EventHubResourceId | Should -Be $eventHubResourceId
		$dataConnectionUpdated.StorageAccountResourceId | Should -Be $storageAccountResourceId
		$dataConnectionUpdated.Kind | Should -Be $kind
        Remove-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'UpdateExpandedIotHub' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName
        $iothubName = $env.iothub
        $iotHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Devices/IotHubs/$iothubName"
        $sharedAccessPolicyName = $env.iothubSharedAccessPolicyName
        $kind = "IotHub"
        $dataConnectionFullName = "$workspaceName/$kustoPoolName/$databaseName/$dataConnectionName"

        New-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -ConsumerGroup '$Default'
        $dataConnectionUpdated = Update-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName "registryReadWrite" -ConsumerGroup '$Default'
        
        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
		$dataConnectionUpdated.Location | Should -Be $location
		$dataConnectionUpdated.IotHubResourceId | Should -Be $iotHubResourceId
		$dataConnectionUpdated.SharedAccessPolicyName | Should -Be "registryReadWrite"
		$dataConnectionUpdated.Kind | Should -Be $kind
        Remove-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'UpdateViaIdentityExpandedEventHub' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName
        $eventhubNS = $env.eventhubNS
        $eventhub = $env.eventhub
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $kind = "EventHub"
        $dataConnectionFullName = "$workspaceName/$kustoPoolName/$databaseName/$dataConnectionName"

        New-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "None"
        $dataConnection = Get-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -Name $dataConnectionName
        $dataConnectionUpdated = Update-AzSynapseKustoPoolDataConnection -InputObject $dataConnection -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "Gzip"
        
        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
		$dataConnectionUpdated.Location | Should -Be $location
		$dataConnectionUpdated.EventHubResourceId | Should -Be $eventHubResourceId
		$dataConnectionUpdated.Kind | Should -Be $kind
        $dataConnectionUpdated.Compression | Should -Be "GZip"
        Remove-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'UpdateViaIdentityExpandedEventGrid' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName
        $eventhubNS = $env.eventhubNS
        $eventhub = $env.eventgrid
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $storageAccountName = $env.storageName
        $storageAccountResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Storage/storageAccounts/$storageAccountName"
        $kind = "EventGrid"
        $dataConnectionFullName = "$workspaceName/$kustoPoolName/$databaseName/$dataConnectionName"

        New-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup '$Default'
        $dataConnection = Get-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -Name $dataConnectionName
        $dataConnectionUpdated = Update-AzSynapseKustoPoolDataConnection -InputObject $dataConnection -location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup '$Default'
        
        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
		$dataConnectionUpdated.Location | Should -Be $location
		$dataConnectionUpdated.EventHubResourceId | Should -Be $eventHubResourceId
		$dataConnectionUpdated.StorageAccountResourceId | Should -Be $storageAccountResourceId
		$dataConnectionUpdated.Kind | Should -Be $kind
        Remove-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'UpdateViaIdentityExpandedIotHub' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName
        $iothubName = $env.iothub
        $iotHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Devices/IotHubs/$iothubName"
        $sharedAccessPolicyName = $env.iothubSharedAccessPolicyName
        $kind = "IotHub"
        $dataConnectionFullName = "$workspaceName/$kustoPoolName/$databaseName/$dataConnectionName"

        New-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -ConsumerGroup '$Default'
        $dataConnection = Get-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -Name $dataConnectionName
        $dataConnectionUpdated = Update-AzSynapseKustoPoolDataConnection -InputObject $dataConnection -location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName "registryReadWrite" -ConsumerGroup '$Default'
        
        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
		$dataConnectionUpdated.Location | Should -Be $location
		$dataConnectionUpdated.IotHubResourceId | Should -Be $iotHubResourceId
		$dataConnectionUpdated.SharedAccessPolicyName | Should -Be "registryReadWrite"
		$dataConnectionUpdated.Kind | Should -Be $kind
        Remove-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }
}
