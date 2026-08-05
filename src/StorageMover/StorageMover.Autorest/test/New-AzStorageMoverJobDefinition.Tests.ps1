if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMoverJobDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverJobDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageMoverJobDefinition' {
    It 'CreateExpanded' {
        $jobName = "testJob1" + $env.RandomString
        $job1 = New-AzStorageMoverJobDefinition -Name $jobName -ProjectName $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -AgentName $env.AgentName -SourceName $env.NfsEndpointName -TargetName $env.ContainerEndpointName -CopyMode "Additive"
        $job1.Name | Should -Be $jobName 
        $job1.CopyMode | Should -Be "Additive"
        $job1.SourceName | Should -Be $env.NfsEndpointName
        $job1.TargetName | Should -Be $env.ContainerEndpointName
        
        $job1 = Get-AzStorageMoverJobDefinition -ProjectName $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Name $jobName
        $job1.Name | Should -Be $jobName 
        $job1.CopyMode | Should -Be "Additive"
        $job1.SourceName | Should -Be $env.NfsEndpointName
        $job1.TargetName | Should -Be $env.ContainerEndpointName
    }

    It 'CreateWithConnection' {
        # Create a self-contained storage mover for this test (no agent needed for CloudToCloud)
        $stoMoverName = "smConn" + $env.RandomString
        New-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $stoMoverName -Location $env.Location | Out-Null

        # Create project, endpoints, and connection on it
        $projName = "projConn" + $env.RandomString
        $mccName = "mccConn" + $env.RandomString
        $containerEpName = "cepConn" + $env.RandomString
        New-AzStorageMoverProject -Name $projName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $stoMoverName | Out-Null
        New-AzStorageMoverMultiCloudConnectorEndpoint -Name $mccName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $stoMoverName -MultiCloudConnectorId $env.MultiCloudConnectorId -AWSS3BucketId $env.AwsS3BucketId | Out-Null
        New-AzStorageMoverAzStorageContainerEndpoint -Name $containerEpName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $stoMoverName -BlobContainerName $env.ContainerName -StorageAccountResourceId $env.StoraccId | Out-Null
        $connName = "connJd" + $env.RandomString
        New-AzStorageMoverConnection -Name $connName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $stoMoverName -PrivateLinkServiceId $env.PrivateLinkServiceId -Description "connection for job def test" | Out-Null

        $connResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.StorageMover/storageMovers/$stoMoverName/connections/$connName"
        $jobName = "testJobConn" + $env.RandomString
        $job = New-AzStorageMoverJobDefinition -Name $jobName -ProjectName $projName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $stoMoverName -SourceName $mccName -TargetName $containerEpName -CopyMode "Additive" -JobType "CloudToCloud" -Connection $connResourceId
        $job.Name | Should -Be $jobName
        $job.Connection | Should -Contain $connResourceId

        # Verify via Get
        $job = Get-AzStorageMoverJobDefinition -ProjectName $projName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $stoMoverName -Name $jobName
        $job.Connection | Should -Contain $connResourceId

        # Clean up - removing the storage mover cascades all child resources
        Remove-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $stoMoverName -Force
    }

    It 'CreateWithSchedule' {
        # Create a self-contained storage mover for this test (no agent needed for CloudToCloud)
        $stoMoverName = "smSched" + $env.RandomString
        New-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $stoMoverName -Location $env.Location | Out-Null

        # Create project and endpoints on it
        $projName = "projSched" + $env.RandomString
        $mccName = "mccSched" + $env.RandomString
        $containerEpName = "cepSched" + $env.RandomString
        New-AzStorageMoverProject -Name $projName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $stoMoverName | Out-Null
        New-AzStorageMoverMultiCloudConnectorEndpoint -Name $mccName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $stoMoverName -MultiCloudConnectorId $env.MultiCloudConnectorId -AWSS3BucketId $env.AwsS3BucketId | Out-Null
        New-AzStorageMoverAzStorageContainerEndpoint -Name $containerEpName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $stoMoverName -BlobContainerName $env.ContainerName -StorageAccountResourceId $env.StoraccId | Out-Null

        $scheduleStart = [DateTime]::UtcNow.AddDays(1)
        $scheduleEnd = [DateTime]::UtcNow.AddDays(90)
        $jobName = "testJobSched" + $env.RandomString
        $job = New-AzStorageMoverJobDefinition -Name $jobName -ProjectName $projName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $stoMoverName -SourceName $mccName -TargetName $containerEpName -CopyMode "Additive" -JobType "CloudToCloud" -ScheduleFrequency "Weekly" -ScheduleDaysOfWeek @("Monday", "Wednesday", "Friday") -ExecutionTimeHour 14 -ExecutionTimeMinute 30 -ScheduleIsActive -ScheduleStartDate $scheduleStart -ScheduleEndDate $scheduleEnd
        $job.Name | Should -Be $jobName
        $job.ScheduleFrequency | Should -Be "Weekly"
        $job.ScheduleDaysOfWeek | Should -Contain "Monday"
        $job.ScheduleDaysOfWeek | Should -Contain "Wednesday"
        $job.ScheduleDaysOfWeek | Should -Contain "Friday"
        $job.ExecutionTimeHour | Should -Be 14
        $job.ExecutionTimeMinute | Should -Be 30
        $job.ScheduleIsActive | Should -Be $true

        # Verify via Get
        $job = Get-AzStorageMoverJobDefinition -ProjectName $projName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $stoMoverName -Name $jobName
        $job.ScheduleFrequency | Should -Be "Weekly"
        $job.ScheduleDaysOfWeek.Count | Should -Be 3

        # Clean up - removing the storage mover cascades all child resources
        Remove-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $stoMoverName -Force
    }
}
