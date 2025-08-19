if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDataTransferFlow'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDataTransferFlow.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDataTransferFlow' {
    It 'Delete' {
        {
            $flowToDelete = "test-flow-to-delete-1-" + $env.RunId
            Write-Host "Flow name: $flowToDelete"

            $flowParams = @{
                ResourceGroupName     = $env.ResourceGroupName
                ConnectionName        = $env.ConnectionLinked
                Name                  = $flowToDelete
                Location              = $env.Location
                FlowType              = "Mission"
                DataType              = "Blob"
                StorageAccountName    = $env.StorageAccountName
                StorageContainerName  = $env.StorageContainerName
            }
            $createdFlow =  New-AzDataTransferFlow @flowParams
            $createdFlow | Should -Not -BeNullOrEmpty

            Remove-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $flowToDelete -Confirm:$false | Should -BeNullOrEmpty

            # Ensure the flow is deleted
            $deletedFlow = Get-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $flowToDelete -ErrorAction SilentlyContinue
            $deletedFlow | Should -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Delete and return result' {
        {
            $flowToDelete = "test-flow-to-delete-2-" + $env.RunId
            Write-Host "Flow name: $flowToDelete"

            $flowParams = @{
                ResourceGroupName     = $env.ResourceGroupName
                ConnectionName        = $env.ConnectionLinked
                Name                  = $flowToDelete
                Location              = $env.Location
                FlowType              = "Mission"
                DataType              = "Blob"
                StorageAccountName    = $env.StorageAccountName
                StorageContainerName  = $env.StorageContainerName
            }
            $createdFlow =  New-AzDataTransferFlow @flowParams
            $createdFlow | Should -Not -BeNullOrEmpty

            $result = Remove-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $flowToDelete -PassThru -Confirm:$false
            $result | Should -Be $true

            # Ensure the flow is deleted
            $deletedFlow = Get-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $flowToDelete -ErrorAction SilentlyContinue
            $deletedFlow | Should -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Delete AsJob' {
        {
            # Create a new flow to delete
            $flowToDelete = "test-flow-delete-asjob-" + $env.RunId
            Write-Host "Flow name: $flowToDelete"
    
            $flowParams = @{
                ResourceGroupName     = $env.ResourceGroupName
                ConnectionName        = $env.ConnectionLinked
                Name                  = $flowToDelete
                Location              = $env.Location
                FlowType              = "Mission"
                DataType              = "Blob"
                StorageAccountName    = $env.StorageAccountName
                StorageContainerName  = $env.StorageContainerName
            }
    
            $createdFlow = New-AzDataTransferFlow @flowParams
            $createdFlow | Should -Not -BeNullOrEmpty
    
            # Remove the flow as a background job
            $job = Remove-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $flowToDelete -AsJob -Confirm:$false
    
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
    
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true

            # Ensure the flow is deleted
            $deletedFlow = Get-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $flowToDelete -ErrorAction SilentlyContinue
            $deletedFlow | Should -BeNullOrEmpty
        } | Should -Not -Throw
    }
    
    It 'DeleteViaIdentityConnection' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
