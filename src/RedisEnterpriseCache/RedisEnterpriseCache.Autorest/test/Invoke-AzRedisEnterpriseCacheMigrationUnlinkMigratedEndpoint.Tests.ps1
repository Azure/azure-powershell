$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzRedisEnterpriseCacheMigrationUnlinkMigratedEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzRedisEnterpriseCacheMigrationUnlinkMigratedEndpoint' {
    It 'Unlinks a migrated Azure Cache for Redis endpoint' {
        $sourceResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.MigrationUnlinkResourceGroupName)/providers/Microsoft.Cache/redis/$($env.MigrationUnlinkOssCacheName)"
        $migration = Start-AzRedisEnterpriseCacheMigration -ClusterName $env.MigrationUnlinkClusterName -ResourceGroupName $env.MigrationUnlinkResourceGroupName -SourceResourceId $sourceResourceId -ForceMigrate -SwitchDns -SkipDataMigration -Confirm:$false
        $migration.ProvisioningState | Should -Be "Succeeded"

        if ($TestMode -ne 'playback') {
            Remove-AzRedisCache -ResourceGroupName $env.MigrationUnlinkResourceGroupName -Name $env.MigrationUnlinkOssCacheName -Force
        }

        $result = Invoke-AzRedisEnterpriseCacheMigrationUnlinkMigratedEndpoint -ClusterName $env.MigrationUnlinkClusterName -ResourceGroupName $env.MigrationUnlinkResourceGroupName -PassThru -Confirm:$false
        $result | Should -Be $true
    }
}
