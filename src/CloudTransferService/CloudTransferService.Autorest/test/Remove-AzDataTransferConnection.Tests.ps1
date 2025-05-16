if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDataTransferConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDataTransferConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDataTransferConnection' {
    It 'Delete' {
        {
            Remove-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:connectionToRemove -Confirm:$false | Should -BeNullOrEmpty

            # Ensure the connection is deleted
            $deletedConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:connectionToRemove -ErrorAction SilentlyContinue
            $deletedConnection | Should -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Delete and return result' {
        {
            $result = Remove-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:connectionToRemove -PassThru -Confirm:$false
            $result | Should -Be $true

            # Ensure the connection is deleted
            $deletedConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:connectionToRemove -ErrorAction SilentlyContinue
            $deletedConnection | Should -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
