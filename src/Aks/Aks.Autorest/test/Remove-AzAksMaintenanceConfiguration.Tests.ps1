if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAksMaintenanceConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAksMaintenanceConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAksMaintenanceConfiguration' {
    It 'Delete' {
        $MaintenanceConfigName = 'aksManagedAutoUpgradeSchedule'
        New-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName $MaintenanceConfigName -WeeklyDayOfWeek Friday -WeeklyIntervalWeek 2 -MaintenanceWindowStartTime 01:00 -MaintenanceWindowDurationHour 6
        Remove-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName $MaintenanceConfigName
    }

    It 'DeleteViaIdentity' {
        $MaintenanceConfigName = 'aksManagedAutoUpgradeSchedule'
        $MaintenanceConfig = New-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName $MaintenanceConfigName -WeeklyDayOfWeek Friday -WeeklyIntervalWeek 2 -MaintenanceWindowStartTime 01:00 -MaintenanceWindowDurationHour 6
        Remove-AzAksMaintenanceConfiguration -InputObject $MaintenanceConfig
    }
}
