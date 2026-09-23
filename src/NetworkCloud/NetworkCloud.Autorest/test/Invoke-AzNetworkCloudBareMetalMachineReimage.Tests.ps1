if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkCloudBareMetalMachineReimage')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkCloudBareMetalMachineReimage.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkCloudBareMetalMachineReimage' {
    It 'Reimage' {
        {
            $bmmConfig = $global:config.AzNetworkCloudBareMetalMachine
            Invoke-AzNetworkCloudBareMetalMachineReimage -Name $bmmConfig.bmmName -ResourceGroupName $bmmConfig.bmmRg -SubscriptionId $bmmConfig.subscriptionId
        } | Should -Not -Throw
    }

    It 'ReimageViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
