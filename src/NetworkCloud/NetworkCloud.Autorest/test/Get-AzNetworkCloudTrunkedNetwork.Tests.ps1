if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudTrunkedNetwork')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudTrunkedNetwork.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudTrunkedNetwork' {
    It 'ListBySubscription' {
        {
            $config = $global:config.AzNetworkCloudTrunkedNetwork

            Get-AzNetworkCloudTrunkedNetwork -SubscriptionId $config.subscriptionId
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = $global:config.AzNetworkCloudTrunkedNetwork

            Get-AzNetworkCloudTrunkedNetwork -Name $config.trunkedNetworkName -ResourceGroupName $config.trunkedNetworkRg -SubscriptionId $config.subscriptionId
        } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        {
            $config = $global:config.AzNetworkCloudTrunkedNetwork

            Get-AzNetworkCloudTrunkedNetwork -ResourceGroupName $config.trunkedNetworkRg -SubscriptionId $config.subscriptionId
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
