if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzWorkloadsMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWorkloadsMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzWorkloadsMonitor' {
    It 'Delete' {
        $response = Remove-AzWorkloadsMonitor -Name $env.CreateHaMonitorName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId
        $response.Status | Should -Be $env.ProvisioningState
    }

    It 'DeleteViaIdentity' {
        $response = Remove-AzWorkloadsMonitor -InputObject "/subscriptions/$($env.WaaSSubscriptionId)/resourceGroups/$($env.MonitorRg)/providers/Microsoft.Workloads/monitors/$($env.HaMonitorName)"
        $response.Status | Should -Be $env.ProvisioningState
    }
}
