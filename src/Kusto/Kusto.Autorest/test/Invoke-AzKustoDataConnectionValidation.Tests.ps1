Describe 'Invoke-AzKustoDataConnectionValidation' {
    BeforeAll {
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzKustoDataConnectionValidation.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'DataExpandedEventHub' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "event-hub-dc"
        $eventHubResourceId = $env.eventHubResourceId
        $kind = "EventHub"

        { Invoke-AzKustoDataConnectionValidation -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "None" } | Should -Not -Throw
    }

    It 'DataExpandedEventGrid' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "event-grid-dc"
        $eventHubResourceId = $env.eventHubResourceId
        $storageAccountResourceId = $env.storageAccountResourceId
        $kind = "EventGrid"

        { Invoke-AzKustoDataConnectionValidation -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup '$Default' } | Should -Not -Throw
    }

    It 'DataExpandedIotHub' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "iot-hub-dc"
        $iotHubResourceId = $env.iotHubResourceId
        $sharedAccessPolicyName = "registryRead"
        $kind = "IotHub"

        { Invoke-AzKustoDataConnectionValidation -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -ConsumerGroup '$Default' } | Should -Not -Throw
    }

    It 'DataViaIdentityExpandedEventHub' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "event-hub-dc"
        $eventHubResourceId = $env.eventHubResourceId
        $kind = "EventHub"

        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        { Invoke-AzKustoDataConnectionValidation -InputObject $database -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "None" } | Should -Not -Throw
    }

    It 'DataViaIdentityExpandedEventGrid' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "event-grid-dc"
        $eventHubResourceId = $env.eventHubResourceId
        $storageAccountResourceId = $env.storageAccountResourceId
        $kind = "EventGrid"

        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        { Invoke-AzKustoDataConnectionValidation -InputObject $database -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -StorageAccountResourceId $storageAccountResourceId -ConsumerGroup '$Default' } | Should -Not -Throw
    }

    It 'DataViaIdentityExpandedIotHub' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "iot-hub-dc"
        $iotHubResourceId = $env.iotHubResourceId
        $sharedAccessPolicyName = "registryRead"
        $kind = "IotHub"

        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        { Invoke-AzKustoDataConnectionValidation -InputObject $database -DataConnectionName $dataConnectionName -Location $location -Kind $kind -IotHubResourceId $iotHubResourceId -SharedAccessPolicyName $sharedAccessPolicyName -ConsumerGroup '$Default' } | Should -Not -Throw
    }
}
