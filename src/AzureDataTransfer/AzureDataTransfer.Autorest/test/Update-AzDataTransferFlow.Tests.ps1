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

Describe 'Update-AzDataTransferFlow' {
    It 'UpdateTagsForExistingFlow' {
        {
            # Update tags for an existing flow
            Update-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowName -Tag @{Environment="Production"; Department="IT"} -Confirm:$false | Should -BeNullOrEmpty

            # Verify the tags are updated
            $updatedFlow = Get-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowName
            $updatedFlow | Should -Not -BeNullOrEmpty
            $updatedFlow.Tags.Environment | Should -Be "Production"
            $updatedFlow.Tags.Department | Should -Be "IT"
        } | Should -Not -Throw
    }

    It 'UpdateTagsForNonExistentFlow' {
        {
            # Attempt to update tags for a non-existent flow
            Update-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name "NonExistentFlow" -Tag @{Environment="Production"; Department="IT"} -Confirm:$false
        } | Should -Throw
    }

    It 'UpdateViaIdentityConnectionExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
