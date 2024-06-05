Describe 'Invoke-AzSynapseDetachKustoPoolFollowerDatabase' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzSynapseDetachKustoPoolFollowerDatabase.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'DetachExpanded' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName
        $attachedDatabaseConfigurationName = "testdbconf" + $env.rstr4
        $followerKustoPoolName = $env.followerKustoPoolName
        $kustoPoolResourceId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Synapse/workspaces/$workspaceName/kustoPools/$kustoPoolName"
        $followerClusterResourceId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Synapse/workspaces/$workspaceName/kustoPools/$followerKustoPoolName"
        $databaseName = "testdatabase" + $env.rstr4
        $defaultPrincipalsModificationKind = $env.defaultPrincipalsModificationKind

        New-AzSynapseKustoPoolDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -Name $databaseName -Kind ReadWrite -Location $location
        New-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $followerKustoPoolName -Name $attachedDatabaseConfigurationName -Location $location -KustoPoolResourceId $kustoPoolResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $defaultPrincipalsModificationKind
        Start-TestSleep -Seconds 180
        { Invoke-AzSynapseDetachKustoPoolFollowerDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -AttachedDatabaseConfigurationName $attachedDatabaseConfigurationName -KustoPoolResourceId $followerClusterResourceId } | Should -Not -Throw
        Remove-AzSynapseKustoPoolDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -Name $databaseName
    }

    It 'DetachViaIdentityExpanded' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName
        $attachedDatabaseConfigurationName = "testdbconf" + $env.rstr5
        $followerKustoPoolName = $env.followerKustoPoolName
        $kustoPoolResourceId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Synapse/workspaces/$workspaceName/kustoPools/$kustoPoolName"
        $followerClusterResourceId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Synapse/workspaces/$workspaceName/kustoPools/$followerKustoPoolName"
        $databaseName = "testdatabase" + $env.rstr5
        $defaultPrincipalsModificationKind = $env.defaultPrincipalsModificationKind

        New-AzSynapseKustoPoolDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -Name $databaseName -Kind ReadWrite -Location $location
        New-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $followerKustoPoolName -Name $attachedDatabaseConfigurationName -Location $location -KustoPoolResourceId $kustoPoolResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $defaultPrincipalsModificationKind
        $kustopool = Get-AzSynapseKustoPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $kustoPoolName
        { Invoke-AzSynapseDetachKustoPoolFollowerDatabase -InputObject $kustopool -AttachedDatabaseConfigurationName $attachedDatabaseConfigurationName -KustoPoolResourceId $followerClusterResourceId } | Should -Not -Throw
        Remove-AzSynapseKustoPoolDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -Name $databaseName
    }
}
