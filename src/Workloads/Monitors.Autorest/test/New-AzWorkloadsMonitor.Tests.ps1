if(($null -eq $TestName) -or ($TestName -contains 'New-AzWorkloadsMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWorkloadsMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWorkloadsMonitor' {
    It 'CreateMonitorExpanded' {
        $monitor = New-AzWorkloadsMonitor -ResourceGroupName $env.MonitorRg -Name $env.CreateMonitorName -Location eastus2euap `
        -AppLocation eastus -ManagedResourceGroupName mrg-170313 `
        -MonitorSubnet $env.MonitorSubnet `
        -RoutingPreference 'RouteAll' -ZoneRedundancyPreference Disabled
        $monitor.ProvisioningState | Should -Be "Succeeded"
    }

    It 'CreateHaMonitorExpanded' {
        $monitorHa = New-AzWorkloadsMonitor -ResourceGroupName $env.MonitorRg -Name $env.CreateHaMonitorName -Location eastus2euap `
        -AppLocation eastus -ManagedResourceGroupName mrg-1703133 `
        -MonitorSubnet $env.HaMonitorSubnet `
        -RoutingPreference 'RouteAll' -ZoneRedundancyPreference Disabled
        $monitorHa.ProvisioningState | Should -Be "Succeeded"
    }
}
