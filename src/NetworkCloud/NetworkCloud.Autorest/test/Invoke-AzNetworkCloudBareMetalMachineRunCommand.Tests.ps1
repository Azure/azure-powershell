if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkCloudBareMetalMachineRunCommand')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkCloudBareMetalMachineRunCommand.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkCloudBareMetalMachineRunCommand' {
    It 'RunExpanded' {
        {
            $bmmConfig = $global:config.AzNetworkCloudBareMetalMachine

            Invoke-AzNetworkCloudBareMetalMachineRunCommand -BareMetalMachineName $bmmConfig.commandsBmmName -ResourceGroupName $bmmConfig.bmmRg -SubscriptionId $bmmConfig.subscriptionId -LimitTimeSecond $bmmConfig.limitTimeSeconds -Script $bmmConfig.script -Argument $bmmConfig.scriptArgs
        } | Should -Not -Throw
    }

    It 'Run' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
