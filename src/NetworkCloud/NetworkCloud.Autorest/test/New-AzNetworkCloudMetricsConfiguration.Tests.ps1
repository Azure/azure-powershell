if (($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkCloudMetricsConfiguration')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudMetricsConfiguration.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkCloudMetricsConfiguration' {
    It 'Create' {
        { New-AzNetworkCloudMetricsConfiguration -ClusterName $global:config.AzNetworkCloudMetricsConfiguration.clusterName `
                -SubscriptionId $global:config.AzNetworkCloudMetricsConfiguration.subscriptionId `
                -EnabledMetric $global:config.AzNetworkCloudMetricsConfiguration.enabledMetric `
                -MetricsConfigurationName $global:config.AzNetworkCloudMetricsConfiguration.metricsConfigurationName `
                -ResourceGroupName $global:config.AzNetworkCloudMetricsConfiguration.resourceGroup `
                -CollectionInterval $global:config.AzNetworkCloudMetricsConfiguration.collectionInterval `
                -ExtendedLocationName $global:config.AzNetworkCloudMetricsConfiguration.extendedLocation `
                -ExtendedLocationType $global:config.AzNetworkCloudMetricsConfiguration.extendedLocationType `
                -Location $global:config.AzNetworkCloudMetricsConfiguration.location } | Should -Not -Throw
    }
}
