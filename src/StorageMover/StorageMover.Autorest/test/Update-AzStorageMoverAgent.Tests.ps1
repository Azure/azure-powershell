if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageMoverAgent'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageMoverAgent.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageMoverAgent' {
    It 'UpdateExpanded' {
        $updateDescription = "update agent description"
        $limit = New-AzStorageMoverUploadLimitWeeklyRecurrenceObject -Day 'Monday','Tuesday','Friday' -LimitInMbps 100 -EndTimeHour 5 -StartTimeHour 1 -StartTimeMinute 30 -EndTimeMinute 0
        $agent = Update-AzStorageMoverAgent -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Name $env.AgentName -Description $updateDescription -UploadLimitScheduleWeeklyRecurrence $limit
        $agent.Name | Should -Be $env.AgentName 
        $agent.Description | Should -Be $updateDescription
        $agent.UploadLimitScheduleWeeklyRecurrence.Day[0] | Should -Be "Monday"
        $agent.UploadLimitScheduleWeeklyRecurrence.Day[1] | Should -Be "Tuesday"
        $agent.UploadLimitScheduleWeeklyRecurrence.Day[2] | Should -Be "Friday"
        $agent.UploadLimitScheduleWeeklyRecurrence.EndTimeHour | Should -Be 5 
        $agent.UploadLimitScheduleWeeklyRecurrence.EndTimeMinute | Should -Be 0 
        $agent.UploadLimitScheduleWeeklyRecurrence.LimitInMbps | Should -Be 100
        $agent.UploadLimitScheduleWeeklyRecurrence.StartTimeHour | Should -Be 1 
        $agent.UploadLimitScheduleWeeklyRecurrence.StartTimeMinute | Should -Be 30 

        $agent = Get-AzStorageMoverAgent -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Name $env.AgentName
        $agent.Name | Should -Be $env.AgentName 
        $agent.Description | Should -Be $updateDescription
        $agent.UploadLimitScheduleWeeklyRecurrence.Day[0] | Should -Be "Monday"
        $agent.UploadLimitScheduleWeeklyRecurrence.Day[1] | Should -Be "Tuesday"
        $agent.UploadLimitScheduleWeeklyRecurrence.Day[2] | Should -Be "Friday"
        $agent.UploadLimitScheduleWeeklyRecurrence.EndTimeHour | Should -Be 5 
        $agent.UploadLimitScheduleWeeklyRecurrence.EndTimeMinute | Should -Be 0 
        $agent.UploadLimitScheduleWeeklyRecurrence.LimitInMbps | Should -Be 100
        $agent.UploadLimitScheduleWeeklyRecurrence.StartTimeHour | Should -Be 1 
        $agent.UploadLimitScheduleWeeklyRecurrence.StartTimeMinute | Should -Be 30 
    }
}
