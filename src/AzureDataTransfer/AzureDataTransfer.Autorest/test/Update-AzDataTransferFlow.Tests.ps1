if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDataTransferFlow'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDataTransferFlow.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$flowToUpdate = "test-flow-to-update-" + $env.RunId
Write-Host "Flow name: $flowToUpdate"

Describe 'Update-AzDataTransferFlow' {
    It 'UpdateTagsForExistingFlow' {
        {
            $flowParams = @{
                ResourceGroupName     = $env.ResourceGroupName
                ConnectionName        = $env.ConnectionLinked
                Name                  = $flowToUpdate
                Location              = $env.Location
                FlowType              = "Mission"
                DataType              = "Blob"
                StorageAccountName    = $env.StorageAccountName
                StorageContainerName  = $env.StorageContainerName
            }
            $createdFlow = New-AzDataTransferFlow @flowParams
            $createdFlow | Should -Not -BeNullOrEmpty

            # Update tags for an existing flow
            $updatedFlow = Update-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $flowToUpdate -Tag @{Environment="Production"; Department="IT"} -Confirm:$false

            # Verify the tags are updated
            $updatedFlow | Should -Not -BeNullOrEmpty
            $updatedFlow.Tags.Environment | Should -Be "Production"
            $updatedFlow.Tags.Department | Should -Be "IT"
        } | Should -Not -Throw
    }

    It 'UpdateTagsForExistingFlow AsJob' {
        {
            # Update tags for the flow as a background job
            $job = Update-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $flowToUpdate -Tag @{Source="Job"; Status="Completed"} -AsJob -Confirm:$false
    
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
    
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
    
            # Verify the tags are updated after the job completes
            $updatedFlow = Get-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $flowToUpdate
            $updatedFlow | Should -Not -BeNullOrEmpty
            $updatedFlow.Tags.Source | Should -Be "Job"
            $updatedFlow.Tags.Status | Should -Be "Completed"
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityConnectionExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    AfterAll {
        # Clean up the created flow
        Remove-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $flowToUpdate -Confirm:$false
    }
}
