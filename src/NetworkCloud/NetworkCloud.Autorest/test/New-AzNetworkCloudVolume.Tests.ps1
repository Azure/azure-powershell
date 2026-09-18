if (($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkCloudVolume')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudVolume.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkCloudVolume' {
    It 'Create' {
        {
            $volumeConfig = $global:config.AzNetworkCloudVolume
            $global = $global:config.common

            New-AzNetworkCloudVolume -Name $volumeConfig.volumeName -ResourceGroupName $volumeConfig.volumeRg -SubscriptionId $volumeConfig.subscriptionId -ExtendedLocationName $volumeConfig.extendedLocation -ExtendedLocationType $global.customLocationType -Location $global.location -SizeMiB $volumeConfig.size -Tag @{ tag = $volumeConfig.tags }
        } | Should -Not -Throw
    }
}
