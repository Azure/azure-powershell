if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudKubernetesCluster')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudKubernetesCluster.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudKubernetesCluster' {
    It 'ListBySubscription' {
        { Get-AzNetworkCloudKubernetesCluster -SubscriptionId $global:config.AzNetworkCloudKubernetesCluster.subscriptionId } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzNetworkCloudKubernetesCluster -KubernetesClusterName $global:config.AzNetworkCloudKubernetesCluster.kubernetesClusterName -SubscriptionId $global:config.AzNetworkCloudKubernetesCluster.subscriptionId -ResourceGroupName $global:config.AzNetworkCloudKubernetesCluster.resourceGroup } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        { Get-AzNetworkCloudKubernetesCluster -ResourceGroupName $global:config.AzNetworkCloudKubernetesCluster.resourceGroup -SubscriptionId $global:config.AzNetworkCloudKubernetesCluster.subscriptionId } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
