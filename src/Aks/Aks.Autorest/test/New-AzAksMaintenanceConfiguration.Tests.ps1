if(($null -eq $TestName) -or ($TestName -contains 'New-AzAksMaintenanceConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAksMaintenanceConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAksMaintenanceConfiguration' {
    It 'CreateExpanded' {
        $MaintenanceConfigName = 'aks_maintenance_config'
        $TimeSpan = New-AzAksTimeSpanObject -Start (Get-Date -Year 2025 -Month 4 -Day 29) -End (Get-Date -Year 2025 -Month 5 -Day 2)
        $TimeInWeek = New-AzAksTimeInWeekObject -Day 'Sunday' -HourSlot 1,2
        $MaintenanceConfig = New-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName $MaintenanceConfigName -TimeInWeek $TimeInWeek -NotAllowedTime $TimeSpan
        
        $MaintenanceConfig.Name | Should -Be $MaintenanceConfigName
        $MaintenanceConfig.NotAllowedTime.Start.ToString("M-d-yyyy") | Should -Be '4-29-2025'
        $MaintenanceConfig.NotAllowedTime.End.ToString("M-d-yyyy") | Should -Be '5-2-2025'
        $MaintenanceConfig.TimeInWeek.Day | Should -Be 'Sunday'
        $MaintenanceConfig.TimeInWeek.HourSlot.Count | Should -Be 2
        $MaintenanceConfig.TimeInWeek.HourSlot.Contains(1) | Should -Be $true
        $MaintenanceConfig.TimeInWeek.HourSlot.Contains(2) | Should -Be $true

        Remove-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName $MaintenanceConfigName
    }
}
