if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWorkloadsMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWorkloadsMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}
Describe 'Get-AzWorkloadsMonitor' {
    It 'ListBySubscription'{ 
            Get-AzWorkloadsMonitor -SubscriptionId $env.WaaSSubscriptionId
        }

    It 'Get' {
        $monGetResponse = Get-AzWorkloadsMonitor -Name $env.MonitorName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId
        $monGetResponse.Name | Should -Be $env.MonitorName
    }

    It 'ListByRg' {
        $monListByRgResponse = Get-AzWorkloadsMonitor -ResourceGroupName $env.MonitorRg
        $monListByRgResponse.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ListByArmId' {
        $monGetbyIdResponse = Get-AzWorkloadsMonitor -InputObject "/subscriptions/$($env.WaaSSubscriptionId)/resourceGroups/$($env.MonitorRg)/providers/Microsoft.Workloads/monitors/$($env.MonitorName)"
        $monGetbyIdResponse.Name | Should -Be $env.MonitorName
    }
}
