if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWorkloadsSapLandscapeMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWorkloadsSapLandscapeMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWorkloadsSapLandscapeMonitor' {
    It 'Get' {
        $response = Get-AzWorkloadsSapLandscapeMonitor -MonitorName $env.MonitorName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId
        $response.GroupingLandscape.Name | Should -Be "NonProd"
    }

    It 'GetViaIdentity' {
        $response = Get-AzWorkloadsSapLandscapeMonitor -InputObject "/subscriptions/$($env.WaaSSubscriptionId)/resourceGroups/$($env.MonitorRg)/providers/Microsoft.Workloads/monitors/$($env.MonitorName)/sapLandscapeMonitor/default"
        $response.GroupingLandscape.Name | Should -Be "NonProd"
    }
}
