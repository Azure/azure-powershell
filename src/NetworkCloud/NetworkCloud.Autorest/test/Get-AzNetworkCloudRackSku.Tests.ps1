if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudRackSku')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudRackSku.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudRackSku' {
    It 'ListBySubscription' {
        { Get-AzNetworkCloudRackSku -Subscription $global:config.AzNetworkCloudRackSku.subscriptionId } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzNetworkCloudRackSku -Name $global:config.AzNetworkCloudRackSku.rackSkuName `
                -Subscription $global:config.AzNetworkCloudRackSku.subscriptionId `
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
