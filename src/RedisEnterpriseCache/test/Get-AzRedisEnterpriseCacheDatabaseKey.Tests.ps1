$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRedisEnterpriseCacheDatabaseKey.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzRedisEnterpriseCacheDatabaseKey' {
    It 'List' {
        $splat = @{
            Name = $env.ClusterName
            ResourceGroupName = $env.ResourceGroupName
        }
        $databaseKeys = Get-AzRedisEnterpriseCacheDatabaseKey @splat
        $databaseKeys.PrimaryKey | Should -Not -Be $null
        # TODO: uncomment the following line when listKeys supports returning the SecondaryKey
        #$databaseKeys.SecondaryKey | Should -Not -Be $null
    }
}
