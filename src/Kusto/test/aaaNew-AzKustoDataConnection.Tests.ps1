$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoDataConnection.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzKustoDataConnection' {
    It 'CreateExpandedEventHub' {
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

        $dataConnectionCreated = New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "None"
        Validate_EventHubDataConnection $dataConnectionCreated $dataConnectionFullName $location $eventHubResourceId $kind
    }

    It 'CreateExpandedEventGrid' {
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

        $dataConnectionCreated = New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup '$Default'
        Validate_EventGridDataConnection $dataConnectionCreated $dataConnectionFullName $location $eventHubResourceId $storageAccountResourceId $kind
    }

    It 'CreateExpandedIotHub' {
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

        $dataConnectionCreated = New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -ConsumerGroup '$Default'
        Validate_IotHubDataConnection $dataConnectionCreated $dataConnectionFullName $location $iotHubResourceId $sharedAccessPolicyName $kind
    }
}
