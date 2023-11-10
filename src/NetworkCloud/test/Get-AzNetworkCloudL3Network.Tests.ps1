if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudL3Network')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudL3Network.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudL3Network' {
    It 'ListBySubscription' {
        { Get-AzNetworkCloudL3Network -Subscription $global:config.AzNetworkCloudL3Network.subscriptionId } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzNetworkCloudL3Network -Name $global:config.AzNetworkCloudL3Network.l3NetworkName `
                -ResourceGroupName $global:config.AzNetworkCloudL3Network.resourceGroup `
                -Subscription $global:config.AzNetworkCloudL3Network.subscriptionId `
        } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        { Get-AzNetworkCloudL3Network -ResourceGroupName `
                $global:config.AzNetworkCloudL3Network.resourceGroup `
                -Subscription $global:config.AzNetworkCloudL3Network.subscriptionId } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
