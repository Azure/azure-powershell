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
        $MaintenanceConfigName = 'aksManagedAutoUpgradeSchedule'
        $MaintenanceConfig = New-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName $MaintenanceConfigName -WeeklyDayOfWeek Friday -WeeklyIntervalWeek 2 -MaintenanceWindowStartTime 01:00 -MaintenanceWindowDurationHour 6
        
        $MaintenanceConfig.Name | Should -Be $MaintenanceConfigName
        $MaintenanceConfig.WeeklyDayOfWeek | Should -Be 'Friday'
        $MaintenanceConfig.WeeklyIntervalWeek | Should -Be 2
        $MaintenanceConfig.MaintenanceWindowDurationHour | Should -Be 6

        Remove-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName $MaintenanceConfigName
    }
}
