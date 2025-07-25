if (($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkCloudRack')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudRack.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkCloudRack' {
    It 'Update' {
        {
            $tagUpdatedHash = @{
                tag1 = $global:config.AzNetworkCloudRack.tags
                tag2 = $global:config.AzNetworkCloudRack.tagsUpdate
            }
            Update-AzNetworkCloudRack -ResourceGroupName $global:config.AzNetworkCloudRack.resourceGroup `
                -Subscription $global:config.AzNetworkCloudRack.subscriptionId `
                -RackLocation $global:config.AzNetworkCloudRack.rackLocation `
                -RackSerialNumber $global:config.AzNetworkCloudRack.rackSerialNumber `
                -Name $global:config.AzNetworkCloudRack.rackName -Tag $tagUpdatedHash } `
        | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
