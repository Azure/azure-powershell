if (($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkCloudStorageAppliance')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudStorageAppliance.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkCloudStorageAppliance' {
    It 'Update' {
        {
            $tagUpdatedHash = @{
                CreatedBy = $global:config.AzNetworkCloudStorageAppliance.tags
                tag2      = $global:config.AzNetworkCloudStorageAppliance.tagsUpdate
            }
            Update-AzNetworkCloudStorageAppliance -Name $global:config.AzNetworkCloudStorageAppliance.storageApplianceName `
                -ResourceGroupName $global:config.AzNetworkCloudStorageAppliance.resourceGroup -Tag $tagUpdatedHash `
                -SerialNumber $global:config.AzNetworkCloudStorageAppliance.serialNumber `
                -Subscription $global:config.AzNetworkCloudStorageAppliance.subscriptionId } `
        | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
