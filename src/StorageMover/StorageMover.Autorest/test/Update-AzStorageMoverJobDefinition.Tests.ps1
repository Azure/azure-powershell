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

}

Describe 'Update-AzStorageMoverJobDefinition PythonParity' -Tag @('PythonParity', 'Offline') {
    It 'UpdateExpandedSyncAndHourlyRequest' {
        $syncedUntil = [datetime]::new(2026, 5, 1, 0, 0, 0, [System.DateTimeKind]::Utc)
        $capture = Invoke-StorageMoverTestRequest -Response @{
            name = 'job'
            properties = @{
                sourceName = 'source'; targetName = 'target'; copyMode = 'Additive'
                syncMode = 'FullScan'; moverSyncedUntil = '2026-05-01T00:00:00Z'
                schedule = @{ frequency = 'Hourly'; repeatInterval = '6h'; isActive = $true }
            }
        } -Command {
            param($pipeline)
            Update-AzStorageMoverJobDefinition -SubscriptionId $env.SubscriptionId -ResourceGroupName 'rg' -StorageMoverName 'mover' -ProjectName 'project' -Name 'job' -ScheduleFrequency Hourly -ScheduleRepeatInterval '6h' -SyncMode FullScan -MoverSyncedUntil $syncedUntil -HttpPipelinePrepend $pipeline
        }
        $capture.Requests.Count | Should -Be 1
        $capture.Requests[0].Method | Should -Be 'PATCH'
        $capture.Requests[0].Uri.AbsolutePath | Should -Be "/subscriptions/$($env.SubscriptionId)/resourceGroups/rg/providers/Microsoft.StorageMover/storageMovers/mover/projects/project/jobDefinitions/job"
        $capture.Requests[0].Uri.Query | Should -Be '?api-version=2026-05-01'
        $request = ($capture.Requests[0].Content | ConvertFrom-Json).properties
        $request.schedule.frequency | Should -Be "Hourly"
        $request.schedule.repeatInterval | Should -Be "6h"
        $request.syncMode | Should -Be "FullScan"
        ([datetime]$request.moverSyncedUntil).ToUniversalTime() | Should -Be $syncedUntil
        $request.PSObject.Properties.Name | Should -Not -Contain 'sourceName'
        $request.PSObject.Properties.Name | Should -Not -Contain 'targetName'
        $capture.Result.SyncMode | Should -Be 'FullScan'
        $capture.Result.ScheduleRepeatInterval | Should -Be '6h'
    }

    It 'UpdateScheduleFalseWithoutOverwritingOtherFieldsRequest' {
        $capture = Invoke-StorageMoverTestRequest -Response @{
            name = 'job'
            properties = @{ schedule = @{ frequency = 'Hourly'; repeatInterval = '6h'; isActive = $false } }
        } -Command {
            param($pipeline)
            Update-AzStorageMoverJobDefinition -SubscriptionId $env.SubscriptionId -ResourceGroupName 'rg' -StorageMoverName 'mover' -ProjectName 'project' -Name 'job' -ScheduleIsActive:$false -HttpPipelinePrepend $pipeline
        }
        $request = ($capture.Requests[0].Content | ConvertFrom-Json).properties
        @($request.PSObject.Properties.Name).Count | Should -Be 1
        @($request.schedule.PSObject.Properties.Name).Count | Should -Be 1
        $request.schedule.isActive | Should -Be $false
        $capture.Result.ScheduleIsActive | Should -Be $false
        $capture.Result.ScheduleFrequency | Should -Be 'Hourly'
        $capture.Result.ScheduleRepeatInterval | Should -Be '6h'
    }
}
