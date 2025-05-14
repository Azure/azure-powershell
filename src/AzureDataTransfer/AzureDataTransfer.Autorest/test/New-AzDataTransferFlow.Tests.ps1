if(($null -eq $TestName) -or ($TestName -contains 'New-AzDataTransferFlow'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataTransferFlow.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDataTransferFlow' {
    It 'CreateNewFlow' {
        {
            # Create a new flow
            New-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowName -Location $env:Location -FlowType "Mission" -DataType "Blob" -StorageAccountName $env:StorageAccountName -StorageContainerName $env:StorageContainerName -Confirm:$false | Should -BeNullOrEmpty

            # Verify the flow is created
            $createdFlow = Get-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowName
            $createdFlow | Should -Not -BeNullOrEmpty
            $createdFlow.Name | Should -Be $env:FlowName
        } | Should -Not -Throw
    }

    It 'CreateExistingFlow' {
        {
            # Ensure the flow already exists
            New-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowName -Location $env:Location -FlowType "Mission" -DataType "Blob" -StorageAccountName $env:StorageAccountName -StorageContainerName $env:StorageContainerName -Confirm:$false | Should -BeNullOrEmpty

            # Attempt to create the same flow again
            New-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowName -Location $env:Location -FlowType "Mission" -DataType "Blob" -StorageAccountName $env:StorageAccountName -StorageContainerName $env:StorageContainerName -Confirm:$false | Should -BeNullOrEmpty

            # Verify the flow still exists and no duplicate is created
            $existingFlow = Get-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowName
            $existingFlow | Should -Not -BeNullOrEmpty
            $existingFlow.Name | Should -Be $env:FlowName
        } | Should -Not -Throw
    }

    It 'CreateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
