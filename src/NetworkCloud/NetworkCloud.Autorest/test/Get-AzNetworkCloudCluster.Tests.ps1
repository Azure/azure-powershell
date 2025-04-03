if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudCluster')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudCluster.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudCluster' {
    It 'ListBySubscription' {
        { Get-AzNetworkCloudCluster -SubscriptionId $global:config.AzNetworkCloudCluster.subscriptionId } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzNetworkCloudCluster -Name $global:config.AzNetworkCloudCluster.clusterName -ResourceGroupName $global:config.AzNetworkCloudCluster.clusterRg -SubscriptionId $global:config.AzNetworkCloudCluster.subscriptionId } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        { Get-AzNetworkCloudCluster -ResourceGroupName $global:config.AzNetworkCloudCluster.clusterRg -SubscriptionId $global:config.AzNetworkCloudCluster.subscriptionId } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
