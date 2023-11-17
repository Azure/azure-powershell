if (($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkCloudL3Network')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudL3Network.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkCloudL3Network' {
    It 'Update' {
        {
            $tagUpdatedHash = @{
                tag1 = $global:config.AzNetworkCloudL3Network.tags
                tag2 = $global:config.AzNetworkCloudL3Network.tagsUpdate
            }
            Update-AzNetworkCloudL3Network -ResourceGroupName $global:config.AzNetworkCloudL3Network.resourceGroup `
                -Subscription $global:config.AzNetworkCloudL3Network.subscriptionId `
                -Name $global:config.AzNetworkCloudL3Network.l3NetworkName -Tag $tagUpdatedHash } `
        | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
