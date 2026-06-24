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
    It 'StartMigrationWithFriendlyParams' {
        $sourceResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Cache/redis/$($env.OssCacheName)"
        $result = Start-AzRedisEnterpriseCacheMigration -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroupName -SourceResourceId $sourceResourceId -SwitchDns -SkipDataMigration -ForceMigrate -Confirm:$false
        $result.ProvisioningState | Should -Be "Succeeded"
        $result.SourceType | Should -Be "AzureCacheForRedis"
        $result.TargetResourceId | Should -Not -BeNullOrEmpty
        $result.Type | Should -Be "Microsoft.Cache/redisEnterprise/migrations"
    }
}
