if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkCloudBareMetalMachineDataExtract')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkCloudBareMetalMachineDataExtract.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkCloudBareMetalMachineDataExtract' {
    It 'RunViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunExpanded' {
        {
            $bmmConfig = $global:config.AzNetworkCloudBareMetalMachine
            $command = @{
                command   = $bmmConfig.dataExtractCommand
                arguments = $bmmConfig.dataExtractArgs
            }

            Invoke-AzNetworkCloudBareMetalMachineDataExtract -BareMetalMachineName $bmmConfig.commandsBmmName -ResourceGroupName $bmmConfig.bmmRg -SubscriptionId $bmmConfig.subscriptionId -Command $command -LimitTimeSecond $bmmConfig.limitTimeSeconds
        } | Should -Not -Throw
    }

    It 'Run' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
