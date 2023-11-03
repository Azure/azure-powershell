if (($null -eq $TestName) -or ($TestName -contains 'AzSubscription')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'AzSubscription.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzSubscription' {
    It 'CreateAliasExpanded' {
        {
            $config = New-AzSubscriptionAlias -AliasName $env.testSubName -SubscriptionId $env.SubscriptionId
            $config.AliasName | Should -Be $env.testSubName
        } | Should -Not -Throw
    }

    It 'ListAlias' {
        {
            $config = Get-AzSubscriptionAlias -AliasName $env.testSubName
            $config.AliasName | Should -Be $env.testSubName
        } | Should -Not -Throw
    }

    It 'GetPolicy' {
        {
            $config = Get-AzSubscriptionPolicy
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'RenameSub' {
        {
            $config = Rename-AzSubscription -Id $env.SubscriptionId -SubscriptionName "testsubscription"
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'DeleteAlias' -Skip {
        {
            Remove-AzSubscriptionAlias -AliasName $env.testSubName
        } | Should -Not -Throw
    }

    It 'UpdateSubPolicy' -skip {
        {
            $config = Update-AzSubscriptionPolicy -BlockSubscriptionsIntoTenant:$false -BlockSubscriptionsLeavingTenant:$false 
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
