if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudRack')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudRack.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudRack' {
    It 'ListBySubscription' {
        { Get-AzNetworkCloudRack -Subscription $global:config.AzNetworkCloudRack.subscriptionId } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzNetworkCloudRack -Name $global:config.AzNetworkCloudRack.rackName `
                -ResourceGroupName $global:config.AzNetworkCloudRack.resourceGroup `
                -Subscription $global:config.AzNetworkCloudRack.subscriptionId `
        } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        { Get-AzNetworkCloudRack -ResourceGroupName `
                $global:config.AzNetworkCloudRack.resourceGroup `
                -Subscription $global:config.AzNetworkCloudRack.subscriptionId } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
