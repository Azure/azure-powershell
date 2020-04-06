$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzKustoDataConnectionValidation.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzKustoDataConnectionValidation' {
    It 'Data' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName + "a"
        $eventhubNS= $env.eventhubNSName
        $eventhub= $env.eventhubName
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $tableName = $env.tableName
        $tableMappingName = $env.tableMappingName
        $dataFormat = $env.dataFormat
        $kind = "EventHub"

        $dataConnectionProperties = New-Object -Type Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.EventHubDataConnection -Property @{Location=$location; Kind=$kind; EventHubResourceId=$eventHubResourceId; DataFormat=$dataFormat; ConsumerGroup='$Default'; Compression= "None"; TableName = $tableName; MappingRuleName = $tableMappingName}
        $dataConnectionValidation = New-Object -Type Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.DataConnectionValidation -Property @{DataConnectionName=$dataConnectionName; Property=$dataConnectionProperties}
        $validationResult = Invoke-AzKustoDataConnectionValidation -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -Parameter $dataConnectionValidation
        $validationResult.errorMessage | Should Be "event hub resource id and consumer group tuple provided are already used"
    }

    It 'DataViaIdentity' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName + "a"
        $eventhubNS= $env.eventhubNSName
        $eventhub= $env.eventhubName
        $eventHubResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$eventhubNS/eventhubs/$eventhub"
        $tableName = $env.tableName
        $tableMappingName = $env.tableMappingName
        $dataFormat = $env.dataFormat
        $kind = "EventHub"

        $dataConnectionProperties = New-Object -Type Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.EventHubDataConnection -Property @{Location=$location; Kind=$kind; EventHubResourceId=$eventHubResourceId; DataFormat=$dataFormat; ConsumerGroup='$Default'; Compression= "None"; TableName = $tableName; MappingRuleName = $tableMappingName}
        $dataConnectionValidation = New-Object -Type Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.DataConnectionValidation -Property @{DataConnectionName=$dataConnectionName; Property=$dataConnectionProperties}
        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $validationResult = Invoke-AzKustoDataConnectionValidation -InputObject $database -Parameter $dataConnectionValidation
        $validationResult.errorMessage | Should Be "event hub resource id and consumer group tuple provided are already used"
    }
}
