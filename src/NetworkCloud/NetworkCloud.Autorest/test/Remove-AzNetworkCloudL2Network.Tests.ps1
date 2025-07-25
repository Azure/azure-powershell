if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkCloudL2Network')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkCloudL2Network.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkCloudL2Network' {
    It 'Delete' {
        { Remove-AzNetworkCloudL2Network  -Name $global:config.AzNetworkCloudL2Network.l2NetworkName `
                -ResourceGroupName $global:config.AzNetworkCloudL2Network.resourceGroup  `
                -Subscription $global:config.AzNetworkCloudL2Network.subscriptionId } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
