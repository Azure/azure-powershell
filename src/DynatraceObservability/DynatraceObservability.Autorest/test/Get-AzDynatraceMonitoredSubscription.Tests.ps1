if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDynatraceMonitoredSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDynatraceMonitoredSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDynatraceMonitoredSubscription' {
    It 'Get parameter set (single monitored subscription)' {
        # The cmdlet exposes parameter sets: Get (MonitorName + ResourceGroupName) and GetViaIdentity (InputObject), List (MonitorName + ResourceGroupName)
        # There is no -MonitorInputObject or -ConfigurationName parameter; remove invalid usage.
        { Get-AzDynatraceMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01 } | Should -Not -Throw
    }

    It 'List parameter set (enumerates monitored subscriptions)' {
        $result = Get-AzDynatraceMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01
        $result | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentity parameter set' {
        # Obtain one monitored subscription object (first item) then pipe as identity
        $all = Get-AzDynatraceMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01
        $first = $all | Select-Object -First 1
        { $first | Get-AzDynatraceMonitoredSubscription } | Should -Not -Throw
    }
}
