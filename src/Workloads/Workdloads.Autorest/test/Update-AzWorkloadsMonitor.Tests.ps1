if(($null -eq $TestName) -or ($TestName -contains 'Update-AzWorkloadsMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWorkloadsMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzWorkloadsMonitor' {
    It 'UpdateExpanded' {
        $response = Update-AzWorkloadsMonitor -MonitorName $env.MonitorName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId -Tag @{name="suha"}
        $response.ProvisioningState | Should -Be "Succeeded"
    }

    It 'UpdateViaIdentityExpanded' {
        $monGetbyIdResponse = Update-AzWorkloadsMonitor -InputObject "/subscriptions/$($env.WaaSSubscriptionId)/resourceGroups/$($env.MonitorRg)/providers/Microsoft.Workloads/monitors/$($env.MonitorName)" -Tag @{name="suhaById"}
        $monGetbyIdResponse.ProvisioningState | Should -Be "Succeeded"
    }
}
