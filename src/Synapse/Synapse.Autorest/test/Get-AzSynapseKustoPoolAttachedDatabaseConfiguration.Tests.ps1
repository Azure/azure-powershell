Describe 'Get-AzSynapseKustoPoolAttachedDatabaseConfiguration' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
             $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSynapseKustoPoolAttachedDatabaseConfiguration.Recording.json'
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
        $attachedDatabaseConfigurationName = $env.attachedDatabaseConfigurationName
        $followerKustoPoolName = $env.followerKustoPoolName
        $defaultPrincipalsModificationKind = $env.defaultPrincipalsModificationKind
        $kustoPoolResourceId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Synapse/workspaces/$workspaceName/kustoPools/$kustoPoolName"
        $attachedDatabaseConfigurationFullName = $workspaceName + "/" + $followerKustoPoolName + "/" + $attachedDatabaseConfigurationName

        [array]$attachedDatabaseConfigurationGet = Get-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $followerKustoPoolName
        $attachedDatabaseConfiguration = $attachedDatabaseConfigurationGet[0]
        Validate_AttachedDatabaseConfiguration $attachedDatabaseConfiguration $attachedDatabaseConfigurationFullName  $location $kustoPoolResourceId $databaseName $defaultPrincipalsModificationKind
    }

    It 'Get' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName
        $databaseName = $env.databaseName
        $attachedDatabaseConfigurationName = $env.attachedDatabaseConfigurationName
        $followerKustoPoolName = $env.followerKustoPoolName
        $defaultPrincipalsModificationKind = $env.defaultPrincipalsModificationKind
        $kustoPoolResourceId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Synapse/workspaces/$workspaceName/kustoPools/$kustoPoolName"
        $attachedDatabaseConfigurationFullName = $workspaceName + "/" + $followerKustoPoolName + "/" + $attachedDatabaseConfigurationName

        $attachedDatabaseConfiguration = Get-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $followerKustoPoolName -AttachedDatabaseConfigurationName $attachedDatabaseConfigurationName
        Validate_AttachedDatabaseConfiguration $attachedDatabaseConfiguration $attachedDatabaseConfigurationFullName  $location $kustoPoolResourceId $databaseName $defaultPrincipalsModificationKind
    }
}
