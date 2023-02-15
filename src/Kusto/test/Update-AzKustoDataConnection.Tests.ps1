Describe 'Update-AzKustoDataConnection' {
    BeforeAll{
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzKustoDataConnection.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'UpdateExpandedEventHub' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.locationfordc
        $resourceGroupName = $env.resourceGroupNamefordc
        $clusterName = $env.clusterNamefordc
        $databaseName = $env.databaseNamefordc
        $dataConnectionName = $env.dataConnectionName
        $eventhubNS = $env.eventhubNSNamefordc
        $eventhub = $env.eventhubNamefordc
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $kind = "EventHub"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        $dataConnectionUpdated = Update-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup 'Default' -Compression "None"
        
        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
		$dataConnectionUpdated.Location | Should -Be $location
		$dataConnectionUpdated.EventHubResourceId | Should -Be $eventHubResourceId
		$dataConnectionUpdated.Kind | Should -Be $kind
    }

    It 'UpdateExpandedEventGrid' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.locationfordc
        $resourceGroupName = $env.resourceGroupNamefordc
        $clusterName = $env.clusterNamefordc
        $databaseName = $env.databaseNamefordc
        $dataConnectionName = $env.dataConnectionName + "g"
        $eventhubNS = $env.eventhubNSNameForEventGridfordc
        $eventhub = $env.eventhubNameForEventGridfordc
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $storageAccountName = $env.storageNamefordc
        $storageAccountResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Storage/storageAccounts/$storageAccountName"
        $kind = "EventGrid"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        $dataConnectionUpdated = Update-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup 'Default'
        
        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
		$dataConnectionUpdated.Location | Should -Be $location
		$dataConnectionUpdated.EventHubResourceId | Should -Be $eventHubResourceId
		$dataConnectionUpdated.StorageAccountResourceId | Should -Be $storageAccountResourceId
		$dataConnectionUpdated.Kind | Should -Be $kind
    }

    It 'UpdateExpandedIotHub' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.locationfordc
        $resourceGroupName = $env.resourceGroupNamefordc
        $clusterName = $env.clusterNamefordc
        $databaseName = $env.databaseNamefordc
        $dataConnectionName = $env.dataConnectionName + "h"
        $iothubName = $env.iothubNamefordc
        $iotHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Devices/IotHubs/$iothubName"
        $sharedAccessPolicyName = $env.iothubSharedAccessPolicyName
        $kind = "IotHub"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        $dataConnectionUpdated = Update-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -ConsumerGroup 'Default'
        
        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
		$dataConnectionUpdated.Location | Should -Be $location
		$dataConnectionUpdated.IotHubResourceId | Should -Be $iotHubResourceId
		$dataConnectionUpdated.SharedAccessPolicyName | Should -Be $sharedAccessPolicyName
		$dataConnectionUpdated.Kind | Should -Be $kind
    }

    It 'UpdateViaIdentityExpandedEventHub' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.locationfordc
        $resourceGroupName = $env.resourceGroupNamefordc
        $clusterName = $env.clusterNamefordc
        $databaseName = $env.databaseNamefordc
        $dataConnectionName = $env.dataConnectionName
        $eventhubNS = $env.eventhubNSNamefordc
        $eventhub = $env.eventhubNamefordc
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $kind = "EventHub"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        $dataConnection = Get-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -Name $dataConnectionName
        $dataConnectionUpdated = Update-AzKustoDataConnection -InputObject $dataConnection -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup 'Default' -Compression "None"
        
        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
        $dataConnectionUpdated.Location | Should -Be $location
        $dataConnectionUpdated.EventHubResourceId | Should -Be $eventHubResourceId
        $dataConnectionUpdated.Kind | Should -Be $kind
    }

    It 'UpdateViaIdentityExpandedEventGrid' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.locationfordc
        $resourceGroupName = $env.resourceGroupNamefordc
        $clusterName = $env.clusterNamefordc
        $databaseName = $env.databaseNamefordc
        $dataConnectionName = $env.dataConnectionName + "g"
        $eventhubNS = $env.eventhubNSNameForEventGridfordc
        $eventhub = $env.eventhubNameForEventGridfordc
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $storageAccountName = $env.storageNamefordc
        $storageAccountResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Storage/storageAccounts/$storageAccountName"
        $kind = "EventGrid"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        $dataConnection = Get-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -Name $dataConnectionName
        $dataConnectionUpdated = Update-AzKustoDataConnection -InputObject $dataConnection -location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup 'Default'
        
        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
        $dataConnectionUpdated.Location | Should -Be $location
        $dataConnectionUpdated.EventHubResourceId | Should -Be $eventHubResourceId
        $dataConnectionUpdated.StorageAccountResourceId | Should -Be $storageAccountResourceId
        $dataConnectionUpdated.Kind | Should -Be $kind
    }

    It 'UpdateViaIdentityExpandedIotHub' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.locationfordc
        $resourceGroupName = $env.resourceGroupNamefordc
        $clusterName = $env.clusterNamefordc
        $databaseName = $env.databaseNamefordc
        $dataConnectionName = $env.dataConnectionName + "h"
        $iothubName = $env.iothubNamefordc
        $iotHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Devices/IotHubs/$iothubName"
        $sharedAccessPolicyName = $env.iothubSharedAccessPolicyName
        $kind = "IotHub"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        $dataConnection = Get-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -Name $dataConnectionName
        $dataConnectionUpdated = Update-AzKustoDataConnection -InputObject $dataConnection -location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -ConsumerGroup 'Default'
        
        # Validate
        $dataConnectionUpdated.Name | Should -Be $dataConnectionFullName
		$dataConnectionUpdated.Location | Should -Be $location
		$dataConnectionUpdated.IotHubResourceId | Should -Be $iotHubResourceId
		$dataConnectionUpdated.SharedAccessPolicyName | Should -Be $sharedAccessPolicyName
		$dataConnectionUpdated.Kind | Should -Be $kind
    }
}
