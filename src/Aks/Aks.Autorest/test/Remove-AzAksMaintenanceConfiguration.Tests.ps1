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
        $MaintenanceConfigName = 'aks_maintenance_config'
        $TimeInWeek = New-AzAksTimeInWeekObject -Day 'Sunday' -HourSlot 1,2
        $MaintenanceConfig = New-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName $MaintenanceConfigName -TimeInWeek $TimeInWeek
        Remove-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName $MaintenanceConfigName
    }

    It 'DeleteViaIdentity' {
        $MaintenanceConfigName = 'aks_maintenance_config'
        $TimeInWeek = New-AzAksTimeInWeekObject -Day 'Sunday' -HourSlot 1,2
        $MaintenanceConfig = New-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName $MaintenanceConfigName -TimeInWeek $TimeInWeek
        Remove-AzAksMaintenanceConfiguration -InputObject $MaintenanceConfig
    }
}
