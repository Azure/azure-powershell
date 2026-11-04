if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzRedisEnterpriseCacheClusterUnlinkMigratedEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzRedisEnterpriseCacheClusterUnlinkMigratedEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzRedisEnterpriseCacheClusterUnlinkMigratedEndpoint' {
    It 'Unlinks an endpoint after an ACRE to AMR migration' {
        $cache = Update-AzRedisEnterpriseCache -Name $env.ClusterName -ResourceGroupName $env.ResourceGroupName -Sku "Balanced_B1" -Tag @{"amr-migration-data-preserve" = "false"}

        $cache.SkuName | Should -Be "Balanced_B1"
        $cache.ProvisioningState | Should -Be "Succeeded"
        $cache.HostName | Should -Match '\.redis\.azure\.net$'
        $cache.MigratedEndpoint | Should -Match '\.redisenterprise\.cache\.azure\.net:10000$'

        $result = Invoke-AzRedisEnterpriseCacheClusterUnlinkMigratedEndpoint -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroupName -PassThru -Confirm:$false
        $result | Should -Be $true
    }
}
