if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudClusterManager')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudClusterManager.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudClusterManager' {
    It 'ListBySubscription' {
        { Get-AzNetworkCloudClusterManager -SubscriptionId $global:config.AzNetworkCloudClusterManager.subscriptionId } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzNetworkCloudClusterManager -Name $global:config.AzNetworkCloudClusterManager.clusterManagerName -SubscriptionId $global:config.AzNetworkCloudClusterManager.subscriptionId -ResourceGroupName $global:config.AzNetworkCloudClusterManager.resourceGroup } | Should -Not -Throw
    }

    It 'Get ClusterManager with UserAssigned Identity' {
        { Get-AzNetworkCloudClusterManager -Name $global:config.AzNetworkCloudClusterManager.clusterManagerNameUA -SubscriptionId $global:config.AzNetworkCloudClusterManager.subscriptionId -ResourceGroupName $global:config.AzNetworkCloudClusterManager.resourceGroup } | Should -Not -Throw
    }

    It 'Get ClusterManager with SystemAssigned Identity' {
        { Get-AzNetworkCloudClusterManager -Name $global:config.AzNetworkCloudClusterManager.clusterManagerNameSA -SubscriptionId $global:config.AzNetworkCloudClusterManager.subscriptionId -ResourceGroupName $global:config.AzNetworkCloudClusterManager.resourceGroup } | Should -Not -Throw
    }
    
    It 'ListByResourceGroup' {
        { Get-AzNetworkCloudClusterManager -ResourceGroupName $global:config.AzNetworkCloudClusterManager.resourceGroup -SubscriptionId $global:config.AzNetworkCloudClusterManager.subscriptionId } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
