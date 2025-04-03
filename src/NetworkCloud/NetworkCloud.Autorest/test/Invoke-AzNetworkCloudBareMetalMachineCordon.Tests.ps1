if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkCloudBareMetalMachineCordon')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkCloudBareMetalMachineCordon.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkCloudBareMetalMachineCordon' {
    It 'CordonExpanded' {
        {
            $bmmConfig = $global:config.AzNetworkCloudBareMetalMachine
            Invoke-AzNetworkCloudBareMetalMachineCordon -BareMetalMachineName $bmmConfig.bmmName -ResourceGroupName $bmmConfig.bmmRg -SubscriptionId $bmmConfig.subscriptionId -Evacuate $bmmConfig.cordonEvacuate
        } | Should -Not -Throw
    }

    It 'Cordon' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CordonViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CordonViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
