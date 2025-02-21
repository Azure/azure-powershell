if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudServicesNetwork')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudServicesNetwork.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudServicesNetwork' {
    It 'ListBySubscription' {
        { Get-AzNetworkCloudServicesNetwork -Subscription $global:config.AzNetworkCloudServicesNetwork.subscriptionId } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzNetworkCloudServicesNetwork -Name $global:config.AzNetworkCloudServicesNetwork.cnsName -Subscription $global:config.AzNetworkCloudServicesNetwork.subscriptionId -ResourceGroupName $global:config.AzNetworkCloudServicesNetwork.resourceGroup } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        { Get-AzNetworkCloudServicesNetwork -ResourceGroupName $global:config.AzNetworkCloudServicesNetwork.resourceGroup -Subscription $global:config.AzNetworkCloudServicesNetwork.subscriptionId } | Should -Not -Throw
    }


    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}