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

    # Needs a cross-tenant endpoint in a partner tenant; setupEnv reads its details from the SM_XT_PARTNER_* environment variables.
    It 'CreateCrossTenant' -Skip:(-not $env.PartnerEndpointId) {
        $projectName = "xtproject"
        $sourceEndpointName = "blobsource"
        $jobName = "xtjob"
        New-AzStorageMoverProject -Name $projectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.CrossTenantStoMoverName | Out-Null
        New-AzStorageMoverAzStorageContainerEndpoint -Name $sourceEndpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.CrossTenantStoMoverName -StorageAccountResourceId $env.CrossTenantStorageAccountId -BlobContainerName $env.CrossTenantContainerName -EndpointKind Source -EnableCrossTenantTransfer -AllowedStorageAccount $env.PartnerStorageAccountId | Out-Null

        $job = New-AzStorageMoverJobDefinition -Name $jobName -ProjectName $projectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.CrossTenantStoMoverName -JobType CloudToCloud -CopyMode Additive -SourceName $sourceEndpointName -TargetName $env.PartnerEndpointName -IsCrossTenantJob -CrossTenantEndpointTenantId $env.PartnerTenantId -CrossTenantEndpointResourceId $env.PartnerEndpointId
        $job.IsCrossTenantJob | Should -Be $true
        $job.CrossTenantEndpointTenantId | Should -Be $env.PartnerTenantId
        $job.CrossTenantEndpointResourceId | Should -Be $env.PartnerEndpointId

        $job = Get-AzStorageMoverJobDefinition -Name $jobName -ProjectName $projectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.CrossTenantStoMoverName
        $job.IsCrossTenantJob | Should -Be $true
        $job.TargetName | Should -Be $env.PartnerEndpointName
        $job.TargetResourceId | Should -Be $env.PartnerEndpointId
    }

}

Describe 'New-AzStorageMoverJobDefinition RequestContract' -Tag @('PythonParity', 'Offline') {
    It 'CreateExpandedSyncAndHourlyRequest' {
        $syncedUntil = [datetime]::new(2026, 5, 1, 0, 0, 0, [System.DateTimeKind]::Utc)
        $response = @{
            name = 'job'
            properties = @{
                sourceName = 'source'; targetName = 'target'; copyMode = 'Additive'
                jobType = 'OnPremToCloudAgentLess'; syncMode = 'SnapshotBased'
                dataIntegrityValidation = 'SaveVerifyFileMD5'
                moverSyncedUntil = '2026-05-01T00:00:00Z'
                schedule = @{ frequency = 'Hourly'; repeatInterval = '4h'; isActive = $true }
            }
        }
        $capture = Invoke-StorageMoverTestRequest -Response $response -Command {
            param($pipeline)
            New-AzStorageMoverJobDefinition -SubscriptionId $env.SubscriptionId -ResourceGroupName 'rg' -StorageMoverName 'mover' -ProjectName 'project' -Name 'job' -SourceName 'source' -TargetName 'target' -CopyMode Additive -JobType OnPremToCloudAgentLess -ScheduleFrequency Hourly -ScheduleRepeatInterval '4h' -ScheduleIsActive -SyncMode SnapshotBased -DataIntegrityValidation SaveVerifyFileMD5 -MoverSyncedUntil $syncedUntil -HttpPipelinePrepend $pipeline
        }
        $capture.Requests.Count | Should -Be 1
        $capture.Requests[0].Method | Should -Be 'PUT'
        $capture.Requests[0].Uri.AbsolutePath | Should -Be "/subscriptions/$($env.SubscriptionId)/resourceGroups/rg/providers/Microsoft.StorageMover/storageMovers/mover/projects/project/jobDefinitions/job"
        $capture.Requests[0].Uri.Query | Should -Be '?api-version=2026-05-01'
        $request = ($capture.Requests[0].Content | ConvertFrom-Json).properties
        $request.jobType | Should -Be "OnPremToCloudAgentLess"
        $request.schedule.frequency | Should -Be "Hourly"
        $request.schedule.repeatInterval | Should -Be "4h"
        $request.schedule.isActive | Should -Be $true
        $request.syncMode | Should -Be "SnapshotBased"
        $request.dataIntegrityValidation | Should -Be 'SaveVerifyFileMD5'
        ([datetime]$request.moverSyncedUntil).ToUniversalTime() | Should -Be $syncedUntil
        $capture.Result.JobType | Should -Be 'OnPremToCloudAgentLess'
        $capture.Result.ScheduleRepeatInterval | Should -Be '4h'
        $capture.Result.SyncMode | Should -Be 'SnapshotBased'
        $capture.Result.DataIntegrityValidation | Should -Be 'SaveVerifyFileMD5'
        $capture.Result.MoverSyncedUntil.ToUniversalTime() | Should -Be $syncedUntil
    }
}

