Describe 'Remove-AzSynapseKustoPoolAttachedDatabaseConfiguration' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSynapseKustoPoolAttachedDatabaseConfiguration.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Delete' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName
        $databaseName = "testdatabase" + $env.rstr5
        $attachedDatabaseConfigurationName = "testdbconf" + $env.rstr5
        $followerKustoPoolName = $env.followerKustoPoolName
        $defaultPrincipalsModificationKind = $env.defaultPrincipalsModificationKind
        $kustoPoolResourceId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Synapse/workspaces/$workspaceName/kustoPools/$kustoPoolName"

        New-AzSynapseKustoPoolDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -Name $databaseName -Kind ReadWrite -Location $location
        New-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $followerKustoPoolName -Name $attachedDatabaseConfigurationName -Location $location -KustoPoolResourceId $kustoPoolResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $defaultPrincipalsModificationKind
        { Remove-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $followerKustoPoolName -Name $attachedDatabaseConfigurationName } | Should -Not -Throw
        Remove-AzSynapseKustoPoolDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -Name $databaseName
    }
}
