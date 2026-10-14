if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkFabricUpgrade')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkFabricUpgrade.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkFabricUpgrade' {
    It 'UpgradeExpanded' {
        {
            Invoke-AzNetworkFabricUpgrade -Name $global:config.fabric.name -ResourceGroupName $global:config.common.resourceGroupName -SubscriptionId $global:config.common.subscriptionId -Version $global:config.fabric.upgradeVersion -Action $global:config.fabric.upgradeAction
        } | Should -Not -Throw
    }

    It 'UpgradeViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpgradeViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Upgrade' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpgradeViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpgradeViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
