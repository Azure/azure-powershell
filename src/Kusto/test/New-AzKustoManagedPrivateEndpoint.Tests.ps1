Describe 'New-AzKustoManagedPrivateEndpoint' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoManagedPrivateEndpoint.Recording.json'
        $currentPath = $PSScriptRoot
        while(-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }

    It 'CreateExpanded' {
        { Remove-AzKustoManagedPrivateEndpoint -ClusterName $env.clusterNetwork -Name $env.managedPrivateEndpointName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.networkClustersTestsSubscriptionId }
        $privateLinkResourceId = $env.eventHubResourceId
        $ManagedPrivateEndpoint = New-AzKustoManagedPrivateEndpoint -ClusterName $env.clusterNetwork -Name $env.managedPrivateEndpointName -ResourceGroupName $env.resourceGroupName -GroupId "namespace" -RequestMessage $env.managedPrivateEndpointRequestMessage -PrivateLinkResourceRegion $env.location -PrivateLinkResourceId $privateLinkResourceId -SubscriptionId $env.networkClustersTestsSubscriptionId
        Validate_ManagedPrivateEndpoint $ManagedPrivateEndpoint $env.managedPrivateEndpointName
        { Remove-AzKustoManagedPrivateEndpoint -ClusterName $env.clusterNetwork -Name $env.managedPrivateEndpointName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.networkClustersTestsSubscriptionId }
    }

    It 'Create' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
