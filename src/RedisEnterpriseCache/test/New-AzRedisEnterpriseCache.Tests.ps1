$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRedisEnterpriseCache.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzRedisEnterpriseCache' {
    It 'Create' {
        $splat = @{
            Name = $env.ClusterName
            ResourceGroupName = $env.ResourceGroupName
            Location = $env.Location
            SubscriptionId = $env.SubscriptionId
            Sku = "Enterprise_E10"
            Capacity = 2
            Zones = @("1", "2", "3")
            ClientProtocol = "Encrypted"
            ClusteringPolicy = "OSSCluster"
            EvictionPolicy = "VolatileLRU"
        }
        $cache = New-AzRedisEnterpriseCache @splat
        $cache.Name | Should -Be @($splat.Name, "default")
        $cache.Location | Should -Be $splat.Location
        $cache.SkuName | Should -Be $splat.Sku
        $cache.SkuCapacity | Should -Be $splat.Capacity
        $cache.Type | Should -Be @("Microsoft.Cache/redisEnterprise", "Microsoft.Cache/redisEnterprise/databases")
        $cache.ProvisioningState | Should -Be @("Succeeded", "Succeeded")
        $cache.ResourceState | Should -Be @("Running", "Running")
        $cache.Zone | Should -Be $splat.Zones
        $cache.ClientProtocol | Should -Be $splat.ClientProtocol
        $cache.ClusteringPolicy | Should -Be $splat.ClusteringPolicy
        $cache.EvictionPolicy | Should -Be $splat.EvictionPolicy
    }
}
