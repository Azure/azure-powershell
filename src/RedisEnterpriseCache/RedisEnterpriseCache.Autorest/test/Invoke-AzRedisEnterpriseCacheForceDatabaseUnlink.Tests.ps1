if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzRedisEnterpriseCacheForceDatabaseUnlink'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzRedisEnterpriseCacheForceDatabaseUnlink.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzRedisEnterpriseCacheForceDatabaseUnlink' {
    $id = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Cache/redisEnterprise/{2}/databases/default" -f $env.SubscriptionId,$env.ResourceGroupName,$env.ClusterName4
    It 'Force unlink database from group' {
        $splat = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.ResourceGroupName
            ClusterName = $env.ClusterName3
            Id = @($id)
        }
        $database = Invoke-AzRedisEnterpriseCacheForceDatabaseUnlink @splat
    }
}
