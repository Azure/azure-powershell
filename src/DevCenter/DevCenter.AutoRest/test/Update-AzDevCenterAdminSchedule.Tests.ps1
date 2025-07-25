if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDevCenterAdminSchedule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDevCenterAdminSchedule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDevCenterAdminSchedule' {
    It 'UpdateExpanded' {
        $schedule = New-AzDevCenterAdminSchedule -PoolName $env.scheduleUpdate -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -State "Disabled" -Time "17:30" -TimeZone "America/New_York"
        $schedule.Frequency | Should -Be "Daily"
        $schedule.Name | Should -Be "default"
        $schedule.PropertiesType | Should -Be "StopDevBox"
        $schedule.State | Should -Be "Disabled"
        $schedule.Time | Should -Be "17:30"
        $schedule.TimeZone | Should -Be "America/New_York"
        }

    It 'UpdateViaIdentityExpanded' {
        $scheduleInput = Get-AzDevCenterAdminSchedule -PoolName $env.scheduleUpdate -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup

        $schedule = New-AzDevCenterAdminSchedule -InputObject $scheduleInput -State "Disabled" -Time "17:30" -TimeZone "America/New_York"
        $schedule.Frequency | Should -Be "Daily"
        $schedule.Name | Should -Be "default"
        $schedule.PropertiesType | Should -Be "StopDevBox"
        $schedule.State | Should -Be "Disabled"
        $schedule.Time | Should -Be "17:30"
        $schedule.TimeZone | Should -Be "America/New_York"
        }

}
