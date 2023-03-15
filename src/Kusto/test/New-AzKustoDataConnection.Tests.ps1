Describe 'New-AzKustoDataConnection' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoDataConnection.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'CreateExpandedEventHub' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "event-hub-dc"
        $eventHubResourceId = $env.eventHubResourceId
        $kind = "EventHub"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        $dataConnectionCreated = New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "None"
        $databaseRouting = "Single"
        Validate_EventHubDataConnection $dataConnectionCreated $dataConnectionFullName $location $eventHubResourceId $kind $databaseRouting

        Remove-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'CreateExpandedEventGrid' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "event-grid-dc"
        $eventHubResourceId = $env.eventHubResourceId
        $storageAccountResourceId = $env.storageAccountResourceId
        $kind = "EventGrid"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        $dataConnectionCreated = New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup '$Default'
        $databaseRouting = "Single"
        Validate_EventGridDataConnection $dataConnectionCreated $dataConnectionFullName $location $eventHubResourceId $storageAccountResourceId $kind $databaseRouting

        Remove-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'CreateExpandedIotHub' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "iot-hub-dc"
        $iotHubResourceId = $env.iotHubResourceId
        $sharedAccessPolicyName = "registryRead"
        $kind = "IotHub"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        $dataConnectionCreated = New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -ConsumerGroup '$Default'
        $databaseRouting = "Single"
        Validate_IotHubDataConnection $dataConnectionCreated $dataConnectionFullName $location $iotHubResourceId $sharedAccessPolicyName $kind $databaseRouting

        Remove-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }
}
