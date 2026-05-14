if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageTaskAssignment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageTaskAssignment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New/Get/Update/Remove-AzStorageTaskAssignment, List task assignment reports' {
    It 'New/Get/Update/Remove-AzStorageTaskAssignment, List task assignment reports' {
        $assignmentname1 = "testassignment01"
        $reportprefix = "testc1"
        $startOn = Get-Date -Year 2201 -Month 11 -Day 10 -Hour 2 -Minute 35 -Second 29 -Millisecond 0
        $assignment1 = New-AzStorageTaskAssignment -AccountName $env.TaskAssignmentAccount -Name $assignmentname1 -ResourceGroupName $env.TaskAssignmentResourceGroup -TaskId $env.TaskID -ReportPrefix $reportprefix -TriggerType RunOnce -StartOn $startOn -Description "task assignment1" -Enabled:$false
        $assignment1.Name | Should -Be $assignmentname1
        $assignment1.ReportPrefix | Should -Be $reportprefix
        $assignment1.TriggerType | Should -Be "RunOnce"
        $assignment1.Enabled | Should -Be $false
        $assignment1.StartOn.Year| Should -Be $startOn.ToUniversalTime().Year

        $assignmentname2 = "testassignment02"
        $start = Get-Date -Year 2225 -Month 1 -Day 10 -Hour 1 -Minute 30
        $end = Get-Date -Year 2226 -Month 1 -Day 10 -Hour 2 -Minute 35
        $assignment2 = New-AzStorageTaskAssignment -AccountName $env.TaskAssignmentAccount -Name $assignmentname2 -ResourceGroupName $env.TaskAssignmentResourceGroup -TaskId $env.TaskID  -Description "test assignment2" -ReportPrefix $reportprefix -TriggerType OnSchedule -StartFrom $start.ToUniversalTime() -EndBy $end.ToUniversalTime() -Enabled:$false -Interval 10 -IntervalUnit Days 
        $assignment2.Name | Should -Be $assignmentname2
        $assignment2.ReportPrefix | Should -Be $reportprefix
        $assignment2.TriggerType | Should -Be "OnSchedule"
        $assignment2.Enabled | Should -Be $false
        $assignment2.IntervalUnit | Should -Be "days"
        $assignment2.Interval | Should -Be 10 
        $assignment2.StartFrom.Year| Should -Be $start.ToUniversalTime().Year
        $assignment2.EndBy.Year | Should -Be $end.ToUniversalTime().Year

        $assignment1 = Get-AzStorageTaskAssignment -AccountName $env.TaskAssignmentAccount -ResourceGroupName $env.TaskAssignmentResourceGroup -Name $assignmentname1
        $assignment1.Name | Should -Be $assignmentname1
        $assignment1.ReportPrefix | Should -Be $reportprefix
        $assignment1.TriggerType | Should -Be "RunOnce"
        $assignment1.Enabled | Should -Be $false

        $assignment2 = Get-AzStorageTaskAssignment -AccountName $env.TaskAssignmentAccount -ResourceGroupName $env.TaskAssignmentResourceGroup -Name $assignmentname2
        $assignment2.Name | Should -Be $assignmentname2
        $assignment2.ReportPrefix | Should -Be $reportprefix
        $assignment2.TriggerType | Should -Be "OnSchedule"
        $assignment2.Enabled | Should -Be $false
        $assignment2.IntervalUnit | Should -Be "days"
        $assignment2.Interval | Should -Be 10 

        $assignments = Get-AzStorageTaskAssignment -ResourceGroupName $env.TaskAssignmentResourceGroup -AccountName $env.TaskAssignmentAccount 
        $assignments.Count | Should -BeGreaterThan 1

        $assignment1 = Update-AzStorageTaskAssignment -AccountName $env.TaskAssignmentAccount -ResourceGroupName $env.TaskAssignmentResourceGroup -Name $assignmentname1 -StartOn $end.ToUniversalTime()
        $assignment1.Name | Should -Be $assignmentname1
        $assignment1.ReportPrefix | Should -Be $reportprefix
        $assignment1.TriggerType | Should -Be "RunOnce"
        $assignment1.Enabled | Should -Be $false
        $assignment1.StartOn.Year | Should -Be $end.ToUniversalTime().Year

        $assignment2 = Update-AzStorageTaskAssignment -AccountName $env.TaskAssignmentAccount -ResourceGroupName $env.TaskAssignmentResourceGroup -Name $assignmentname2 -Interval 20 -IntervalUnit Days -Description "update a task assignment" -Enabled:$false -TargetExcludePrefix "ttt"
        $assignment2.Name | Should -Be $assignmentname2
        $assignment2.ReportPrefix | Should -Be $reportprefix
        $assignment2.TriggerType | Should -Be "OnSchedule"
        $assignment2.Enabled | Should -Be $false
        $assignment2.IntervalUnit | Should -Be "days"
        $assignment2.Interval | Should -Be 20

        $reports = Get-AzStorageTaskAssignmentInstancesReport -ResourceGroupName $env.TaskAssignmentResourceGroup -AccountName $env.TaskAssignmentAccount -StorageTaskAssignmentName $assignmentname1
        $reports.Count | Should -Be 0 

        $reports = Get-AzStorageTaskAssignmentInstancesReport -ResourceGroupName $env.TaskAssignmentResourceGroup -AccountName $env.TaskAssignmentAccount
        $reports.Count | Should -Be 0

        Remove-AzStorageTaskAssignment -AccountName $env.TaskAssignmentAccount -ResourceGroupName $env.TaskAssignmentResourceGroup -Name $assignmentname1
        Remove-AzStorageTaskAssignment -AccountName $env.TaskAssignmentAccount -ResourceGroupName $env.TaskAssignmentResourceGroup -Name $assignmentname2
    }
}
