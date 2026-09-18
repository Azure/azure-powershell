if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDataTransferConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDataTransferConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$connectionToUpdate = "test-connection-update-" + $env.RunId
Write-Host "Connection name: $connectionToUpdate"

Describe 'Update-AzDataTransferConnection' {
    It 'UpdateTagsForExistingConnection' {
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
                Name                 = $connectionToUpdate
                PrimaryContact       = "faikh@microsoft.com"
            }
            $createdConnection = New-AzDataTransferConnection @connectionParams
            $createdConnection | Should -Not -BeNullOrEmpty

            # Update tags for an existing connection
            $updatedConnection = Update-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToUpdate -Tag @{Environment="Production"; Department="IT"} -Confirm:$false

            # Verify the tags are updated
            $updatedConnection | Should -Not -BeNullOrEmpty
            $updatedConnection.Tag["Environment"] | Should -Be "Production"
            $updatedConnection.Tag["Department"] | Should -Be "IT"
        } | Should -Not -Throw
    }

    It 'UpdateTagsForExistingConnection AsJob' {
        {
            # Update tags for the connection as a background job
            $job = Update-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToUpdate -Tag @{Source="Job"; Domain="Ops"} -AsJob -Confirm:$false
    
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
    
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
    
            # Verify the tags are updated after the job completes
            $updatedConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToUpdate
            $updatedConnection | Should -Not -BeNullOrEmpty
            $updatedConnection.Tag["Source"] | Should -Be "Job"
            $updatedConnection.Tag["Domain"] | Should -Be "Ops"
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    AfterAll {
        # Clean up the created connection
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToUpdate -Confirm:$false
    }
}
