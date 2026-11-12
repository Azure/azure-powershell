$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-not (Test-Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. $loadEnvPath
$TestRecordingFile = Join-Path $PSScriptRoot 'AzRedisEnterpriseCacheClusterLifecycle.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzRedisEnterpriseCacheClusterLifecycle' {
    It 'Creates a cache with database features' {
        $splat = @{
            Name = $env.ClusterLifecycleClusterName
            ResourceGroupName = $env.ClusterLifecycleResourceGroupName
            Location = $env.Location
            SubscriptionId = $env.SubscriptionId
            Sku = 'Balanced_B10'
            MinimumTlsVersion = '1.2'
            ClientProtocol = 'Encrypted'
            ClusteringPolicy = 'OSSCluster'
            EvictionPolicy = 'VolatileLRU'
            PublicNetworkAccess = 'Enabled'
            FirewallRule = @(
                @{Name='initial-rule'; SourceAddressPrefix='203.0.113.0/24'}
            )
            AccessKeysAuthentication = 'Enabled'
            NotifyKeyspaceEvents = 'KEA'
            MaintenanceConfigurationMaintenanceWindow = @(
                @{Type='Weekly'; ScheduleDayOfWeek='Monday'; StartHourUtc=6; Duration='PT10H'}
                @{Type='Weekly'; ScheduleDayOfWeek='Thursday'; StartHourUtc=6; Duration='PT10H'}
            )
        }
        $cache = New-AzRedisEnterpriseCache @splat -EnableSystemAssignedIdentity -Module '{name:RedisTimeSeries, args:"RETENTION_POLICY 20"}','{name:RedisBloom, args:"ERROR_RATE 0.001 INITIAL_SIZE 400"}'

        $cache.Name | Should -Be $splat.Name
        ($cache.Location.ToLower() -replace '\s', '') | Should -Be $splat.Location
        $cache.SkuName | Should -Be $splat.Sku
        $cache.Type | Should -Be 'Microsoft.Cache/redisEnterprise'
        $cache.ProvisioningState | Should -Be 'Succeeded'
        $cache.ResourceState | Should -Be 'Running'
        $cache.Database.Count | Should -Be 1
        $cache.Database['default'].Name | Should -Be 'default'
        $cache.Database['default'].Type | Should -Be 'Microsoft.Cache/redisEnterprise/databases'
        $cache.Database['default'].ClientProtocol | Should -Be $splat.ClientProtocol
        $cache.Database['default'].ClusteringPolicy | Should -Be $splat.ClusteringPolicy
        $cache.Database['default'].EvictionPolicy | Should -Be $splat.EvictionPolicy
        $cache.Database['default'].ProvisioningState | Should -Be 'Succeeded'
        $cache.Database['default'].ResourceState | Should -Be 'Running'
        $cache.Database['default'].NotifyKeyspaceEvents | Should -Be $splat.NotifyKeyspaceEvents
        $cache.IdentityType | Should -Be 'SystemAssigned'
        @($cache.FirewallRule).Count | Should -Be 1
        $cache.FirewallRule[0].Name | Should -Be 'initial-rule'
        $cache.FirewallRule[0].SourceAddressPrefix | Should -Be '203.0.113.0/24'
        $cache.MaintenanceConfigurationMaintenanceWindow.Count | Should -Be 2
        $cache.MaintenanceConfigurationMaintenanceWindow[0].ScheduleDayOfWeek | Should -Be 'Monday'
        $cache.MaintenanceConfigurationMaintenanceWindow[0].StartHourUtc | Should -Be 6
        $cache.MaintenanceConfigurationMaintenanceWindow[0].Duration | Should -Be 'PT10H'
        $cache.MaintenanceConfigurationMaintenanceWindow[1].ScheduleDayOfWeek | Should -Be 'Thursday'
        $cache.MaintenanceConfigurationMaintenanceWindow[1].StartHourUtc | Should -Be 6
    }

    It 'Lists supported SKUs' {
        $skus = Get-AzRedisEnterpriseCacheSku -ClusterName $env.ClusterLifecycleClusterName -ResourceGroupName $env.ClusterLifecycleResourceGroupName
        $skus | Should -Not -Be $null
        @($skus.Name) | Should -Contain 'Balanced_B250'
        @($skus.Name) | Should -Contain 'Balanced_B50'
        @($skus.SizeInGb) | Should -Contain 24
    }

    It 'Updates identity and maintenance windows' {
        $cache = Update-AzRedisEnterpriseCache -Name $env.ClusterLifecycleClusterName -ResourceGroupName $env.ClusterLifecycleResourceGroupName -EnableSystemAssignedIdentity $false
        $cache.IdentityType | Should -Be 'None'

        $windows = @(
            @{Type='Weekly'; ScheduleDayOfWeek='Wednesday'; StartHourUtc=10; Duration='PT10H'}
            @{Type='Weekly'; ScheduleDayOfWeek='Saturday'; StartHourUtc=10; Duration='PT10H'}
        )
        $cache = Update-AzRedisEnterpriseCache -Name $env.ClusterLifecycleClusterName -ResourceGroupName $env.ClusterLifecycleResourceGroupName -MaintenanceConfigurationMaintenanceWindow $windows
        $cache.MaintenanceConfigurationMaintenanceWindow.Count | Should -Be 2
        $cache.MaintenanceConfigurationMaintenanceWindow[0].ScheduleDayOfWeek | Should -Be 'Wednesday'
        $cache.MaintenanceConfigurationMaintenanceWindow[0].StartHourUtc | Should -Be 10
    }

    It 'Replaces and clears firewall rules' {
        $rules = @(
            @{Name='replacement-rule'; SourceAddressPrefix='AzureCloud'}
        )
        $cache = Update-AzRedisEnterpriseCache -Name $env.ClusterLifecycleClusterName -ResourceGroupName $env.ClusterLifecycleResourceGroupName -FirewallRule $rules
        @($cache.FirewallRule).Count | Should -Be 1
        $cache.FirewallRule[0].Name | Should -Be 'replacement-rule'
        $cache.FirewallRule[0].SourceAddressPrefix | Should -Be 'AzureCloud'

        $cache = Update-AzRedisEnterpriseCache -Name $env.ClusterLifecycleClusterName -ResourceGroupName $env.ClusterLifecycleResourceGroupName -FirewallRule @()
        @($cache.FirewallRule).Count | Should -Be 0
    }

    It 'Gets and lists the cache' {
        $cache = Get-AzRedisEnterpriseCache -Name $env.ClusterLifecycleClusterName -ResourceGroupName $env.ClusterLifecycleResourceGroupName
        $cache.Name | Should -Be $env.ClusterLifecycleClusterName
        ($cache.Location.ToLower() -replace '\s', '') | Should -Be $env.Location
        $cache.Type | Should -Be 'Microsoft.Cache/redisEnterprise'
        $cache.Database.Count | Should -Be 1
        $cache.Database['default'].Name | Should -Be 'default'

        $resourceGroupCaches = @(Get-AzRedisEnterpriseCache -ResourceGroupName $env.ClusterLifecycleResourceGroupName)
        $matchingCache = @($resourceGroupCaches | Where-Object Name -eq $env.ClusterLifecycleClusterName)
        $matchingCache.Count | Should -Be 1
        $matchingCache[0].Type | Should -Be 'Microsoft.Cache/redisEnterprise'

        @(Get-AzRedisEnterpriseCache).Count | Should -BeGreaterThan 0
    }

    It 'Gets the database and keys' {
        $databases = @(Get-AzRedisEnterpriseCacheDatabase -Name $env.ClusterLifecycleClusterName -ResourceGroupName $env.ClusterLifecycleResourceGroupName)
        $databases.Count | Should -Be 1
        $databases[0].Name | Should -Be 'default'
        $databases[0].Type | Should -Be 'Microsoft.Cache/redisEnterprise/databases'

        $keys = Get-AzRedisEnterpriseCacheKey -Name $env.ClusterLifecycleClusterName -ResourceGroupName $env.ClusterLifecycleResourceGroupName
        $keys.PrimaryKey | Should -Not -Be $null
        $keys.SecondaryKey | Should -Not -Be $null
    }

    It 'Creates and removes an access policy assignment' {
        $assignment = New-AzRedisEnterpriseCacheAccessPolicyAssignment -AccessPolicyAssignmentName testPolicy -ClusterName $env.ClusterLifecycleClusterName -DatabaseName default -ResourceGroupName $env.ClusterLifecycleResourceGroupName -UserObjectId '5dce0ce9-f0a7-437f-aea2-760d05c62ca9' -AccessPolicyName default
        $assignment.Name | Should -Be 'testPolicy'
        $assignment.ProvisioningState | Should -Be 'Succeeded'

        {
            Remove-AzRedisEnterpriseCacheAccessPolicyAssignment -AccessPolicyAssignmentName testPolicy -ClusterName $env.ClusterLifecycleClusterName -DatabaseName default -ResourceGroupName $env.ClusterLifecycleResourceGroupName
        } | Should -Not -Throw
    }

    It 'Regenerates both access keys' {
        foreach ($keyType in 'Primary', 'Secondary') {
            $keys = New-AzRedisEnterpriseCacheKey -Name $env.ClusterLifecycleClusterName -ResourceGroupName $env.ClusterLifecycleResourceGroupName -KeyType $keyType
            $keys.PrimaryKey | Should -Not -Be $null
            $keys.SecondaryKey | Should -Not -Be $null
        }
    }

    It 'Deletes the cache' {
        {
            Remove-AzRedisEnterpriseCache -Name $env.ClusterLifecycleClusterName -ResourceGroupName $env.ClusterLifecycleResourceGroupName
        } | Should -Not -Throw
    }
}
