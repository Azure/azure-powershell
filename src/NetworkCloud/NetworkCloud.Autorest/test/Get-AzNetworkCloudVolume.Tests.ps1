if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudVolume')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudVolume.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudVolume' {
    It 'ListBySubscription' {
        {
            $volumeConfig = $global:config.AzNetworkCloudVolume
            Get-AzNetworkCloudVolume -SubscriptionId $volumeConfig.subscriptionId
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $volumeConfig = $global:config.AzNetworkCloudVolume
            Get-AzNetworkCloudVolume -SubscriptionId $volumeConfig.subscriptionId -Name $volumeConfig.volumeName -ResourceGroupName $volumeConfig.volumeRg
        } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        {
            $volumeConfig = $global:config.AzNetworkCloudVolume
            Get-AzNetworkCloudVolume -ResourceGroupName $volumeConfig.volumeRg -SubscriptionId $volumeConfig.subscriptionId
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
