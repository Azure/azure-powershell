if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudMetricsConfiguration')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudMetricsConfiguration.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudMetricsConfiguration' {
    It 'ListByParent' {
        { Get-AzNetworkCloudMetricsConfiguration -ClusterName $global:config.AzNetworkCloudMetricsConfiguration.clusterName `
                -ResourceGroupName $global:config.AzNetworkCloudMetricsConfiguration.resourceGroup `
                -SubscriptionId $global:config.AzNetworkCloudMetricsConfiguration.subscriptionId } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzNetworkCloudMetricsConfiguration -ClusterName $global:config.AzNetworkCloudMetricsConfiguration.clusterName `
                -Name $global:config.AzNetworkCloudMetricsConfiguration.metricsConfigurationName `
                -ResourceGroupName $global:config.AzNetworkCloudMetricsConfiguration.resourceGroup `
                -SubscriptionId $global:config.AzNetworkCloudMetricsConfiguration.subscriptionId } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
