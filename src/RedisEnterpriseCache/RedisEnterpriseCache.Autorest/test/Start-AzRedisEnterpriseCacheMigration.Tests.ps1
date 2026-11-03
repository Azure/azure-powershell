if(($null -eq $TestName) -or ($TestName -contains 'Start-AzRedisEnterpriseCacheMigration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzRedisEnterpriseCacheMigration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzRedisEnterpriseCacheMigration' {
    It 'Runs the migration lifecycle' {
        $sourceResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Cache/redis/$($env.OssCacheName)"
        $startedMigration = Start-AzRedisEnterpriseCacheMigration -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroupName -SourceResourceId $sourceResourceId -ForceMigrate -SwitchDns -SkipDataMigration -Confirm:$false

        $startedMigration | Should -Not -Be $null
        $startedMigration.ProvisioningState | Should -Be "Succeeded"
        $startedMigration.SourceType | Should -Be "AzureCacheForRedis"
        $startedMigration.TargetResourceId | Should -Not -Be $null
        $startedMigration.Type | Should -Be "Microsoft.Cache/redisEnterprise/migrations"
        $startedMigration.CreationTime | Should -Not -Be $null

        $migration = Get-AzRedisEnterpriseCacheMigration -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroupName
        $migration.Id | Should -Be $startedMigration.Id
        $migration.ProvisioningState | Should -Be "Succeeded"
        $migration.SourceType | Should -Be "AzureCacheForRedis"

        $undone = Undo-AzRedisEnterpriseCacheMigration -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroupName -RollbackReason testing -PassThru
        $undone | Should -Be $true
    }
}
