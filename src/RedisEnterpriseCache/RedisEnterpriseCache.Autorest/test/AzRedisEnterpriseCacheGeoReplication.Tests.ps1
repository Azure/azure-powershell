$selectedTestNames = Get-SelectedTestNames
if (($selectedTestNames.Count -eq 0) -or ($selectedTestNames -contains 'AzRedisEnterpriseCacheGeoReplication'))
{
    $TestEnvironmentName = 'geo'
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-not (Test-Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . $loadEnvPath
    $TestRecordingFile = Join-Path $PSScriptRoot 'AzRedisEnterpriseCacheGeoReplication.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzRedisEnterpriseCacheGeoReplication' {
    It 'Creates the first cache without a database' {
        $cache = New-AzRedisEnterpriseCache -Name $env.ClusterName3 -ResourceGroupName $env.ResourceGroupName -Location $env.Location -SubscriptionId $env.SubscriptionId -Sku 'Balanced_B10' -NoDatabase -PublicNetworkAccess 'Enabled'
        $cache.Name | Should -Be $env.ClusterName3
        $cache.ProvisioningState | Should -Be 'Succeeded'
        $cache.ResourceState | Should -Be 'Running'
        $cache.Database.Count | Should -Be 0
    }

    It 'Creates the second cache with a replication-group database' {
        $linkedDatabase = "{id:`"/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Cache/redisEnterprise/$($env.ClusterName4)/databases/default`"}"
        $cache = New-AzRedisEnterpriseCache -Name $env.ClusterName4 -ResourceGroupName $env.ResourceGroupName -Location $env.Location -SubscriptionId $env.SubscriptionId -Sku 'Balanced_B10' -ClientProtocol 'Encrypted' -ClusteringPolicy 'EnterpriseCluster' -EvictionPolicy 'NoEviction' -PublicNetworkAccess 'Enabled' -AccessKeysAuthentication 'Enabled' -GroupNickname 'GroupName' -LinkedDatabase $linkedDatabase -Module '{name:RediSearch}'
        $cache.Name | Should -Be $env.ClusterName4
        $cache.ProvisioningState | Should -Be 'Succeeded'
        $cache.ResourceState | Should -Be 'Running'
        $cache.Database['default'].GeoReplicationGroupNickname | Should -Be 'GroupName'
        $cache.Database['default'].GeoReplicationLinkedDatabase[0].Id | Should -Be "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Cache/redisEnterprise/$($env.ClusterName4)/databases/default"
    }

    It 'Adds the first cache database to the replication group' {
        $cluster3Id = "{id:`"/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Cache/redisEnterprise/$($env.ClusterName3)/databases/default`"}"
        $cluster4Id = "{id:`"/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Cache/redisEnterprise/$($env.ClusterName4)/databases/default`"}"
        $database = New-AzRedisEnterpriseCacheDatabase -Name $env.ClusterName3 -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -ClientProtocol 'Encrypted' -ClusteringPolicy 'EnterpriseCluster' -EvictionPolicy 'NoEviction' -AccessKeysAuthentication 'Enabled' -GroupNickname 'GroupName' -LinkedDatabase ($cluster3Id,$cluster4Id -join ',')
        $database.Name | Should -Be 'default'
        $database.ProvisioningState | Should -Be 'Succeeded'
        $database.ResourceState | Should -Be 'Running'
        $database.GeoReplicationGroupNickname | Should -Be 'GroupName'
        $database.GeoReplicationLinkedDatabase[0].Id | Should -Be "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Cache/redisEnterprise/$($env.ClusterName3)/databases/default"
    }

    It 'Force unlinks the peer database' {
        $peerId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Cache/redisEnterprise/$($env.ClusterName4)/databases/default"
        {
            Invoke-AzRedisEnterpriseCacheForceDatabaseUnlink -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -ClusterName $env.ClusterName3 -Id @($peerId) -ErrorAction Stop
        } | Should -Not -Throw
    }
}
