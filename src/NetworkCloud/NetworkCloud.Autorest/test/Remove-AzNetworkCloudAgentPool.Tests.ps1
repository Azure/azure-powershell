if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkCloudAgentPool')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkCloudAgentPool.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkCloudAgentPool' {
    It 'Delete' {
        { Remove-AzNetworkCloudAgentPool -Name $global:config.AzNetworkCloudAgentPool.agentPoolName -KubernetesClusterName $global:config.AzNetworkCloudAgentPool.clusterName -ResourceGroupName $global:config.AzNetworkCloudAgentPool.agentPoolRg -SubscriptionId $global:config.AzNetworkCloudAgentPool.subscriptionId } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
