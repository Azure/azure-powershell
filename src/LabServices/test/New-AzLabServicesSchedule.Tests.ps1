if(($null -eq $TestName) -or ($TestName -contains 'New-AzLabServicesSchedule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzLabServicesSchedule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'New-AzLabServicesSchedule' {
    It 'Create' {
        $lab = Get-AzLabServicesLab -ResourceGroupName $ENV:ResourceGroupName -Name $ENV:LabName
        
        New-AzLabServicesSchedule `
            -Lab $lab `
            -Name $ENV:ScheduleNameSecond `
            -StartAt "$((Get-Date).AddHours(5))" `
            -StopAt "$((Get-Date).AddHours(6))" `
            -RecurrencePatternFrequency 'Weekly' `
            -RecurrencePatternInterval 1 `
            -RecurrencePatternWeekDay @($((Get-Date).DayOfWeek)) `
            -RecurrencePatternExpirationDate $((Get-Date).AddDays(20)) `
            -TimeZoneId 'America/Los_Angeles' | Should -Not -BeNullOrEmpty

        Get-AzLabServicesSchedule -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Name $ENV:ScheduleNameSecond | Should -Not -BeNullOrEmpty
    }
}