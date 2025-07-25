$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRedisEnterpriseCacheKey.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzRedisEnterpriseCacheKey' {
    It 'Regenerate' {
        $splat = @{
            Name = $env.ClusterName
            ResourceGroupName = $env.ResourceGroupName
            KeyType = "Primary"
        }
        $databaseKeys = New-AzRedisEnterpriseCacheKey @splat
        $databaseKeys.PrimaryKey | Should -Not -Be $null
        $databaseKeys.SecondaryKey | Should -Not -Be $null

        $splat = @{
            Name = $env.ClusterName
            ResourceGroupName = $env.ResourceGroupName
            KeyType = "Secondary"
        }
        $databaseKeys = New-AzRedisEnterpriseCacheKey @splat
        $databaseKeys.PrimaryKey | Should -Not -Be $null
        $databaseKeys.SecondaryKey | Should -Not -Be $null
    }
}
