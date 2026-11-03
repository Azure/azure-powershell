if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzRedisEnterpriseCacheUnlinkClusterMigratedEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzRedisEnterpriseCacheUnlinkClusterMigratedEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzRedisEnterpriseCacheUnlinkClusterMigratedEndpoint' {
    It 'Unlinks an endpoint after an ACRE to AMR migration' {
        $cache = Update-AzRedisEnterpriseCache -Name $env.ClusterName -ResourceGroupName $env.ResourceGroupName -Sku "Balanced_B1" -Tag @{"amr-migration-data-preserve" = "false"}

        $cache.SkuName | Should -Be "Balanced_B1"
        $cache.ProvisioningState | Should -Be "Succeeded"
        $cache.MigratedEndpoint | Should -Not -BeNullOrEmpty

        $result = Invoke-AzRedisEnterpriseCacheUnlinkClusterMigratedEndpoint -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroupName -PassThru -Confirm:$false
        $result | Should -Be $true
    }
}
