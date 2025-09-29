if(($null -eq $TestName) -or ($TestName -contains 'New-AzDataTransferConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataTransferConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# FlowProfile-based connection test names
$testRunId = "09281619"
$connectionToCreate = "test-connection-create-$testRunId"
$connectionToCreateAsJob = "test-connection-create-as-job-$testRunId"
$fpBasicConnectionName = "test-rcv-basic-fp-conn-$testRunId"
$fpMultiConnectionName = "test-multi-fp-conn-$testRunId"
$fpSendConnectionName = "test-send-basic-fp-conn-$testRunId"
$fpAsJobConnectionName = "test-asjob-fp-conn-$testRunId"

$testRunIdFp = "09280826"
$basicFlowProfileName = "test-basic-fp-$testRunIdFp"
$messagingFlowProfileName = "test-messaging-fp-$testRunIdFp"
$asJobFlowProfileName = "test-asjob-fp-$testRunIdFp"

Write-Host "Connection names - FlowType: $connectionToCreate, $connectionToCreateAsJob"
Write-Host "FlowProfile Connection names - Basic: $fpBasicConnectionName, Multi: $fpMultiConnectionName, Send: $fpSendConnectionName, AsJob: $fpAsJobConnectionName"

Describe 'New-AzDataTransferConnection' {
    $connectionParams = @{
        Location             = $env.Location
        PipelineName         = $env.PipelineName
        Direction            = "Receive"
        FlowType             = "Mission"
        ResourceGroupName    = $env.ResourceGroupName
        Justification        = "Receive side for PS testing"
        RemoteSubscriptionId = $env.SubscriptionId
        RequirementId        = 0
        Name                 = $connectionToCreate
        PrimaryContact       = "faikh@microsoft.com"
    }

    It 'CreateNewConnection' {
        {
            # Create a new connection
            $createdConnection = New-AzDataTransferConnection @connectionParams

            # Verify the connection is created
            $createdConnection | Should -Not -BeNullOrEmpty
            $createdConnection.Name | Should -Be $connectionToCreate
            $createdConnection.Location | Should -Be $env.Location
            $createdConnection.Pipeline | Should -Be $env.PipelineName
            $createdConnection.Direction | Should -Be "Receive"
            $createdConnection.FlowType | Should -Be "Mission"
            $createdConnection.ResourceGroupName | Should -Be $env.ResourceGroupName
            $createdConnection.RemoteSubscriptionId | Should -Be $env.SubscriptionId
            $createdConnection.RequirementId | Should -Be 0
        } | Should -Not -Throw
    }

    It 'CreateExistingConnection' {
        {
            # Ensure the connection already exists
            { New-AzDataTransferConnection @connectionParams } | Should -Throw
    
            # Verify the connection still exists and no duplicate is created
            $existingConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToCreate
            $existingConnection | Should -Not -BeNullOrEmpty
            $existingConnection.Name | Should -Be $connectionToCreate
        } | Should -Not -Throw
    }

    It 'CreateNewConnection AsJob' {
        {
            $connectionParams = @{
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Receive"
                FlowType             = "Mission"
                ResourceGroupName    = $env.ResourceGroupName
                Justification        = "Receive side for PS testing"
                RemoteSubscriptionId = $env.SubscriptionId
                RequirementId        = 0
                Name                 = $connectionToCreateAsJob
                PrimaryContact       = "faikh@microsoft.com"
            }

            # Create a new connection as a background job
            $job = New-AzDataTransferConnection @connectionParams -AsJob -Confirm:$false
    
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
    
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
    
            # Verify the connection is created after the job completes
            $createdConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToCreateAsJob
            $createdConnection | Should -Not -BeNullOrEmpty
            $createdConnection.Name | Should -Be $connectionToCreateAsJob
            $createdConnection.Location | Should -Be $env.Location
            $createdConnection.Pipeline | Should -Be $env.PipelineName
            $createdConnection.Direction | Should -Be "Receive"
            $createdConnection.FlowType | Should -Be "Mission"
            $createdConnection.ResourceGroupName | Should -Be $env.ResourceGroupName
            $createdConnection.RemoteSubscriptionId | Should -Be $env.SubscriptionId
            $createdConnection.RequirementId | Should -Be 0
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    # Helper function to create FlowProfile metadata for connections
    function New-TestFlowProfileMetadata {
        param(
            [string]$FlowProfileName,
            [string]$PipelineName,
            [string]$ResourceGroupName
        )
        
        try {
            $flowProfile = Get-AzDataTransferFlowProfile -PipelineName $PipelineName -ResourceGroupName $ResourceGroupName -FlowProfileName $FlowProfileName -ErrorAction SilentlyContinue
            
            if ($flowProfile) {
                return @{
                    Name = $FlowProfileName
                    Pipeline = $PipelineName
                    FlowProfileId = $flowProfile.FlowProfileId
                    ReplicationScenario = $flowProfile.ReplicationScenario
                    Status = $flowProfile.Status
                    Description = $flowProfile.Description
                }
            } else {
                Write-Warning "FlowProfile $FlowProfileName not found, creating metadata anyway"
                return @{
                    Name = $FlowProfileName
                    Pipeline = $PipelineName
                    ReplicationScenario = "Files"
                    Status = "Enabled"
                    Description = "Test FlowProfile metadata"
                }
            }
        }
        catch {
            Write-Warning "Error creating FlowProfile metadata: $($_.Exception.Message)"
            return @{
                Name = $FlowProfileName
                Pipeline = $PipelineName
                ReplicationScenario = "Files"
                Status = "Enabled"
                Description = "Test FlowProfile metadata"
            }
        }
    }

    # FlowProfile-based Connection Tests
    It 'CreateConnectionWithSingleFlowProfile' {
        {
            # Create FlowProfile metadata for the connection
            $flowProfileMetadata = New-TestFlowProfileMetadata -FlowProfileName $basicFlowProfileName -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName

            $fpConnectionParams = @{
                Name                 = $fpBasicConnectionName
                ResourceGroupName    = $env.ResourceGroupName
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Receive"
                FlowProfileList      = @($flowProfileMetadata)
                Justification        = "Basic receive connection using single FlowProfile for testing"
                RequirementId        = "FP-BASIC-$testRunId"
                RemoteSubscriptionId = $env.SubscriptionId
                PrimaryContact       = "fptest@company.com"
            }

            # Create the connection with FlowProfile
            $createdConnection = New-AzDataTransferConnection @fpConnectionParams

            # Verify the connection is created with FlowProfile
            $createdConnection | Should -Not -BeNullOrEmpty
            $createdConnection.Name | Should -Be $fpBasicConnectionName
            $createdConnection.Location | Should -Be $env.Location
            $createdConnection.Pipeline | Should -Be $env.PipelineName
            $createdConnection.Direction | Should -Be "Receive"
            $createdConnection.ResourceGroupName | Should -Be $env.ResourceGroupName
            $createdConnection.RemoteSubscriptionId | Should -Be $env.SubscriptionId
            $createdConnection.RequirementId | Should -Be "FP-BASIC-$testRunId"
            $createdConnection.FlowProfileList | Should -Not -BeNullOrEmpty
            $createdConnection.FlowProfileList.Count | Should -Be 1
            $createdConnection.FlowProfileList[0].Name | Should -Be $basicFlowProfileName
        } | Should -Not -Throw
    }

    It 'CreateConnectionWithMultipleFlowProfiles' {
        {
            # Create multiple FlowProfile metadata objects
            $basicFlowProfileMetadata = New-TestFlowProfileMetadata -FlowProfileName $basicFlowProfileName -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName
            $messagingFlowProfileMetadata = New-TestFlowProfileMetadata -FlowProfileName $messagingFlowProfileName -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName

            $fpMultiConnectionParams = @{
                Name                 = $fpMultiConnectionName
                ResourceGroupName    = $env.ResourceGroupName
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Receive"
                FlowProfileList      = @($basicFlowProfileMetadata, $messagingFlowProfileMetadata)
                Justification        = "Advanced connection supporting multiple FlowProfiles for diverse data transfer scenarios"
                RequirementId        = "FP-MULTI-$testRunId"
                RemoteSubscriptionId = $env.SubscriptionId
                PrimaryContact       = "fpmulti@company.com"
                SecondaryContact     = @("tech-lead@company.com", "operations@company.com")
            }

            # Create the connection with multiple FlowProfiles
            $createdConnection = New-AzDataTransferConnection @fpMultiConnectionParams

            # Verify the connection is created with multiple FlowProfiles
            $createdConnection | Should -Not -BeNullOrEmpty
            $createdConnection.Name | Should -Be $fpMultiConnectionName
            $createdConnection.Direction | Should -Be "Receive"
            $createdConnection.FlowProfileList | Should -Not -BeNullOrEmpty
            $createdConnection.FlowProfileList.Count | Should -Be 2
            
            # Verify FlowProfile names
            $fpNames = $createdConnection.FlowProfileList | ForEach-Object { $_.Name }
            $fpNames | Should -Contain $basicFlowProfileName
            $fpNames | Should -Contain $messagingFlowProfileName
        } | Should -Not -Throw
    }

    It 'CreateSendConnectionWithFlowProfile' {
        {
            # Create FlowProfile metadata for send connection
            $flowProfileMetadata = New-TestFlowProfileMetadata -FlowProfileName $basicFlowProfileName -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName

            $fpSendConnectionParams = @{
                Name                 = $fpSendConnectionName
                ResourceGroupName    = $env.ResourceGroupName
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Send"
                FlowProfileList      = @($flowProfileMetadata)
                Justification        = "Send connection using FlowProfile for outbound data transfer testing"
                RequirementId        = "FP-SEND-$testRunId"
                RemoteSubscriptionId = $env.SubscriptionId
                PrimaryContact       = "fpsend@company.com"
                Pin                  = "TEST-PIN-$testRunId"
            }

            # Create the send connection with FlowProfile
            $createdConnection = New-AzDataTransferConnection @fpSendConnectionParams

            # Verify the send connection is created with FlowProfile
            $createdConnection | Should -Not -BeNullOrEmpty
            $createdConnection.Name | Should -Be $fpSendConnectionName
            $createdConnection.Direction | Should -Be "Send"
            $createdConnection.FlowProfileList | Should -Not -BeNullOrEmpty
            $createdConnection.FlowProfileList.Count | Should -Be 1
            $createdConnection.Pin | Should -Be "TEST-PIN-$testRunId"
        } | Should -Not -Throw
    }

    It 'CreateConnectionWithFlowProfileAsJob' {
        {
            # Create FlowProfile metadata for AsJob connection
            $flowProfileMetadata = New-TestFlowProfileMetadata -FlowProfileName $asJobFlowProfileName -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName

            $fpAsJobConnectionParams = @{
                Name                 = $fpAsJobConnectionName
                ResourceGroupName    = $env.ResourceGroupName
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Receive"
                FlowProfileList      = @($flowProfileMetadata)
                Justification        = "Connection created as background job using FlowProfile"
                RequirementId        = "FP-ASJOB-$testRunId"
                RemoteSubscriptionId = $env.SubscriptionId
                PrimaryContact       = "fpasjob@company.com"
            }

            # Create the connection as a background job
            $job = New-AzDataTransferConnection @fpAsJobConnectionParams -AsJob -Confirm:$false

            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true

            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true

            # Verify the connection is created after the job completes
            $createdConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $fpAsJobConnectionName
            $createdConnection | Should -Not -BeNullOrEmpty
            $createdConnection.Name | Should -Be $fpAsJobConnectionName
            $createdConnection.Direction | Should -Be "Receive"
            $createdConnection.FlowProfileList | Should -Not -BeNullOrEmpty
            $createdConnection.FlowProfileList.Count | Should -Be 1
            $createdConnection.FlowProfileList[0].Name | Should -Be $asJobFlowProfileName
        } | Should -Not -Throw
    }

    It 'CreateExistingConnectionWithFlowProfile' {
        {
            # Try to create a connection that already exists (should throw)
            $flowProfileMetadata = New-TestFlowProfileMetadata -FlowProfileName $basicFlowProfileName -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName

            $duplicateConnectionParams = @{
                Name                 = $fpBasicConnectionName  # This should already exist from previous test
                ResourceGroupName    = $env.ResourceGroupName
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Receive"
                FlowProfileList      = @($flowProfileMetadata)
                Justification        = "Duplicate connection test"
                RequirementId        = "FP-DUPLICATE-$testRunId"
                RemoteSubscriptionId = $env.SubscriptionId
                PrimaryContact       = "fpdup@company.com"
            }

            { New-AzDataTransferConnection @duplicateConnectionParams } | Should -Throw

            # Verify the original connection still exists
            $existingConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $fpBasicConnectionName
            $existingConnection | Should -Not -BeNullOrEmpty
            $existingConnection.Name | Should -Be $fpBasicConnectionName
        } | Should -Not -Throw
    }

    AfterAll {
        # Remove test connections created during tests (both FlowType and FlowProfile based)
        @($connectionToCreate, $connectionToCreateAsJob, $fpBasicConnectionName, $fpMultiConnectionName, $fpSendConnectionName, $fpAsJobConnectionName) | ForEach-Object {
            if ($_) {
                try {
                    $connection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $_ -ErrorAction SilentlyContinue
                    if ($connection) {
                        Write-Host "Cleaning up connection: $_"
                        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $_ -Confirm:$false
                        Write-Host "Successfully removed connection: $_"
                    } else {
                        Write-Host "Connection $_ not found or already removed"
                    }
                }
                catch {
                    Write-Warning "Failed to remove connection $_. Error: $($_.Exception.Message)"
                }
            }
        }
    }
}
