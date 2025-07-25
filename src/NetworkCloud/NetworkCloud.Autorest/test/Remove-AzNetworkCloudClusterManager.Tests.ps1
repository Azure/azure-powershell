if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkCloudClusterManager')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkCloudClusterManager.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkCloudClusterManager' {
    It 'Delete' {
        { Remove-AzNetworkCloudClusterManager  -Name $global:config.AzNetworkCloudClusterManager.clusterManagerName `
                -ResourceGroupName $global:config.AzNetworkCloudClusterManager.resourceGroup `
                -SubscriptionId $global:config.AzNetworkCloudClusterManager.subscriptionId 
        } | Should -Not -Throw
    }
    It 'Delete ClusterManager with UserAssigned Identity' {
        { Remove-AzNetworkCloudClusterManager  -Name $global:config.AzNetworkCloudClusterManager.clusterManagerNameUA `
                -ResourceGroupName $global:config.AzNetworkCloudClusterManager.resourceGroup `
                -SubscriptionId $global:config.AzNetworkCloudClusterManager.subscriptionId 
        } | Should -Not -Throw
    }
    It 'Delete ClusterManager with SystemAssigned Identity' {
        { Remove-AzNetworkCloudClusterManager  -Name $global:config.AzNetworkCloudClusterManager.clusterManagerNameSA `
                -ResourceGroupName $global:config.AzNetworkCloudClusterManager.resourceGroup `
                -SubscriptionId $global:config.AzNetworkCloudClusterManager.subscriptionId 
        } | Should -Not -Throw
    }
    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
