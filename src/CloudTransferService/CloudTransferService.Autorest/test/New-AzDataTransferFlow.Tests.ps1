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

$flowToCreate = "test-flow-" + -join ((65..90) + (97..122) | Get-Random -Count 6 | ForEach-Object {[char]$_})
Describe 'New-AzDataTransferFlow' {
    $flowParams = @{
        ResourceGroupName     = $env.ResourceGroupName
        ConnectionName        = $env.ConnectionLinked
        Name                  = $flowToCreate
        Location              = $env.Location
        FlowType              = "Mission"
        DataType              = "Blob"
        StorageAccountName    = $env.StorageAccountName
        StorageContainerName  = $env.StorageContainerName
    }

    It 'CreateNewFlow' {
        {
            # Create a new flow
            $createdFlow =  New-AzDataTransferFlow @flowParams

            # Verify the flow is created
            $createdFlow | Should -Not -BeNullOrEmpty
            $createdFlow.Name | Should -Be $flowToCreate
            $createdFlow.Location | Should -Be $env.Location
            $createdFlow.FlowType | Should -Be "Mission"
            $createdFlow.DataType | Should -Be "Blob"
            $createdFlow.StorageAccountName | Should -Be $env.StorageAccountName
            $createdFlow.StorageContainerName | Should -Be $env.StorageContainerName
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

    AfterAll {
        # Clean up the created flow
        Remove-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $flowToCreate
    }
}
