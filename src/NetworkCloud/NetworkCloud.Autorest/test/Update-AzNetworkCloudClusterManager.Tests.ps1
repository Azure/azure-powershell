if (($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkCloudClusterManager')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudClusterManager.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkCloudClusterManager' {
    It 'Update' {
        { $cmconfig = $global:config.AzNetworkCloudClusterManager
            $tagUpdatedHash = @{
                $cmconfig.tagsKey1      = $cmconfig.tagsValue1
                $cmconfig.tagsKey2      = $cmconfig.tagsValue2
                $cmconfig.tagsUpdateKey = $cmconfig.tagsUpdateValue
            }
            Update-AzNetworkCloudClusterManager -ResourceGroupName $cmconfig.resourceGroup `
                -SubscriptionId $cmconfig.subscriptionId `
                -Name $cmconfig.clusterManagerName -Tag $tagUpdatedHash } `
        | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
