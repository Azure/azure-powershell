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
    It 'CreateExpanded' -skip{
        $monitor = New-AzWorkloadsMonitor -ResourceGroupName PowerShell-CLI-TestRG -Name powershellmonitor09 -Location eastus2euap `
        -AppLocation eastus -ManagedResourceGroupName powershellmonitor09-mrg `
        -MonitorSubnet "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/PowerShell-CLI-TestRG/providers/Microsoft.Network/virtualNetworks/lucas-workloads-vnet/subnets/subnet03" `
        -RoutingPreference 'RouteAll' -ZoneRedundancyPreference Disabled
        $monitor.ProvisioningState | Should -Be "Succeeded"
    }
}
