if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzWorkloadsSapLandscapeMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWorkloadsSapLandscapeMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzWorkloadsSapLandscapeMonitor' {
    It 'Delete' {
        Remove-AzWorkloadsSapLandscapeMonitor -MonitorName $env.MonitorName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId
    }

    It 'DeleteViaIdentity' {
        Remove-AzWorkloadsSapLandscapeMonitor -InputObject "/subscriptions/$($env.WaaSSubscriptionId)/resourceGroups/$($env.MonitorRg)/providers/Microsoft.Workloads/monitors/$($env.CreateMonitorName)/sapLandscapeMonitor/default"
    }
}
