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

Describe 'AzRedisEnterpriseCacheGeoReplication' {
    It 'Creates the first cache without a database' {
        $cache = New-AzRedisEnterpriseCache -Name $env.GeoPrimaryClusterName -ResourceGroupName $env.GeoResourceGroupName -Location $env.Location -SubscriptionId $env.SubscriptionId -Sku 'Balanced_B10' -NoDatabase -PublicNetworkAccess 'Enabled'
        $cache.Name | Should -Be $env.GeoPrimaryClusterName
        $cache.ProvisioningState | Should -Be 'Succeeded'
        $cache.ResourceState | Should -Be 'Running'
        $cache.Database.Count | Should -Be 0
    }

    It 'Creates the second cache with a replication-group database' {
        $linkedDatabase = "{id:`"/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.GeoResourceGroupName)/providers/Microsoft.Cache/redisEnterprise/$($env.GeoSecondaryClusterName)/databases/default`"}"
        $cache = New-AzRedisEnterpriseCache -Name $env.GeoSecondaryClusterName -ResourceGroupName $env.GeoResourceGroupName -Location $env.Location -SubscriptionId $env.SubscriptionId -Sku 'Balanced_B10' -ClientProtocol 'Encrypted' -ClusteringPolicy 'EnterpriseCluster' -EvictionPolicy 'NoEviction' -PublicNetworkAccess 'Enabled' -AccessKeysAuthentication 'Enabled' -GroupNickname 'GroupName' -LinkedDatabase $linkedDatabase -Module '{name:RediSearch}'
        $cache.Name | Should -Be $env.GeoSecondaryClusterName
        $cache.ProvisioningState | Should -Be 'Succeeded'
        $cache.ResourceState | Should -Be 'Running'
        $cache.Database['default'].GeoReplicationGroupNickname | Should -Be 'GroupName'
        $cache.Database['default'].GeoReplicationLinkedDatabase[0].Id | Should -Be "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.GeoResourceGroupName)/providers/Microsoft.Cache/redisEnterprise/$($env.GeoSecondaryClusterName)/databases/default"
    }

    It 'Adds the first cache database to the replication group' {
        $cluster3Id = "{id:`"/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.GeoResourceGroupName)/providers/Microsoft.Cache/redisEnterprise/$($env.GeoPrimaryClusterName)/databases/default`"}"
        $cluster4Id = "{id:`"/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.GeoResourceGroupName)/providers/Microsoft.Cache/redisEnterprise/$($env.GeoSecondaryClusterName)/databases/default`"}"
        $database = New-AzRedisEnterpriseCacheDatabase -Name $env.GeoPrimaryClusterName -ResourceGroupName $env.GeoResourceGroupName -SubscriptionId $env.SubscriptionId -ClientProtocol 'Encrypted' -ClusteringPolicy 'EnterpriseCluster' -EvictionPolicy 'NoEviction' -AccessKeysAuthentication 'Enabled' -GroupNickname 'GroupName' -LinkedDatabase @($cluster3Id, $cluster4Id) -Module '{name:RediSearch}'
        $database.Name | Should -Be 'default'
        $database.ProvisioningState | Should -Be 'Succeeded'
        $database.ResourceState | Should -Be 'Running'
        $database.GeoReplicationGroupNickname | Should -Be 'GroupName'
        $database.GeoReplicationLinkedDatabase[0].Id | Should -Be "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.GeoResourceGroupName)/providers/Microsoft.Cache/redisEnterprise/$($env.GeoPrimaryClusterName)/databases/default"
        $database.GeoReplicationLinkedDatabase[1].Id | Should -Be "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.GeoResourceGroupName)/providers/Microsoft.Cache/redisEnterprise/$($env.GeoSecondaryClusterName)/databases/default"
    }

    It 'Force unlinks the peer database' {
        $peerId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.GeoResourceGroupName)/providers/Microsoft.Cache/redisEnterprise/$($env.GeoSecondaryClusterName)/databases/default"
        {
            Invoke-AzRedisEnterpriseCacheForceDatabaseUnlink -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.GeoResourceGroupName -ClusterName $env.GeoPrimaryClusterName -Id @($peerId) -ErrorAction Stop
        } | Should -Not -Throw
    }
}
