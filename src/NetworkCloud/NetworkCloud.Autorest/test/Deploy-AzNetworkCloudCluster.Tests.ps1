if (($null -eq $TestName) -or ($TestName -contains 'Deploy-AzNetworkCloudCluster')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Deploy-AzNetworkCloudCluster.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Deploy-AzNetworkCloudCluster' {
    It 'Deploy' {
        { Deploy-AzNetworkCloudCluster -Name $global:config.AzNetworkCloudCluster.clusterName -ResourceGroupName $global:config.AzNetworkCloudCluster.clusterRg -SubscriptionId $global:config.AzNetworkCloudCluster.subscriptionId  -NoWait } | Should -Not -Throw
    }

    It 'DeployViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
