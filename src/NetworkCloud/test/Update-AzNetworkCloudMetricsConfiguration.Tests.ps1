if (($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkCloudMetricsConfiguration')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudMetricsConfiguration.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkCloudMetricsConfiguration' {
    It 'Update' {
        {
            $tagUpdatedHash = @{
                tag1 = $global:config.AzNetworkCloudMetricsConfiguration.tags
                tag2 = $global:config.AzNetworkCloudMetricsConfiguration.tagsUpdate
            }

            Update-AzNetworkCloudMetricsConfiguration -ClusterName $global:config.AzNetworkCloudMetricsConfiguration.clusterName `
                -SubscriptionId $global:config.AzNetworkCloudMetricsConfiguration.subscriptionId `
                -ResourceGroupName $global:config.AzNetworkCloudMetricsConfiguration.resourceGroup `
                -Name $global:config.AzNetworkCloudMetricsConfiguration.metricsConfigurationName -Tag $tagUpdatedHash `
                -CollectionInterval $global:config.AzNetworkCloudMetricsConfiguration.collectionIntervalUpdate `
                -EnabledMetric $global:config.AzNetworkCloudMetricsConfiguration.enabledMetricUpdate
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
