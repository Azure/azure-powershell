if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudBareMetalMachine')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudBareMetalMachine.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudBareMetalMachine' {
    It 'ListBySubscription' {
        {
            Get-AzNetworkCloudBareMetalMachine -SubscriptionId $global:config.AzNetworkCloudBareMetalMachine.subscriptionId
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $bmmConfig = $global:config.AzNetworkCloudBareMetalMachine
            Get-AzNetworkCloudBareMetalMachine -Name $bmmConfig.bmmName -ResourceGroup $bmmConfig.bmmRg -SubscriptionId $bmmConfig.subscriptionId
        } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        {
            $bmmConfig = $global:config.AzNetworkCloudBareMetalMachine
            Get-AzNetworkCloudBareMetalMachine -ResourceGroup $bmmConfig.bmmRg -SubscriptionId $bmmConfig.subscriptionId
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
