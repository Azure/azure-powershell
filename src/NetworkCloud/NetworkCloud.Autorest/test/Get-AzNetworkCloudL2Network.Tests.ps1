if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudL2Network')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudL2Network.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudL2Network' {
    It 'ListBySubscription' {
        { Get-AzNetworkCloudL2Network -Subscription $global:config.AzNetworkCloudL2Network.subscriptionId } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzNetworkCloudL2Network -Name $global:config.AzNetworkCloudL2Network.l2NetworkName -Subscription $global:config.AzNetworkCloudL2Network.subscriptionId -ResourceGroupName $global:config.AzNetworkCloudL2Network.resourceGroup } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        { Get-AzNetworkCloudL2Network -ResourceGroupName $global:config.AzNetworkCloudL2Network.resourceGroup -Subscription $global:config.AzNetworkCloudL2Network.subscriptionId } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
