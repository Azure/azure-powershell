if (($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkCloudKubernetesCluster')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudKubernetesCluster.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkCloudKubernetesCluster' {
    It 'Update' {
        { $tagUpdatedHash = @{
                tag1 = $global:config.AzNetworkCloudKubernetesCluster.tags
                tag2 = $global:config.AzNetworkCloudKubernetesCluster.tagsUpdate
            }
            Update-AzNetworkCloudKubernetesCluster -KubernetesClusterName $global:config.AzNetworkCloudKubernetesCluster.kubernetesClusterName -ResourceGroupName $global:config.AzNetworkCloudKubernetesCluster.resourceGroup -Tag $tagUpdatedHash -ControlPlaneNodeConfigurationCount $global:config.AzNetworkCloudKubernetesCluster.count -KubernetesVersion $global:config.AzNetworkCloudKubernetesCluster.kubernetesVersion -SubscriptionId $global:config.AzNetworkCloudKubernetesCluster.subscriptionId
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
