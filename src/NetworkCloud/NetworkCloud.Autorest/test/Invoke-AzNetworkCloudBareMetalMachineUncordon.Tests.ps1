if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkCloudBareMetalMachineUncordon')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkCloudBareMetalMachineUncordon.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkCloudBareMetalMachineUncordon' {
    It 'Uncordon' {
        {
            $bmmConfig = $global:config.AzNetworkCloudBareMetalMachine
            Invoke-AzNetworkCloudBareMetalMachineUncordon -BareMetalMachineName $bmmConfig.bmmName -ResourceGroupName $bmmConfig.bmmRg -SubscriptionId $bmmConfig.subscriptionId
        } | Should -Not -Throw
    }

    It 'UncordonViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
