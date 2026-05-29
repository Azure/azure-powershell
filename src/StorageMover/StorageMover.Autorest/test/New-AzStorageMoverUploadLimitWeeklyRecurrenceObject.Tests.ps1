if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMoverUploadLimitWeeklyRecurrenceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverUploadLimitWeeklyRecurrenceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageMoverUploadLimitWeeklyRecurrenceObject' {
    It '__AllParameterSets' {
        $recurrence = New-AzStorageMoverUploadLimitWeeklyRecurrenceObject -Day 'Monday','Tuesday','Friday' -LimitInMbps 100 -EndTimeHour 5 -StartTimeHour 1 -StartTimeMinute 30 -EndTimeMinute 0
        $recurrence.Day | Should -Contain 'Monday'
        $recurrence.Day | Should -Contain 'Tuesday'
        $recurrence.Day | Should -Contain 'Friday'
        $recurrence.LimitInMbps | Should -Be 100
        $recurrence.EndTimeHour | Should -Be 5
        $recurrence.StartTimeHour | Should -Be 1
        $recurrence.StartTimeMinute | Should -Be 30
        $recurrence.EndTimeMinute | Should -Be 0
    }
}
