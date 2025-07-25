$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRedisEnterpriseCache.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzRedisEnterpriseCache' {
    It 'Get' {
        $splat = @{
            Name = $env.ClusterName
            ResourceGroupName = $env.ResourceGroupName
        }
        $cache = Get-AzRedisEnterpriseCache @splat
        $cache.Name | Should -Be $splat.Name
        $cache.Location = $cache.Location.ToLower() -replace '\s', ''
        $cache.Location | Should -Be $env.Location
        $cache.Type | Should -Be "Microsoft.Cache/redisEnterprise"
        $databaseName = "default"
        $cache.Database.Count | Should -Be 1
        $cache.Database[$databaseName].Name | Should -Be $databaseName
        $cache.Database[$databaseName].Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"
    }

    It 'ListByResourceGroup' {
        $splat = @{
            ResourceGroupName = $env.ResourceGroupName
        }
        $caches = Get-AzRedisEnterpriseCache @splat
        $databaseName = "default"

        $caches[0].Location = $caches[0].Location.ToLower() -replace '\s', ''
        $caches[0].Location | Should -Be $env.Location
        $caches[0].Type | Should -Be "Microsoft.Cache/redisEnterprise"
        $caches[0].Database.Count | Should -Be 1
        $caches[0].Database[$databaseName].Name | Should -Be $databaseName
        $caches[0].Database[$databaseName].Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"

        $caches[1].Location = $caches[1].Location.ToLower() -replace '\s', ''
        $caches[1].Location | Should -Be $env.Location
        $caches[1].Type | Should -Be "Microsoft.Cache/redisEnterprise"
        $caches[1].Database.Count | Should -Be 1
        $caches[1].Database[$databaseName].Name | Should -Be $databaseName
        $caches[1].Database[$databaseName].Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"
    }

    It 'ListBySubscriptionId' {
        $null = Get-AzRedisEnterpriseCache
    }
}
