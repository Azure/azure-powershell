if (($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkCloudTrunkedNetwork')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudTrunkedNetwork.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkCloudTrunkedNetwork' {
    It 'Update' {
        {
            $config = $global:config.AzNetworkCloudTrunkedNetwork

            Update-AzNetworkCloudTrunkedNetwork -Name $config.trunkedNetworkName -ResourceGroupName $config.trunkedNetworkRg -SubscriptionId $config.subscriptionId -Tag @{ tag = $config.tagUpdate }
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
