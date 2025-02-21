if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudStorageAppliance')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudStorageAppliance.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudStorageAppliance' {
    It 'ListBySubscription' {
        { Get-AzNetworkCloudStorageAppliance -Subscription $global:config.AzNetworkCloudStorageAppliance.subscriptionId } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzNetworkCloudStorageAppliance -Name $global:config.AzNetworkCloudStorageAppliance.storageApplianceName -Subscription $global:config.AzNetworkCloudStorageAppliance.subscriptionId -ResourceGroupName $global:config.AzNetworkCloudStorageAppliance.resourceGroup } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        { Get-AzNetworkCloudStorageAppliance -ResourceGroupName $global:config.AzNetworkCloudStorageAppliance.resourceGroup -Subscription $global:config.AzNetworkCloudStorageAppliance.subscriptionId } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
