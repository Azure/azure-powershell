if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDataTransferFlowProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDataTransferFlowProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Create test FlowProfile names for update tests
$testRunId = "01"
$updateTestFlowProfileName = "test-update-fp-$testRunId"
$updateAsJobFlowProfileName = "test-update-asjob-fp-$testRunId"

Describe 'Update-AzDataTransferFlowProfile' {
    
    BeforeAll {
        # Create test FlowProfiles for update operations
        $initialFlowProfileParams = @{
            Name = $updateTestFlowProfileName
            PipelineName = $env.PipelineName
            ResourceGroupName = $env.ResourceGroupName
            Location = $env.FlowProfileLocation
            ReplicationScenario = "Files"
            Status = "Enabled"
            Description = "Initial FlowProfile for update testing"
            DataSizeMaximum = 1048576  # 1 MB
            DataSizeMinimum = 1024
        }

        $asJobFlowProfileParams = @{
            Name = $updateAsJobFlowProfileName
            PipelineName = $env.PipelineName
            ResourceGroupName = $env.ResourceGroupName
            Location = $env.FlowProfileLocation
            ReplicationScenario = "Messaging"
            Status = "Enabled"
            Description = "Initial FlowProfile for AsJob update testing"
            AntivirusAvSolution = @("Defender")
        }

        Write-Host "Creating test FlowProfiles for Update operations: $updateTestFlowProfileName, $updateAsJobFlowProfileName"
        $null = New-AzDataTransferFlowProfile @initialFlowProfileParams
        $null = New-AzDataTransferFlowProfile @asJobFlowProfileParams
    }

    It 'UpdateExpanded' {
        {
            # Verify the FlowProfile exists before update
            $originalFlowProfile = Get-AzDataTransferFlowProfile -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowProfileName $updateTestFlowProfileName
            $originalFlowProfile | Should -Not -BeNullOrEmpty
            $originalFlowProfile.Description | Should -Be "Initial FlowProfile for update testing"
            $originalFlowProfile.DataSizeMaximum | Should -Be 1048576

            # Update the FlowProfile with new properties
            $updateParams = @{
                PipelineName = $env.PipelineName
                ResourceGroupName = $env.ResourceGroupName
                FlowProfileName = $updateTestFlowProfileName
                Description = "Updated FlowProfile with enhanced security features"
                DataSizeMaximum = 10485760  # 10 MB
                DataSizeMinimum = 2048
                AntivirusAvSolution = @("ClamAv", "Defender")
                Status = "Enabled"
            }

            $updatedFlowProfile = Update-AzDataTransferFlowProfile @updateParams
            
            # Verify the update was successful
            $updatedFlowProfile | Should -Not -BeNullOrEmpty
            $updatedFlowProfile.Name | Should -Be $updateTestFlowProfileName
            $updatedFlowProfile.Description | Should -Be "Updated FlowProfile with enhanced security features"
            $updatedFlowProfile.DataSizeMaximum | Should -Be 10485760
            $updatedFlowProfile.DataSizeMinimum | Should -Be 2048
            $updatedFlowProfile.AntivirusAvSolution | Should -Contain "ClamAv"
            $updatedFlowProfile.AntivirusAvSolution | Should -Contain "Defender"

            # Verify by getting the FlowProfile again
            $verifyFlowProfile = Get-AzDataTransferFlowProfile -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowProfileName $updateTestFlowProfileName
            $verifyFlowProfile.Description | Should -Be "Updated FlowProfile with enhanced security features"
            $verifyFlowProfile.DataSizeMaximum | Should -Be 10485760
        } | Should -Not -Throw
    }

    It 'UpdateNonExistentFlowProfile' {
        {
            # Try to update a FlowProfile that doesn't exist
            $nonExistentName = "non-existent-update-fp-$testRunId"
            $updateParams = @{
                PipelineName = $env.PipelineName
                ResourceGroupName = $env.ResourceGroupName
                FlowProfileName = $nonExistentName
                Description = "This should fail"
                Status = "Enabled"
            }

            { Update-AzDataTransferFlowProfile @updateParams } | Should -Throw
        } | Should -Not -Throw
    }

    It 'UpdateAsJob' {
        {
            # Verify the FlowProfile exists before update
            $originalFlowProfile = Get-AzDataTransferFlowProfile -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowProfileName $updateAsJobFlowProfileName
            $originalFlowProfile | Should -Not -BeNullOrEmpty
            $originalFlowProfile.Description | Should -Be "Initial FlowProfile for AsJob update testing"

            # Update the FlowProfile as a background job
            $updateParams = @{
                PipelineName = $env.PipelineName
                ResourceGroupName = $env.ResourceGroupName
                FlowProfileName = $updateAsJobFlowProfileName
                Description = "Updated via AsJob - Enhanced messaging FlowProfile"
                AntivirusAvSolution = @("ClamAv", "Defender")
                DataSizeMaximum = 5242880  # 5 MB
                Status = "Enabled"
            }

            $job = Update-AzDataTransferFlowProfile @updateParams -AsJob

            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true

            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true

            # Verify the update was successful after job completion
            $updatedFlowProfile = Get-AzDataTransferFlowProfile -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowProfileName $updateAsJobFlowProfileName
            $updatedFlowProfile | Should -Not -BeNullOrEmpty
            $updatedFlowProfile.Description | Should -Be "Updated via AsJob - Enhanced messaging FlowProfile"
            $updatedFlowProfile.DataSizeMaximum | Should -Be 5242880
            $updatedFlowProfile.AntivirusAvSolution | Should -Contain "ClamAv"
            $updatedFlowProfile.AntivirusAvSolution | Should -Contain "Defender"
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityPipelineExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    AfterAll {
        # ToDo: Clean up the test FlowProfiles once Remove is implemented
        Write-Host "Update FlowProfile tests cleanup completed."
    }
}
