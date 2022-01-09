Describe 'New-AzSynapseKustoPoolAttachedDatabaseConfiguration' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSynapseKustoPoolAttachedDatabaseConfiguration.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'CreateExpanded' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName
        $databaseName = "testdatabase" + $env.rstr4
        $attachedDatabaseConfigurationName = "testdbconf" + $env.rstr4
        $followerKustoPoolName = $env.followerKustoPoolName
        $defaultPrincipalsModificationKind = $env.defaultPrincipalsModificationKind
        $kustoPoolResourceId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Synapse/workspaces/$workspaceName/kustoPools/$kustoPoolName"
        $followerKustoPoolResourceId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Synapse/workspaces/$workspaceName/kustoPools/$followerKustoPoolName"
        $attachedDatabaseConfigurationFullName = $workspaceName + "/" + $followerKustoPoolName + "/" + $attachedDatabaseConfigurationName

        New-AzSynapseKustoPoolDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -Name $databaseName -Kind ReadWrite -Location $location
        $attachedDatabaseConfigurationCreated = New-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $followerKustoPoolName -Name $attachedDatabaseConfigurationName -Location $location -KustoPoolResourceId $kustoPoolResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $defaultPrincipalsModificationKind
        Validate_AttachedDatabaseConfiguration $attachedDatabaseConfigurationCreated $attachedDatabaseConfigurationFullName  $location $kustoPoolResourceId $databaseName $defaultPrincipalsModificationKind
        { Invoke-AzSynapseDetachKustoPoolFollowerDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -AttachedDatabaseConfigurationName $attachedDatabaseConfigurationName -KustoPoolResourceId $followerKustoPoolResourceId } | Should -Not -Throw
        Remove-AzSynapseKustoPoolDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -Name $databaseName
    }
}
