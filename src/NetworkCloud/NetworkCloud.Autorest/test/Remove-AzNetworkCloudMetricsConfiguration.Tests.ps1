if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkCloudMetricsConfiguration')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkCloudMetricsConfiguration.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkCloudMetricsConfiguration' {
    It 'Delete' {
        { Remove-AzNetworkCloudMetricsConfiguration -ClusterName $global:config.AzNetworkCloudMetricsConfiguration.clusterName `
                -SubscriptionId $global:config.AzNetworkCloudMetricsConfiguration.subscriptionId `
                -ResourceGroupName $global:config.AzNetworkCloudMetricsConfiguration.resourceGroup `
                -Name $global:config.AzNetworkCloudMetricsConfiguration.metricsConfigurationName }  | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
