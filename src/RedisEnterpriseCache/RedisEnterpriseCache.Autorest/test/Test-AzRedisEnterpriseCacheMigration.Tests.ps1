$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzRedisEnterpriseCacheMigration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzRedisEnterpriseCacheMigration' {
    It 'Reports a clustering warning for a non-clustered source' {
        $sourceResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.MigrationValidateResourceGroupName)/providers/Microsoft.Cache/redis/$($env.MigrationValidateOssCacheName)"
        $result = Test-AzRedisEnterpriseCacheMigration -ClusterName $env.MigrationValidateClusterName -ResourceGroupName $env.MigrationValidateResourceGroupName -SourceResourceId $sourceResourceId -SkipDataMigration -Confirm:$false

        $result | Should -Not -Be $null
        $result.IsValid | Should -Be $false

        $errors = @($result.Error | ForEach-Object { @($_.Disparity) })
        $errors.Count | Should -Be 0

        $warnings = @($result.Warning | ForEach-Object { @($_.Disparity) })
        $warnings.Count | Should -Be 1
        $warnings[0].Category | Should -Be 'Clustering Mode'
        $warnings[0].Message | Should -Match 'cluster-aware'
    }
}
