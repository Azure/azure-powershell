if(($null -eq $TestName) -or ($TestName -contains 'New-AzDataTransferFlowProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataTransferFlowProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Test FlowProfile names - using unique identifiers to avoid conflicts
$testRunId = Get-Date -Format "MMddHHmm"
$testRunId = "09280826"
$basicFlowProfileName = "test-basic-fp-$testRunId"
$messagingFlowProfileName = "test-messaging-fp-$testRunId"
$asJobFlowProfileName = "test-asjob-fp-$testRunId"

Write-Host "FlowProfile test names - Basic: $basicFlowProfileName, Messaging: $messagingFlowProfileName, AsJob: $asJobFlowProfileName"

Describe 'New-AzDataTransferFlowProfile' {
    
    It 'CreateBasicFlowProfile' {
        {
            # Create a basic FlowProfile with minimal required properties
            $basicParams = @{
                Name = $basicFlowProfileName
                PipelineName = $env.PipelineName
                ResourceGroupName = $env.ResourceGroupName
                Location = $env.FlowProfileLocation
                ReplicationScenario = "Files"
                Status = "Enabled"
                Description = "Basic FlowProfile for Files replication testing"
            }

            $basicFlowProfile = New-AzDataTransferFlowProfile @basicParams

            # Verify the FlowProfile is created with correct properties
            $basicFlowProfile | Should -Not -BeNullOrEmpty
            $basicFlowProfile.Name | Should -Be $basicFlowProfileName
            $basicFlowProfile.Location | Should -Be $env.FlowProfileLocation
            $basicFlowProfile.ReplicationScenario | Should -Be "Files"
            $basicFlowProfile.Status | Should -Be "Enabled"
            $basicFlowProfile.Description | Should -Be "Basic FlowProfile for Files replication testing"
        } | Should -Not -Throw
    }

    It 'CreateMessagingFlowProfile' {
        {
            # Create a FlowProfile optimized for messaging scenarios
            $messagingParams = @{
                Name = $messagingFlowProfileName
                PipelineName = $env.PipelineName
                ResourceGroupName = $env.ResourceGroupName
                Location = $env.FlowProfileLocation
                ReplicationScenario = "Messaging"
                Status = "Enabled"
                Description = "FlowProfile optimized for Azure Service Bus and Event Hub message replication"
                AntivirusAvSolution = @("Defender")
            }

            $messagingFlowProfile = New-AzDataTransferFlowProfile @messagingParams

            # Verify the FlowProfile is created with messaging-specific properties
            $messagingFlowProfile | Should -Not -BeNullOrEmpty
            $messagingFlowProfile.Name | Should -Be $messagingFlowProfileName
            $messagingFlowProfile.ReplicationScenario | Should -Be "Messaging"
            $messagingFlowProfile.Status | Should -Be "Enabled"
        } | Should -Not -Throw
    }

    It 'CreateFlowProfileAsJob' {
        {
            # Create a FlowProfile as a background job
            $asJobParams = @{
                Name = $asJobFlowProfileName
                PipelineName = $env.PipelineName
                ResourceGroupName = $env.ResourceGroupName
                Location = $env.FlowProfileLocation
                ReplicationScenario = "Files"
                Status = "Enabled"
                Description = "FlowProfile created as background job"
                AntivirusAvSolution = @("Defender")
            }

            # Create FlowProfile as a background job
            $job = New-AzDataTransferFlowProfile @asJobParams -AsJob -Confirm:$false

            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true

            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true

            # Verify the FlowProfile is created after the job completes
            $createdFlowProfile = Get-AzDataTransferFlowProfile -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowProfileName $asJobFlowProfileName
            $createdFlowProfile | Should -Not -BeNullOrEmpty
            $createdFlowProfile.Name | Should -Be $asJobFlowProfileName
            $createdFlowProfile.ReplicationScenario | Should -Be "Files"
            $createdFlowProfile.Status | Should -Be "Enabled"
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    AfterAll {
        # ToDo: Clean up all created FlowProfiles once Remove is implemented
        Write-Host "Cleaning up test FlowProfiles..."
    }
}
