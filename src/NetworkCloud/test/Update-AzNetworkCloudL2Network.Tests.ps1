if (($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkCloudL2Network')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudL2Network.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkCloudL2Network' {
    It 'Update' {
        {
            $tagUpdatedHash = @{
                tag1 = $global:config.AzNetworkCloudL2Network.tags
                tag2 = $global:config.AzNetworkCloudL2Network.tagsUpdate
            }
            Update-AzNetworkCloudL2Network -ResourceGroupName $global:config.AzNetworkCloudL2Network.resourceGroup `
                -Name $global:config.AzNetworkCloudL2Network.l2NetworkName -Tag $tagUpdatedHash `
                -Subscription $global:config.AzNetworkCloudL2Network.subscriptionId } `
        | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
