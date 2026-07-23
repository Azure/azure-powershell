if(($null -eq $TestName) -or ($TestName -contains 'Update-AzAksMaintenanceConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzAksMaintenanceConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzAksMaintenanceConfiguration' {
    It 'UpdateExpanded' {
        $MaintenanceConfigName = 'aksManagedAutoUpgradeSchedule'
        $MaintenanceConfig = New-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName $MaintenanceConfigName -WeeklyDayOfWeek Friday -WeeklyIntervalWeek 2 -MaintenanceWindowStartTime 01:00 -MaintenanceWindowDurationHour 6
        
        $MaintenanceConfig = Update-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName $MaintenanceConfigName -WeeklyDayOfWeek Sunday -WeeklyIntervalWeek 3 -MaintenanceWindowDurationHour 8

        $MaintenanceConfig.Name | Should -Be $MaintenanceConfigName
        $MaintenanceConfig.WeeklyDayOfWeek | Should -Be 'Sunday'
        $MaintenanceConfig.WeeklyIntervalWeek | Should -Be 3
        $MaintenanceConfig.MaintenanceWindowDurationHour | Should -Be 8

        Remove-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName $MaintenanceConfigName
    }
}
