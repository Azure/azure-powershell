if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminSchedule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminSchedule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminSchedule' {

    It 'Get' {
        $schedule = Get-AzDevCenterAdminSchedule -PoolName $env.poolName -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup
        $schedule.Frequency | Should -Be "Daily"
        $schedule.Name | Should -Be "default"
        $schedule.PropertiesType | Should -Be "StopDevBox"
        $schedule.State | Should -Be "Enabled"
        $schedule.Time | Should -Be "18:30"
        $schedule.TimeZone | Should -Be "America/Los_Angeles"
    }


    It 'GetViaIdentity' {
        $schedule = Get-AzDevCenterAdminSchedule -PoolName $env.poolName -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup
        $schedule = Get-AzDevCenterAdminSchedule -InputObject $schedule
        $schedule.Frequency | Should -Be "Daily"
        $schedule.Name | Should -Be "default"
        $schedule.PropertiesType | Should -Be "StopDevBox"
        $schedule.State | Should -Be "Enabled"
        $schedule.Time | Should -Be "18:30"
        $schedule.TimeZone | Should -Be "America/Los_Angeles"
    }
}
