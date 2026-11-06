if (($null -eq $TestName) -or ($TestName -contains 'RedisEnterpriseCache-ChangeSafety')) {
    . (Join-Path $PSScriptRoot 'loadEnv.ps1')
    $TestRecordingFile = Join-Path $PSScriptRoot 'ChangeSafety.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
    $null = [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.PipelineMock]::Blacklist.Add('x-ms-policy-external-evaluations')
}

Describe 'RedisEnterpriseCache-ChangeSafety' {
    AfterAll {
        Complete-RedisEnterpriseCacheTestRecording -Path $TestRecordingFile
    }

    BeforeAll {
        $fixturePath = Join-Path $PSScriptRoot 'ChangeSafety.env.json'
        if ($TestMode -eq 'playback') {
            $script:policyFixture = Get-Content -LiteralPath $fixturePath -Raw | ConvertFrom-Json
        } else {
            $script:policyFixture = @{
                SubscriptionId = $env.SubscriptionId
                ResourceGroupName = $env.ResourceGroupName
                Location = $env.Location
                Name = $env.ClusterName + 'policy'
            }
            if ($TestMode -eq 'record') {
                $script:policyFixture | ConvertTo-Json | Set-Content -LiteralPath $fixturePath
            }
        }
    }

    It 'CreateNoDatabase-AcquirePolicyToken' {
        $observation = @{ Writes = 0 }
        $observer = New-RedisEnterpriseCacheTestPolicyTokenObserver $observation
        $cache = New-AzRedisEnterpriseCache -Name $script:policyFixture.Name `
            -ResourceGroupName $script:policyFixture.ResourceGroupName `
            -SubscriptionId $script:policyFixture.SubscriptionId -Location $script:policyFixture.Location `
            -Sku Balanced_B10 -NoDatabase -PublicNetworkAccess Enabled `
            -AcquirePolicyToken -HttpPipelineAppend $observer
        $cache.Name | Should -Be $script:policyFixture.Name
        $cache.ProvisioningState | Should -Be 'Succeeded'
        $cache.Database.Count | Should -Be 0
        if ($TestMode -ne 'playback') {
            $observation.Writes | Should -BeGreaterThan 0
        }
    }

    It 'UpdateExpanded-AcquirePolicyToken' {
        $observation = @{ Writes = 0 }
        $observer = New-RedisEnterpriseCacheTestPolicyTokenObserver $observation
        $cache = Update-AzRedisEnterpriseCache -Name $script:policyFixture.Name `
            -ResourceGroupName $script:policyFixture.ResourceGroupName `
            -SubscriptionId $script:policyFixture.SubscriptionId -EnableSystemAssignedIdentity $true `
            -AcquirePolicyToken -HttpPipelineAppend $observer
        $cache.IdentityType | Should -Be 'SystemAssigned'
        if ($TestMode -ne 'playback') {
            $observation.Writes | Should -BeGreaterThan 0
        }
    }

    It 'Delete-AcquirePolicyToken' {
        $observation = @{ Writes = 0 }
        $observer = New-RedisEnterpriseCacheTestPolicyTokenObserver $observation
        Remove-AzRedisEnterpriseCache -Name $script:policyFixture.Name `
            -ResourceGroupName $script:policyFixture.ResourceGroupName `
            -SubscriptionId $script:policyFixture.SubscriptionId `
            -AcquirePolicyToken -HttpPipelineAppend $observer -Confirm:$false
        {
            Get-AzRedisEnterpriseCache -Name $script:policyFixture.Name `
                -ResourceGroupName $script:policyFixture.ResourceGroupName `
                -SubscriptionId $script:policyFixture.SubscriptionId -ErrorAction Stop
        } | Should -Throw
        if ($TestMode -ne 'playback') {
            $observation.Writes | Should -BeGreaterThan 0
        }
    }
}