Describe 'New-AzStorageMoverJobDefinition PythonParity' -Tag 'PythonParity' {
    It 'Create<Frequency>Schedule' -TestCases @(
        @{ Frequency = 'Weekly'; CopyMode = 'Additive'; Hour = 2 },
        @{ Frequency = 'Daily'; CopyMode = 'Mirror'; Hour = 0 },
        @{ Frequency = 'Onetime'; CopyMode = 'Additive'; Hour = 10 }
    ) {
        param($Frequency, $CopyMode, $Hour)
        $context = $null
        try {
            $context = New-StorageMoverTestContext -Name "sm-$($Frequency.ToLowerInvariant())" -JobEndpoints
            $parameters = @{
                ProjectName = 'project'; Name = 'scheduled'; SourceName = 'source'; TargetName = 'target'
                CopyMode = $CopyMode; ScheduleFrequency = $Frequency; ScheduleIsActive = $true
                ExecutionTimeHour = $Hour; ScheduleStartDate = [datetime]$env.ScenarioScheduleStartDate
            }
            if ($Frequency -ne 'Onetime') {
                $parameters.ScheduleEndDate = [datetime]$env.ScenarioScheduleEndDate
            }
            if ($Frequency -eq 'Weekly') {
                $parameters.ScheduleDaysOfWeek = @('Monday', 'Wednesday', 'Friday')
                $parameters.DataIntegrityValidation = 'None'
            } elseif ($Frequency -eq 'Daily') {
                $parameters.PreservePermission = $true
                $parameters.DataIntegrityValidation = 'None'
            }
            $job = New-AzStorageMoverJobDefinition @context @parameters
            $job.CopyMode | Should -Be $CopyMode
            $job.ScheduleFrequency | Should -Be $Frequency
            $job.ScheduleIsActive | Should -Be $true
            $job.ExecutionTimeHour | Should -Be $Hour
            if ($Frequency -eq 'Weekly') {
                $job.DataIntegrityValidation | Should -Be 'None'
                @($job.ScheduleDaysOfWeek).Count | Should -Be 3
                foreach ($day in $parameters.ScheduleDaysOfWeek) {
                    $job.ScheduleDaysOfWeek | Should -Contain $day
                }
            } elseif ($Frequency -eq 'Daily') {
                $job.PreservePermission | Should -Be $true
                $job.DataIntegrityValidation | Should -Be 'None'
            }
            $job = Get-AzStorageMoverJobDefinition @context -ProjectName 'project' -Name 'scheduled'
            $job.ScheduleFrequency | Should -Be $Frequency
            $job.CopyMode | Should -Be $CopyMode
            Remove-AzStorageMoverJobDefinition @context -ProjectName 'project' -Name 'scheduled'
            Invoke-StorageMoverTestFailure -Code ResourceNotFound -Command {
                Get-AzStorageMoverJobDefinition @context -ProjectName 'project' -Name 'scheduled' -ErrorAction Stop
            }
        } finally {
            Remove-StorageMoverTestContext -Context $context
        }
    }

    It 'CreateGetPartiallyUpdateAndDeleteHourlySchedule' {
        $context = $null
        try {
            $context = New-StorageMoverTestContext -Name 'sm-hourly' -Location eastus2euap -Project
            $accountId = "/subscriptions/$($context.SubscriptionId)/resourceGroups/$($context.ResourceGroupName)/providers/Microsoft.Storage/storageAccounts/testaccount"
            foreach ($kind in @('Source', 'Target')) {
                New-AzStorageMoverAzSmbFileShareEndpoint @context -Name $kind.ToLowerInvariant() -StorageAccountResourceId $accountId -FileShareName "$($kind.ToLowerInvariant())share" -EndpointKind $kind | Out-Null
            }
            $parameters = @{
                ProjectName = 'project'; Name = 'scheduled'; SourceName = 'source'; TargetName = 'target'
                CopyMode = 'Additive'; JobType = 'CloudToCloud'; ScheduleFrequency = 'Hourly'
                ScheduleRepeatInterval = '4h'; ScheduleIsActive = $true; ExecutionTimeHour = 9; ExecutionTimeMinute = 0
                ScheduleStartDate = [datetime]$env.ScenarioScheduleStartDate
                ScheduleEndDate = [datetime]$env.ScenarioScheduleEndDate
            }
            $job = New-AzStorageMoverJobDefinition @context @parameters
            $job.ScheduleFrequency | Should -Be 'Hourly'
            $job.ScheduleRepeatInterval | Should -Be '4h'
            $job.ScheduleIsActive | Should -Be $true
            $job = Get-AzStorageMoverJobDefinition @context -ProjectName 'project' -Name 'scheduled'
            $job.ScheduleRepeatInterval | Should -Be '4h'

            $job = Update-AzStorageMoverJobDefinition @context -ProjectName 'project' -Name 'scheduled' -ScheduleRepeatInterval '6h'
            $job.ScheduleFrequency | Should -Be 'Hourly'
            $job.ScheduleRepeatInterval | Should -Be '6h'
            $job.ScheduleIsActive | Should -Be $true
            $job = Update-AzStorageMoverJobDefinition @context -ProjectName 'project' -Name 'scheduled' -ScheduleIsActive:$false
            $job.ScheduleIsActive | Should -Be $false
            $job.ScheduleRepeatInterval | Should -Be '6h'
            $job = Get-AzStorageMoverJobDefinition @context -ProjectName 'project' -Name 'scheduled'
            $job.ScheduleIsActive | Should -Be $false
            $job.ScheduleFrequency | Should -Be 'Hourly'

            $parameters.Name = 'invalid'
            $parameters.ScheduleRepeatInterval = '5h'
            Invoke-StorageMoverTestFailure -Command { New-AzStorageMoverJobDefinition @context @parameters -ErrorAction Stop }
            Remove-AzStorageMoverJobDefinition @context -ProjectName 'project' -Name 'scheduled'
        } finally {
            Remove-StorageMoverTestContext -Context $context
        }
    }

    It 'RejectInvalidCrossTenantJobs' {
        $context = $null
        try {
            $context = New-StorageMoverTestContext -Name 'sm-cross-tenant-validation' -Location westcentralus -Project
            $partnerSubscription = '22222222-2222-2222-2222-222222222222'
            $partnerAccount = "/subscriptions/$partnerSubscription/resourceGroups/partner-rg/providers/Microsoft.Storage/storageAccounts/partnersa"
            New-AzStorageMoverAzStorageContainerEndpoint @context -Name 'source' -StorageAccountResourceId $env.ScenarioStorageAccountId -BlobContainerName 'testcontainer' -EndpointKind Source -EnableCrossTenantTransfer -AllowedStorageAccount $partnerAccount | Out-Null
            $parameters = @{
                ProjectName = 'project'; SourceName = 'source'; TargetName = 'partner-target'
                CopyMode = 'Additive'; JobType = 'CloudToCloud'; IsCrossTenantJob = $true
                CrossTenantEndpointTenantId = '11111111-2222-3333-4444-555555555555'
                CrossTenantEndpointResourceId = "/subscriptions/$partnerSubscription/resourceGroups/partner-rg/providers/Microsoft.StorageMover/storageMovers/partner-mover/endpoints/partner-target"
            }
            foreach ($missing in @('CrossTenantEndpointTenantId', 'CrossTenantEndpointResourceId', 'IsCrossTenantJob')) {
                $invalid = $parameters.Clone()
                $invalid.Name = "missing-$($missing.ToLowerInvariant())"
                $invalid.Remove($missing)
                Invoke-StorageMoverTestFailure -Command { New-AzStorageMoverJobDefinition @context @invalid -ErrorAction Stop }
            }
            $invalid = $parameters.Clone()
            $invalid.Name = 'invalid-job-type'
            $invalid.JobType = 'OnPremToCloud'
            Invoke-StorageMoverTestFailure -Command { New-AzStorageMoverJobDefinition @context @invalid -ErrorAction Stop }
            $invalid = $parameters.Clone()
            $invalid.Name = 'same-subscription'
            $invalid.CrossTenantEndpointResourceId = "/subscriptions/$($context.SubscriptionId)/resourceGroups/$($context.ResourceGroupName)/providers/Microsoft.StorageMover/storageMovers/$($context.StorageMoverName)/endpoints/partner-target"
            Invoke-StorageMoverTestFailure -Command { New-AzStorageMoverJobDefinition @context @invalid -ErrorAction Stop }
            @(Get-AzStorageMoverJobDefinition @context -ProjectName 'project').Count | Should -Be 0
        } finally {
            Remove-StorageMoverTestContext -Context $context
        }
    }

    It 'CreateAgentlessJobWithConnectionAndRejectMissingConnection' {
        $context = $null
        $connectionCreated = $false
        try {
            $context = New-StorageMoverTestContext -Name 'sm-agentless' -Location eastus2euap -Project
            New-AzStorageMoverSmbEndpoint @context -Name 'source' -Host '10.0.0.1' -ShareName 'testshare' -CredentialsUsernameUri 'https://examples-azureKeyVault.vault.azure.net/secrets/username' -CredentialsPasswordUri 'https://examples-azureKeyVault.vault.azure.net/secrets/password' | Out-Null
            $accountId = "/subscriptions/$($context.SubscriptionId)/resourceGroups/$($context.ResourceGroupName)/providers/Microsoft.Storage/storageAccounts/testaccount"
            New-AzStorageMoverAzSmbFileShareEndpoint @context -Name 'target' -StorageAccountResourceId $accountId -FileShareName 'testshare' | Out-Null
            $parameters = @{ ProjectName = 'project'; Name = 'agentless'; SourceName = 'source'; TargetName = 'target'; CopyMode = 'Additive'; JobType = 'OnPremToCloudAgentLess' }
            Invoke-StorageMoverTestFailure -Command { New-AzStorageMoverJobDefinition @context @parameters -ErrorAction Stop }

            $connection = New-AzStorageMoverConnection @context -Name 'agentless' -PrivateLinkServiceId $env.ScenarioAgentlessPrivateLinkServiceId
            $connectionCreated = $true
            $connection.Status | Should -BeIn @('Pending', 'Approved')
            $parameters.Connection = @($connection.Id)
            $job = New-AzStorageMoverJobDefinition @context @parameters
            $job.JobType | Should -Be 'OnPremToCloudAgentLess'
            $job.Connection | Should -Contain $connection.Id
            $job.AgentName | Should -BeNullOrEmpty
            $job = Get-AzStorageMoverJobDefinition @context -ProjectName 'project' -Name 'agentless'
            $job.JobType | Should -Be 'OnPremToCloudAgentLess'
            $job.Connection | Should -Contain $connection.Id
            Remove-AzStorageMoverJobDefinition @context -ProjectName 'project' -Name 'agentless'
        } finally {
            try {
                if ($connectionCreated) { Remove-AzStorageMoverConnection @context -Name 'agentless' }
            } finally {
                Remove-StorageMoverTestContext -Context $context
            }
        }
    }
}
