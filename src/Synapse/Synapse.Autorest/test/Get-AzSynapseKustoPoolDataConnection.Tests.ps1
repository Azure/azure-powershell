Describe 'Get-AzSynapseKustoPoolDataConnection' {
    BeforeAll {
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSynapseKustoPoolDataConnection.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'List' {
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
        [array]$dataConnectionGet = Get-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName
        $dataConnectionGet.Count | Should -Be 1
        Validate_EventHubDataConnection $dataConnectionGet[0] $dataConnectionFullName $location $eventHubResourceId $kind
        Remove-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'Get' {
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
        $dataConnectionGet = Get-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
        Validate_EventHubDataConnection $dataConnectionGet $dataConnectionFullName $location $eventHubResourceId $kind
        Remove-AzSynapseKustoPoolDataConnection -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }
}
