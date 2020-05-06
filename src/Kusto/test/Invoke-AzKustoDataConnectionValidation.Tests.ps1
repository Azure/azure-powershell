$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzKustoDataConnectionValidation.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzKustoDataConnectionValidation' {
    It 'DataExpandedEventHub' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName + $env.rstr4
        $eventhubNS = $env.eventhubNSName
        $eventhub = $env.eventhubName
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $tableName = $env.tableName
        $tableMappingName = $env.tableMappingName
        $dataFormat = $env.dataFormat
        $kind = "EventHub"

        $validationResult = Invoke-AzKustoDataConnectionValidation -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -DataFormat $dataFormat -ConsumerGroup '$Default' -Compression "None" -TableName $tableName -MappingRuleName $tableMappingName
        $validationResult.errorMessage | Should Be "event hub resource id and consumer group tuple provided are already used"
    }

    It 'DataExpandedEventGrid' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName + $env.rstr5
        $eventhubNS = $env.eventhubNSNameForEventGrid
        $eventhub = $env.eventhubNameForEventGrid
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $storageAccountName = $env.storageName
        $storageAccountResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Storage/storageAccounts/$storageAccountName"
        $tableName = $env.tableName
        $tableMappingName = $env.tableMappingName
        $dataFormat = $env.dataFormat
        $kind = "EventGrid"

        $validationResult = Invoke-AzKustoDataConnectionValidation -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -DataFormat $dataFormat -ConsumerGroup '$Default' -TableName $tableName -MappingRuleName $tableMappingName
        $validationResult.errorMessage | Should Be "event hub resource id and consumer group tuple provided are already used"
    }

    It 'DataExpandedIotHub' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName + $env.rstr6
        $iothubName = $env.iothubName
        $iotHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Devices/IotHubs/$iothubName"
        $sharedAccessPolicyName = $env.iothubSharedAccessPolicyName
        $tableName = $env.tableName
        $tableMappingName = $env.tableMappingName
        $dataFormat = $env.dataFormat
        $kind = "IotHub"

        $validationResult = Invoke-AzKustoDataConnectionValidation -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -DataFormat $dataFormat -ConsumerGroup '$Default' -TableName $tableName -MappingRuleName $tableMappingName
        $validationResult.errorMessage | Should Be "event hub resource id and consumer group tuple provided are already used"
    }

    It 'DataViaIdentityExpandedEventHub' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName + $env.rstr4
        $eventhubNS = $env.eventhubNSName
        $eventhub = $env.eventhubName
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $tableName = $env.tableName
        $tableMappingName = $env.tableMappingName
        $dataFormat = $env.dataFormat
        $kind = "EventHub"

        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $validationResult = Invoke-AzKustoDataConnectionValidation -InputObject $database -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -DataFormat $dataFormat -ConsumerGroup '$Default' -Compression "None" -TableName $tableName -MappingRuleName $tableMappingName
        $validationResult.errorMessage | Should Be "event hub resource id and consumer group tuple provided are already used"
    }

    It 'DataViaIdentityExpandedEventGrid' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName + $env.rstr5
        $eventhubNS = $env.eventhubNSNameForEventGrid
        $eventhub = $env.eventhubNameForEventGrid
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $storageAccountName = $env.storageName
        $storageAccountResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Storage/storageAccounts/$storageAccountName"
        $tableName = $env.tableName
        $tableMappingName = $env.tableMappingName
        $dataFormat = $env.dataFormat
        $kind = "EventGrid"

        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $validationResult = Invoke-AzKustoDataConnectionValidation -InputObject $database -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -DataFormat $dataFormat -ConsumerGroup '$Default' -TableName $tableName -MappingRuleName $tableMappingName
        $validationResult.errorMessage | Should Be "event hub resource id and consumer group tuple provided are already used"
    }

    It 'DataViaIdentityExpandedIotHub' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName + $env.rstr6
        $iothubName = $env.iothubName
        $iotHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Devices/IotHubs/$iothubName"
        $sharedAccessPolicyName = $env.iothubSharedAccessPolicyName
        $tableName = $env.tableName
        $tableMappingName = $env.tableMappingName
        $dataFormat = $env.dataFormat
        $kind = "IotHub"

        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $validationResult = Invoke-AzKustoDataConnectionValidation -InputObject $database -DataConnectionName $dataConnectionName -Location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -DataFormat $dataFormat -ConsumerGroup '$Default' -TableName $tableName -MappingRuleName $tableMappingName
        $validationResult.errorMessage | Should Be "event hub resource id and consumer group tuple provided are already used"
    }
}
