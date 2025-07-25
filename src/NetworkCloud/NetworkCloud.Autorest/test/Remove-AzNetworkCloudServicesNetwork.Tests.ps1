if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkCloudServicesNetwork')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkCloudServicesNetwork.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkCloudServicesNetwork' {
    It 'Delete' {
        { Remove-AzNetworkCloudServicesNetwork  -Name $global:config.AzNetworkCloudServicesNetwork.cnsName `
                -ResourceGroupName $global:config.AzNetworkCloudServicesNetwork.resourceGroup `
                -Subscription $global:config.AzNetworkCloudServicesNetwork.subscriptionId `
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
