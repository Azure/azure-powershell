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

Describe 'Update-AzDataTransferConnection' {
    It 'UpdateTagsForExistingConnection' {
        {
            # Update tags for an existing connection
            Update-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:ConnectionName -Tag @{Environment="Production"; Department="IT"} -Confirm:$false | Should -BeNullOrEmpty

            # Verify the tags are updated
            $updatedConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:ConnectionName
            $updatedConnection | Should -Not -BeNullOrEmpty
            $updatedConnection.Tags.Environment | Should -Be "Production"
            $updatedConnection.Tags.Department | Should -Be "IT"
        } | Should -Not -Throw
    }

    It 'UpdateTagsForNonExistentConnection' {
        {
            # Attempt to update tags for a non-existent connection
            Update-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name "NonExistentConnection" -Tag @{Environment="Production"; Department="IT"} -Confirm:$false
        } | Should -Throw
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
}
