if (($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkCloudVolume')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudVolume.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkCloudVolume' {
    It 'Update' {
        {
            $volumeConfig = $global:config.AzNetworkCloudVolume
            Update-AzNetworkCloudVolume -Name $volumeConfig.volumeName -ResourceGroupName $volumeConfig.volumeRg -SubscriptionId $volumeConfig.subscriptionId -Tag @{ tag = $volumeConfig.tagsUpdate }
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
