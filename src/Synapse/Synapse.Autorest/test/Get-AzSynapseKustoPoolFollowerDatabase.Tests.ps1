Describe 'Get-AzSynapseKustoPoolFollowerDatabase' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSynapseKustoPoolFollowerDatabase.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'List' {
        $subscriptionId = $env.SubscriptionId
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName
        $databaseName = $env.databaseName
        $attachedDatabaseConfigurationName = $env.attachedDatabaseConfigurationName
        $followerKustoPoolName = $env.followerKustoPoolName
        $kustoPoolResourceId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Synapse/workspaces/$workspaceName/kustoPools/$followerKustoPoolName"

        [array]$kustoPoolFollowerDatabaseGet = Get-AzSynapseKustoPoolFollowerDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName
        $kustoPoolFollowerDatabase = $kustoPoolFollowerDatabaseGet[0]
        Validate_ClusterFollowerDatabase $kustoPoolFollowerDatabase $attachedDatabaseConfigurationName $kustoPoolResourceId $databaseName
    }
}
