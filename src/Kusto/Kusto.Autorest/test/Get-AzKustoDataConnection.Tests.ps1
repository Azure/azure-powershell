Describe 'Get-AzKustoDataConnection' {
    BeforeAll {
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoDataConnection.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'List' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "event-hub-dc"
        $eventHubResourceId = $env.eventHubResourceId
        $kind = "EventHub"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "None"

        [array]$dataConnectionGet = Get-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName
        $dataConnectionGet.Count | Should -BeGreaterThan 0
        foreach ($dataConnection in $dataConnectionGet)
        {
            if ($dataConnection.Name -eq $dataConnectionFullName)
            {
                $dataConnectionCreated = $dataConnection
            }
        }
        $databaseRouting = "Single"
        Validate_EventHubDataConnection $dataConnectionCreated $dataConnectionFullName $location $eventHubResourceId $kind $databaseRouting

        Remove-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }

    It 'Get' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $dataConnectionName = "event-hub-dc"
        $eventHubResourceId = $env.eventHubResourceId
        $kind = "EventHub"
        $dataConnectionFullName = "$clusterName/$databaseName/$dataConnectionName"

        New-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName -Location $location -Kind $kind -EventHubResourceId $eventHubResourceId -ConsumerGroup '$Default' -Compression "None"

        $dataConnectionCreated = Get-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
        $databaseRouting = "Single"
        Validate_EventHubDataConnection $dataConnectionCreated $dataConnectionFullName $location $eventHubResourceId $kind $databaseRouting

        Remove-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -DataConnectionName $dataConnectionName
    }
}
