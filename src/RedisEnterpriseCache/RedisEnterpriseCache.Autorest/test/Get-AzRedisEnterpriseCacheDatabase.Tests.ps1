$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRedisEnterpriseCacheDatabase.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzRedisEnterpriseCacheDatabase' {
    It 'List' {
        $splat = @{
            Name = $env.ClusterName
            ResourceGroupName = $env.ResourceGroupName
        }
        $databases = Get-AzRedisEnterpriseCacheDatabase @splat
        $databases.Count | Should -Be 1
        $databases[0].Name | Should -Be "default"
        $databases[0].Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"

        $splat2 = @{
            Name = $env.ClusterName2
            ResourceGroupName = $env.ResourceGroupName
        }
        $databases2 = Get-AzRedisEnterpriseCacheDatabase @splat2
        $databases2.Count | Should -Be 1
        $databases2[0].Name | Should -Be "default"
        $databases2[0].Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"
    }
}
