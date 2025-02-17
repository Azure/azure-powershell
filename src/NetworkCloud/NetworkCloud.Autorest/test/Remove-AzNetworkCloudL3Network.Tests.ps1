if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkCloudL3Network')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkCloudL3Network.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkCloudL3Network' {
    It 'Delete' {
        { Remove-AzNetworkCloudL3Network  -Name $global:config.AzNetworkCloudL3Network.l3NetworkName `
                -ResourceGroupName $global:config.AzNetworkCloudL3Network.resourceGroup `
                -Subscription $global:config.AzNetworkCloudL3Network.subscriptionId `
        }  | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
