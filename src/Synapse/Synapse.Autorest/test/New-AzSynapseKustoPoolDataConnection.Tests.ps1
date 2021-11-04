Describe 'New-AzSynapseKustoPoolDataConnection' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSynapseKustoPoolDataConnection.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
    . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'CreateExpandedEventHub' {
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

        $dataConnectionCreated = New-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "None"
        Validate_EventHubDataConnection $dataConnectionCreated $dataConnectionFullName $location $eventHubResourceId $kind
        Remove-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'CreateExpandedEventGrid' {
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

        $dataConnectionCreated = New-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup '$Default'
        Validate_EventGridDataConnection $dataConnectionCreated $dataConnectionFullName $location $eventHubResourceId $storageAccountResourceId $kind
        Remove-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'CreateExpandedIotHub' {
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

        $dataConnectionCreated = New-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -ConsumerGroup '$Default'
        Validate_IotHubDataConnection $dataConnectionCreated $dataConnectionFullName $location $iotHubResourceId $sharedAccessPolicyName $kind
        Remove-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }
}
