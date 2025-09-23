if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDataTransferFlowProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataTransferFlowProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Create a test FlowProfile for Get operations
$testRunId = Get-Date -Format "MMddHHmm"
$getTestFlowProfileName = "test-get-fp-$testRunId"

Describe 'Get-AzDataTransferFlowProfile' {
    
    BeforeAll {
        # Create a test FlowProfile for Get operations
        $testFlowProfileParams = @{
            Name = $getTestFlowProfileName
            PipelineName = $env.PipelineName
            ResourceGroupName = $env.ResourceGroupName
            Location = $env.Location
            ReplicationScenario = "Files"
            Status = "Enabled"
            Description = "Test FlowProfile for Get operations"
            AntiviruAvSolution = @("Defender")
        }

        Write-Host "Creating test FlowProfile for Get operations: $getTestFlowProfileName"
        $null = New-AzDataTransferFlowProfile @testFlowProfileParams
    }

    It 'List' {
        {
            # List all FlowProfiles in the pipeline
            $flowProfiles = Get-AzDataTransferFlowProfile -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName
            $flowProfiles.Count | Should -BeGreaterThan 0
            $flowProfiles | ForEach-Object {
                $_.Name | Should -Not -BeNullOrEmpty
                $_.ReplicationScenario | Should -Not -BeNullOrEmpty
                $_.Status | Should -Not -BeNullOrEmpty
            }
            
            # Verify our test FlowProfile is in the list
            $testFlowProfile = $flowProfiles | Where-Object { $_.Name -eq $getTestFlowProfileName }
            $testFlowProfile | Should -Not -BeNullOrEmpty
            $testFlowProfile.ReplicationScenario | Should -Be "Files"
            $testFlowProfile.Status | Should -Be "Enabled"
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            # Get a specific FlowProfile by name
            $flowProfile = Get-AzDataTransferFlowProfile -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowProfileName $getTestFlowProfileName
            $flowProfile | Should -Not -BeNullOrEmpty
            $flowProfile.Name | Should -Be $getTestFlowProfileName
            $flowProfile.ReplicationScenario | Should -Be "Files"
            $flowProfile.Status | Should -Be "Enabled"
            $flowProfile.Description | Should -Be "Test FlowProfile for Get operations"
            $flowProfile.AntiviruAvSolution | Should -Contain "Defender"
        } | Should -Not -Throw
    }

    It 'GetNonExistentFlowProfile' {
        {
            # Try to get a FlowProfile that doesn't exist
            $nonExistentName = "non-existent-fp-$testRunId"
            { Get-AzDataTransferFlowProfile -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowProfileName $nonExistentName } | Should -Throw
        } | Should -Not -Throw
    }

    It 'GetViaIdentityPipeline' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    AfterAll {
        # ToDo: Clean up the test FlowProfile once Remove is working
    }
}
