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
        { Remove-AzKustoManagedPrivateEndpoint -ClusterName $env.kustoClusterName -Name "testmanagedprivateendpoint" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.subscriptionId }
        $privateLinkResourceId = $env.eventHubNameSpaceResourceId
        $ManagedPrivateEndpoint = New-AzKustoManagedPrivateEndpoint -ClusterName $env.kustoClusterName -Name "testmanagedprivateendpoint" -ResourceGroupName $env.resourceGroupName -GroupId "namespace" -RequestMessage "Please approve" -PrivateLinkResourceRegion $env.location -PrivateLinkResourceId $privateLinkResourceId -SubscriptionId $env.subscriptionId
        Validate_ManagedPrivateEndpoint $ManagedPrivateEndpoint "testmanagedprivateendpoint"
        { Remove-AzKustoManagedPrivateEndpoint -ClusterName $env.kustoClusterName -Name "testmanagedprivateendpoint" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.subscriptionId }
    }

    It 'Create' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
