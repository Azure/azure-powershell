$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoDataConnection.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzKustoDataConnection' {
    It 'List' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName
        $eventhubNS= $env.eventhubNSName
        $eventhub= $env.eventhubName
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $tableName = $env.tableName
        $tableMappingName = $env.tableMappingName
        $dataFormat = $env.dataFormat
        $kind = "EventHub"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        [array]$dataConnectionGet = Get-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
        $dataConnectionCreated = $dataConnectionGet[0]
        Validate_EventHubDataConnection $dataConnectionCreated $dataConnectionFullName $location $eventHubResourceId $tableName $tableMappingName $dataFormat $kind
    }

    It 'Get' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName
        $eventhubNS= $env.eventhubNSName
        $eventhub= $env.eventhubName
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $tableName = $env.tableName
        $tableMappingName = $env.tableMappingName
        $dataFormat = $env.dataFormat
        $kind = "EventHub"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        $dataConnectionCreated = Get-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
        Validate_EventHubDataConnection $dataConnectionCreated $dataConnectionFullName $location $eventHubResourceId $tableName $tableMappingName $dataFormat $kind
    }
}
