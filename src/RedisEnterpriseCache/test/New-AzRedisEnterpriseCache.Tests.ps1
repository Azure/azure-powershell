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
            Zone = @("1", "2", "3")
            ClientProtocol = "Encrypted"
            ClusteringPolicy = "OSSCluster"
            EvictionPolicy = "VolatileLRU"
        }
        $cache = New-AzRedisEnterpriseCache @splat
        $cache.Name | Should -Be $splat.Name
        $cache.Location | Should -Be $splat.Location
        $cache.SkuName | Should -Be $splat.Sku
        $cache.SkuCapacity | Should -Be $splat.Capacity
        $cache.Type | Should -Be "Microsoft.Cache/redisEnterprise"
        $cache.ProvisioningState | Should -Be "Succeeded"
        $cache.ResourceState | Should -Be "Running"
        $cache.Zone | Should -Be $splat.Zone
        $databaseName = "default"
        $cache.Database[$databaseName].Name | Should -Be $databaseName
        $cache.Database[$databaseName].Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"
        $cache.Database[$databaseName].ClientProtocol | Should -Be $splat.ClientProtocol
        $cache.Database[$databaseName].ClusteringPolicy | Should -Be $splat.ClusteringPolicy
        $cache.Database[$databaseName].EvictionPolicy | Should -Be $splat.EvictionPolicy
        $cache.Database[$databaseName].ProvisioningState | Should -Be "Succeeded"
        $cache.Database[$databaseName].ResourceState | Should -Be "Running"
    }
}
