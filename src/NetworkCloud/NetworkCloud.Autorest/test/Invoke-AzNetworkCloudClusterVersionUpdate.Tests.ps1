if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkCloudClusterVersionUpdate')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkCloudClusterVersionUpdate.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkCloudClusterVersionUpdate' {
    It 'Update' {
        { Invoke-AzNetworkCloudClusterVersionUpdate -ClusterName $global:config.AzNetworkCloudCluster.clusterName -ResourceGroupName $global:config.AzNetworkCloudCluster.clusterRg -TargetClusterVersion $global:config.AzNetworkCloudCluster.targetClusterVersion -SubscriptionId $global:config.AzNetworkCloudCluster.subscriptionId -NoWait } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
