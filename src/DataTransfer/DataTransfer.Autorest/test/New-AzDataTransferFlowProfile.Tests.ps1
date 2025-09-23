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
$basicFlowProfileName = "test-basic-fp-$testRunId"
$messagingFlowProfileName = "test-messaging-fp-$testRunId"
$apiFlowProfileName = "test-api-fp-$testRunId"
$complexFlowProfileName = "test-complex-fp-$testRunId"
$advancedFlowProfileName = "test-advanced-fp-$testRunId"
$asJobFlowProfileName = "test-asjob-fp-$testRunId"

Write-Host "FlowProfile test names - Basic: $basicFlowProfileName, Messaging: $messagingFlowProfileName, API: $apiFlowProfileName, Complex: $complexFlowProfileName, Advanced: $advancedFlowProfileName, AsJob: $asJobFlowProfileName"

Describe 'New-AzDataTransferFlowProfile' {
    
    It 'CreateBasicFlowProfile' {
        {
            # Create a basic FlowProfile with minimal required properties
            $basicParams = @{
                Name = $basicFlowProfileName
                PipelineName = $env.PipelineName
                ResourceGroupName = $env.ResourceGroupName
                Location = $env.Location
                ReplicationScenario = "Files"
                Status = "Enabled"
                Description = "Basic FlowProfile for Files replication testing"
            }

            $basicFlowProfile = New-AzDataTransferFlowProfile @basicParams

            # Verify the FlowProfile is created with correct properties
            $basicFlowProfile | Should -Not -BeNullOrEmpty
            $basicFlowProfile.Name | Should -Be $basicFlowProfileName
            $basicFlowProfile.Location | Should -Be $env.Location
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
                Location = $env.Location
                ReplicationScenario = "Messaging"
                Status = "Enabled"
                Description = "FlowProfile optimized for Azure Service Bus and Event Hub message replication"
                AntiviruAvSolution = @("Defender")
            }

            $messagingFlowProfile = New-AzDataTransferFlowProfile @messagingParams

            # Verify the FlowProfile is created with messaging-specific properties
            $messagingFlowProfile | Should -Not -BeNullOrEmpty
            $messagingFlowProfile.Name | Should -Be $messagingFlowProfileName
            $messagingFlowProfile.ReplicationScenario | Should -Be "Messaging"
            $messagingFlowProfile.Status | Should -Be "Enabled"
            $messagingFlowProfile.AntiviruAvSolution | Should -Contain "Defender"
        } | Should -Not -Throw
    }

    It 'CreateAPIFlowProfile' {
        {
            # Create a FlowProfile for REST API scenarios with MIME filters
            $mimeFilters = @(@{
                Media = "application/json"
                Extensions = @(".json", ".xml")
            })

            $textDenyRules = @(@{
                Text = "apikey"
                MatchType = "Partial"
                CaseSensitivity = "Insensitive"
            })

            $apiParams = @{
                Name = $apiFlowProfileName
                PipelineName = $env.PipelineName
                ResourceGroupName = $env.ResourceGroupName
                Location = $env.Location
                ReplicationScenario = "API"
                Status = "Enabled"
                Description = "FlowProfile for RESTful API endpoint data replication"
                MimeFilter = $mimeFilters
                MimeFilterType = "Allow"
                DataSizeMaximum = 10485760  # 10 MB
                DataSizeMinimum = 1
                TextMatchingDeny = $textDenyRules
            }

            $apiFlowProfile = New-AzDataTransferFlowProfile @apiParams

            # Verify the FlowProfile is created with API-specific properties
            $apiFlowProfile | Should -Not -BeNullOrEmpty
            $apiFlowProfile.Name | Should -Be $apiFlowProfileName
            $apiFlowProfile.ReplicationScenario | Should -Be "API"
            $apiFlowProfile.Status | Should -Be "Enabled"
            $apiFlowProfile.MimeFilterType | Should -Be "Allow"
            $apiFlowProfile.DataSizeMaximum | Should -Be 10485760
            $apiFlowProfile.DataSizeMinimum | Should -Be 1
        } | Should -Not -Throw
    }

    It 'CreateComplexDocumentsFlowProfile' {
        {
            # Create a FlowProfile for complex document scenarios
            $mimeFilters = @(
                @{
                    Media = "application"
                    Extensions = @(".pdf", ".docx", ".xlsx", ".pptx")
                },
                @{
                    Media = "text"
                    Extensions = @(".rtf", ".txt")
                }
            )

            $textDenyRules = @(
                @{
                    Text = "CONFIDENTIAL"
                    MatchType = "Complete"
                    CaseSensitivity = "Sensitive"
                },
                @{
                    Text = "social security"
                    MatchType = "Partial"
                    CaseSensitivity = "Insensitive"
                }
            )

            $complexParams = @{
                Name = $complexFlowProfileName
                PipelineName = $env.PipelineName
                ResourceGroupName = $env.ResourceGroupName
                Location = $env.Location
                ReplicationScenario = "Complex"
                Status = "Enabled"
                Description = "FlowProfile for complex Microsoft Office documents and PDF files"
                MimeFilter = $mimeFilters
                MimeFilterType = "Allow"
                DataSizeMaximum = 1073741824  # 1 GB
                DataSizeMinimum = 1024
                ArchiveMinimumSizeForExpansion = 52428800  # 50 MB
                ArchiveMaximumExpansionSizeLimit = 2147483648  # 2 GB
                ArchiveMaximumDepthLimit = 3
                ArchiveMaximumCompressionRatioLimit = 5.0
                AntiviruAvSolution = @("ClamAv", "Defender")
                TextMatchingDeny = $textDenyRules
            }

            $complexFlowProfile = New-AzDataTransferFlowProfile @complexParams

            # Verify the FlowProfile is created with complex document properties
            $complexFlowProfile | Should -Not -BeNullOrEmpty
            $complexFlowProfile.Name | Should -Be $complexFlowProfileName
            $complexFlowProfile.ReplicationScenario | Should -Be "Complex"
            $complexFlowProfile.Status | Should -Be "Enabled"
            $complexFlowProfile.MimeFilterType | Should -Be "Allow"
            $complexFlowProfile.DataSizeMaximum | Should -Be 1073741824
            $complexFlowProfile.ArchiveMaximumDepthLimit | Should -Be 3
            $complexFlowProfile.ArchiveMaximumCompressionRatioLimit | Should -Be 5.0
            $complexFlowProfile.AntiviruAvSolution | Should -Contain "ClamAv"
            $complexFlowProfile.AntiviruAvSolution | Should -Contain "Defender"
        } | Should -Not -Throw
    }

    It 'CreateExistingFlowProfile' {
        {
            # Try to create a FlowProfile that already exists (should throw)
            $duplicateParams = @{
                Name = $basicFlowProfileName  # This should already exist from the first test
                PipelineName = $env.PipelineName
                ResourceGroupName = $env.ResourceGroupName
                Location = $env.Location
                ReplicationScenario = "Files"
                Status = "Enabled"
                Description = "Duplicate FlowProfile"
            }

            { New-AzDataTransferFlowProfile @duplicateParams } | Should -Throw -ErrorId "FlowProfileAlreadyExists"

            # Verify the original FlowProfile still exists
            $existingFlowProfile = Get-AzDataTransferFlowProfile -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowProfileName $basicFlowProfileName
            $existingFlowProfile | Should -Not -BeNullOrEmpty
            $existingFlowProfile.Name | Should -Be $basicFlowProfileName
        } | Should -Not -Throw
    }

    It 'CreateFlowProfileAsJob' {
        {
            # Create a FlowProfile as a background job
            $asJobParams = @{
                Name = $asJobFlowProfileName
                PipelineName = $env.PipelineName
                ResourceGroupName = $env.ResourceGroupName
                Location = $env.Location
                ReplicationScenario = "Files"
                Status = "Enabled"
                Description = "FlowProfile created as background job"
                AntiviruAvSolution = @("Defender")
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
            $createdFlowProfile.AntiviruAvSolution | Should -Contain "Defender"
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
