if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageMoverJobDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageMoverJobDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageMoverJobDefinition' {
    It 'UpdateExpanded' {
        $jobName = "testUpdateJob5" + $env.RandomString
        $job = New-AzStorageMoverJobDefinition -Name $jobName -ProjectName $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -AgentName $env.AgentName -SourceName $env.NfsEndpointName -TargetName $env.ContainerEndpointName -CopyMode "Additive"
        $updateDescription = "update description"
        $job = Update-AzStorageMoverJobDefinition -Name $jobName -ProjectName $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Description $updateDescription
        $job.Description | Should -Be $updateDescription
        $job.Name | Should -Be $jobName 
    }

    It 'UpdateExpandedSyncAndHourlyRequest' {
        # Hourly schedules and synchronization settings are not recorded live yet, so this checks the request model offline.
        $update = [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.JobDefinitionUpdateParameters]::New()
        $update.ScheduleFrequency = "Hourly"
        $update.ScheduleRepeatInterval = "PT1H"
        $update.SyncMode = "FullScan"
        $request = ($update.ToJsonString() | ConvertFrom-Json).properties
        $request.schedule.frequency | Should -Be "Hourly"
        $request.schedule.repeatInterval | Should -Be "PT1H"
        $request.syncMode | Should -Be "FullScan"
    }
}
