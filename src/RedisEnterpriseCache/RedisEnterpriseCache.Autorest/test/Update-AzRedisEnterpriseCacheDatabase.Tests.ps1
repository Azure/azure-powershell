$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzRedisEnterpriseCacheDatabase.Recording.json'

Describe 'Update-AzRedisEnterpriseCacheDatabase' {
    BeforeAll {
        $customModule = Get-Module -All 'Az.RedisEnterpriseCache.custom'
        $script:updateCommand = & $customModule {
            Get-Command 'Update-AzRedisEnterpriseCacheDatabase'
        }
    }

    BeforeEach {
        Mock 'Az.RedisEnterpriseCache.internal\Get-AzRedisEnterpriseCacheDatabase' -ModuleName 'Az.RedisEnterpriseCache.custom' {
            [pscustomobject]@{
                ClientProtocol = 'Encrypted'
                EvictionPolicy = 'VolatileLRU'
            }
        }
        Mock 'Az.RedisEnterpriseCache.internal\New-AzRedisEnterpriseCacheDatabase' -ModuleName 'Az.RedisEnterpriseCache.custom' { }
    }

    It 'preserves the named route including an explicit SubscriptionId' {
        & $script:updateCommand `
            -ClusterName 'named-cache' `
            -ResourceGroupName 'named-rg' `
            -SubscriptionId 'named-sub' `
            -ClientProtocol 'Plaintext'

        Assert-MockCalled 'Az.RedisEnterpriseCache.internal\Get-AzRedisEnterpriseCacheDatabase' `
            -ModuleName 'Az.RedisEnterpriseCache.custom' `
            -Times 1 `
            -Exactly `
            -Scope It `
            -ParameterFilter {
                $ClusterName -eq 'named-cache' -and
                $ResourceGroupName -eq 'named-rg' -and
                $Name -eq 'default' -and
                $SubscriptionId -eq 'named-sub'
            }
        Assert-MockCalled 'Az.RedisEnterpriseCache.internal\New-AzRedisEnterpriseCacheDatabase' `
            -ModuleName 'Az.RedisEnterpriseCache.custom' `
            -Times 1 `
            -Exactly `
            -Scope It `
            -ParameterFilter {
                $ClusterName -eq 'named-cache' -and
                $ResourceGroupName -eq 'named-rg' -and
                $Name -eq 'default' -and
                $SubscriptionId -eq 'named-sub' -and
                $ClientProtocol -eq 'Plaintext' -and
                $EvictionPolicy -eq 'VolatileLRU'
            }
    }

    It 'routes an Id-only database identity through named GET and PUT parameters' {
        $identity = New-Object Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.RedisEnterpriseCacheIdentity
        $identity.Id = '/subscriptions/id-sub/resourceGroups/id-rg/providers/Microsoft.Cache/redisEnterprise/id-cache/databases/default'

        & $script:updateCommand -InputObject $identity -EvictionPolicy 'NoEviction'

        Assert-MockCalled 'Az.RedisEnterpriseCache.internal\Get-AzRedisEnterpriseCacheDatabase' `
            -ModuleName 'Az.RedisEnterpriseCache.custom' `
            -Times 1 `
            -Exactly `
            -Scope It `
            -ParameterFilter {
                $ClusterName -eq 'id-cache' -and
                $ResourceGroupName -eq 'id-rg' -and
                $Name -eq 'default' -and
                $SubscriptionId -eq 'id-sub' -and
                $null -eq $RedisEnterpriseInputObject
            }
        Assert-MockCalled 'Az.RedisEnterpriseCache.internal\New-AzRedisEnterpriseCacheDatabase' `
            -ModuleName 'Az.RedisEnterpriseCache.custom' `
            -Times 1 `
            -Exactly `
            -Scope It `
            -ParameterFilter {
                $ClusterName -eq 'id-cache' -and
                $ResourceGroupName -eq 'id-rg' -and
                $Name -eq 'default' -and
                $SubscriptionId -eq 'id-sub' -and
                $EvictionPolicy -eq 'NoEviction' -and
                $null -eq $InputObject -and
                $null -eq $RedisEnterpriseInputObject
            }
        $identity.Id | Should -Be '/subscriptions/id-sub/resourceGroups/id-rg/providers/Microsoft.Cache/redisEnterprise/id-cache/databases/default'
        $identity.DatabaseName | Should -BeNullOrEmpty
    }

    It 'defaults an Id-only cluster identity to the default database' {
        $identity = New-Object Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.RedisEnterpriseCacheIdentity
        $identity.Id = '/subscriptions/cluster-sub/resourceGroups/cluster-rg/providers/Microsoft.Cache/redisEnterprise/cluster-cache'

        & $script:updateCommand -InputObject $identity

        Assert-MockCalled 'Az.RedisEnterpriseCache.internal\Get-AzRedisEnterpriseCacheDatabase' `
            -ModuleName 'Az.RedisEnterpriseCache.custom' `
            -Times 1 `
            -Exactly `
            -Scope It `
            -ParameterFilter {
                $ClusterName -eq 'cluster-cache' -and
                $ResourceGroupName -eq 'cluster-rg' -and
                $Name -eq 'default' -and
                $SubscriptionId -eq 'cluster-sub'
            }
    }

    It 'routes field-based identities without mutation' {
        $identity = New-Object Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.RedisEnterpriseCacheIdentity
        $identity.SubscriptionId = 'field-sub'
        $identity.ResourceGroupName = 'field-rg'
        $identity.ClusterName = 'field-cache'
        $identity.DatabaseName = 'default'

        & $script:updateCommand -InputObject $identity

        Assert-MockCalled 'Az.RedisEnterpriseCache.internal\Get-AzRedisEnterpriseCacheDatabase' `
            -ModuleName 'Az.RedisEnterpriseCache.custom' `
            -Times 1 `
            -Exactly `
            -Scope It `
            -ParameterFilter {
                $ClusterName -eq 'field-cache' -and
                $ResourceGroupName -eq 'field-rg' -and
                $Name -eq 'default' -and
                $SubscriptionId -eq 'field-sub' -and
                $null -eq $RedisEnterpriseInputObject
            }
        $identity.SubscriptionId | Should -Be 'field-sub'
        $identity.ResourceGroupName | Should -Be 'field-rg'
        $identity.ClusterName | Should -Be 'field-cache'
        $identity.DatabaseName | Should -Be 'default'
    }

    It 'rejects malformed or wrong-resource IDs before calling GET or PUT' {
        foreach ($invalidId in @(
            '/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Cache/redis/cache',
            '/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Cache/redisEnterprise/cache/databases/default/databases/default')) {
            $identity = New-Object Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.RedisEnterpriseCacheIdentity
            $identity.Id = $invalidId

            $caughtException = $null
            try {
                & $script:updateCommand -InputObject $identity
            } catch {
                $caughtException = $_.Exception
            }

            $caughtException | Should -BeOfType ([System.Management.Automation.PSArgumentException])
        }

        Assert-MockCalled 'Az.RedisEnterpriseCache.internal\Get-AzRedisEnterpriseCacheDatabase' `
            -ModuleName 'Az.RedisEnterpriseCache.custom' `
            -Times 0 `
            -Exactly `
            -Scope It
        Assert-MockCalled 'Az.RedisEnterpriseCache.internal\New-AzRedisEnterpriseCacheDatabase' `
            -ModuleName 'Az.RedisEnterpriseCache.custom' `
            -Times 0 `
            -Exactly `
            -Scope It
    }
}
