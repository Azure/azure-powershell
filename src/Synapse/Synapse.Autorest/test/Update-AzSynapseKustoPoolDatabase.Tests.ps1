Describe 'Update-AzSynapseKustoPoolDatabase' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSynapseKustoPoolDatabase.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'UpdateExpandedReadWrite' {
        $kustoPoolName = $env.kustoPoolName
        $databaseName = $env.databaseName
        $workspaceName = $env.workspaceName
        $resourceGroupName = $env.resourceGroupName
        $databaseFullName = $workspaceName + "/" + $kustoPoolName + "/" + $databaseName

        $databaseItem = Get-AzSynapseKustoPoolDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -Name $databaseName
        $softDeletePeriodInDaysUpdated = $databaseItem.SoftDeletePeriod.Add((New-TimeSpan -Days 1))
        $hotCachePeriodInDaysUpdated = $databaseItem.HotCachePeriod.Add((New-TimeSpan -Days 1))

        $databaseUpdatedWithParameters = Update-AzSynapseKustoPoolDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -Name $databaseName -Location $env.location -Kind "ReadWrite" -SoftDeletePeriod $softDeletePeriodInDaysUpdated -HotCachePeriod $hotCachePeriodInDaysUpdated
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location $env.databaseType $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }

    It 'UpdateViaIdentityExpandedReadWrite' {
        $kustoPoolName = $env.kustoPoolName
        $databaseName = $env.databaseName
        $workspaceName = $env.workspaceName
        $resourceGroupName = $env.resourceGroupName
        $databaseFullName = $workspaceName + "/" + $kustoPoolName + "/" + $databaseName

        $databaseItem = Get-AzSynapseKustoPoolDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -Name $databaseName
        $softDeletePeriodInDaysUpdated = $databaseItem.SoftDeletePeriod.Add((New-TimeSpan -Days -1))
        $hotCachePeriodInDaysUpdated = $databaseItem.HotCachePeriod.Add((New-TimeSpan -Days -1))

        $database = Get-AzSynapseKustoPoolDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -Name $databaseName
        $databaseUpdatedWithParameters = Update-AzSynapseKustoPoolDatabase -InputObject $database -Location $env.location -Kind "ReadWrite" -SoftDeletePeriod $softDeletePeriodInDaysUpdated -HotCachePeriod $hotCachePeriodInDaysUpdated
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location $env.databaseType $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }
}
