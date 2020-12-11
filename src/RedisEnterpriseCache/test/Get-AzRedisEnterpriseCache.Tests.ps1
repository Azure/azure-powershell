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
        $cache.Location | Should -Be $env.Location
        $cache.Type | Should -Be "Microsoft.Cache/redisEnterprise"
        $databaseName = "default"
        $cache.Database[$databaseName].Name | Should -Be $databaseName
        $cache.Database[$databaseName].Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"
    }

    It 'List' {
        $splat = @{
            ResourceGroupName = $env.ResourceGroupName
        }
        $cache = Get-AzRedisEnterpriseCache @splat
        $cache.Name | Should -Be $env.ClusterName
        $cache.Location | Should -Be $env.Location
        $cache.Type | Should -Be "Microsoft.Cache/redisEnterprise"
        $databaseName = "default"
        $cache.Database[$databaseName].Name | Should -Be $databaseName
        $cache.Database[$databaseName].Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"
    }
}
