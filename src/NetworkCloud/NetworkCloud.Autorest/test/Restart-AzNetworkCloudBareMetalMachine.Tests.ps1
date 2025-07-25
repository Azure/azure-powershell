if (($null -eq $TestName) -or ($TestName -contains 'Restart-AzNetworkCloudBareMetalMachine')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzNetworkCloudBareMetalMachine.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Restart-AzNetworkCloudBareMetalMachine' {
    It 'Restart' {
        {
            $bmmConfig = $global:config.AzNetworkCloudBareMetalMachine
            Restart-AzNetworkCloudBareMetalMachine -Name $bmmConfig.bmmName -ResourceGroupName $bmmConfig.bmmRg -SubscriptionId $bmmConfig.subscriptionId
        } | Should -Not -Throw
    }

    It 'RestartViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
