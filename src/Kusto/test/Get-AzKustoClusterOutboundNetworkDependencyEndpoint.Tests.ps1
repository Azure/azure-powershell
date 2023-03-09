Describe 'Get-AzKustoClusterOutboundNetworkDependencyEndpoint' {
    BeforeAll {
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoClusterOutboundNetworkDependencyEndpoint.Recording.json'
        $currentPath = $PSScriptRoot
        while(-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }

    It 'List' {
        #Set-AzContext -SubscriptionId $env.networkClustersTestsSubscriptionId

        $clusterName = $env.kustoClusterName
        $KustoClusterOutboundNetworkDependencyEndpointList = Get-AzKustoClusterOutboundNetworkDependencyEndpoint -ClusterName $clusterName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.subscriptionId
        $KustoClusterOutboundNetworkDependencyEndpointList.Count | Should -Be 5

        #Set-AzContext -SubscriptionId $env.SubscriptionId
    }
}
