if(($null -eq $TestName) -or ($TestName -contains 'Start-AzDevCenterAdminNetworkConnectionHealthCheck'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzDevCenterAdminNetworkConnectionHealthCheck.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzDevCenterAdminNetworkConnectionHealthCheck' {
    It 'Run' {
        Start-AzDevCenterAdminNetworkConnectionHealthCheck -NetworkConnectionName $env.networkConnectionName -ResourceGroupName $env.resourceGroup
    }

    It 'RunViaIdentity' {
        Start-AzDevCenterAdminNetworkConnectionHealthCheck -InputObject @{"NetworkConnectionName" = $env.networkConnectionName; "ResourceGroupName" = $env.resourceGroup; "SubscriptionId" = $env.SubscriptionId}
    }
}
