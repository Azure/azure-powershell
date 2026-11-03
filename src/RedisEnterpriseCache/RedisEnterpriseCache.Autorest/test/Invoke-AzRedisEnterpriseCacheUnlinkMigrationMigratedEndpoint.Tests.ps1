if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzRedisEnterpriseCacheUnlinkMigrationMigratedEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzRedisEnterpriseCacheUnlinkMigrationMigratedEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzRedisEnterpriseCacheUnlinkMigrationMigratedEndpoint' {
    It 'Unlinks a migrated Azure Cache for Redis endpoint' {
        $sourceResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Cache/redis/$($env.OssCacheName)"
        $migration = Start-AzRedisEnterpriseCacheMigration -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroupName -SourceResourceId $sourceResourceId -ForceMigrate -SwitchDns -SkipDataMigration -Confirm:$false
        $migration.ProvisioningState | Should -Be "Succeeded"

        if ($TestMode -ne 'playback') {
            Remove-AzRedisCache -ResourceGroupName $env.ResourceGroupName -Name $env.OssCacheName -Force
        }

        $result = Invoke-AzRedisEnterpriseCacheUnlinkMigrationMigratedEndpoint -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroupName -PassThru -Confirm:$false
        $result | Should -Be $true
    }
}
