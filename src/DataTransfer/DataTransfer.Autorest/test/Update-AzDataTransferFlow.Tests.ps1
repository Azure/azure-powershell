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
            $updatedFlow.Tag["Environment"] | Should -Be "Production"
            $updatedFlow.Tag["Department"] | Should -Be "IT"
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
