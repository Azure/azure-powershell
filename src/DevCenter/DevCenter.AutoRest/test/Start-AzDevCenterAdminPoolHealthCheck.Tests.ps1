if(($null -eq $TestName) -or ($TestName -contains 'Start-AzDevCenterAdminPoolHealthCheck'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzDevCenterAdminPoolHealthCheck.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzDevCenterAdminPoolHealthCheck' {
    It 'Run' {
        Start-AzDevCenterAdminPoolHealthCheck -PoolName $env.poolName -ProjectName $env.projectName -ResourceGroupName $env.resourceGroupName10 -SubscriptionId $env.SubscriptionId2
        }

    It 'RunViaIdentity' {
        Start-AzDevCenterAdminPoolHealthCheck -InputObject @{"PoolName" = $env.poolName; "ProjectName" = $env.projectName; "ResourceGroupName" = $env.resourceGroupName10; "SubscriptionId" = $env.SubscriptionId2}
    }
}
