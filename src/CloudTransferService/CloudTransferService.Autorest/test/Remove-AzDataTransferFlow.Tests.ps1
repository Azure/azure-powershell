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
            Remove-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $flowToRemove -Confirm:$false | Should -BeNullOrEmpty

            # Ensure the flow is deleted
            $deletedFlow = Get-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:flowToRemove -ErrorAction SilentlyContinue
            $deletedFlow | Should -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Delete and return result' {
        {
            $result = Remove-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:flowToRemove -PassThru -Confirm:$false
            $result | Should -Be $true

            # Ensure the flow is deleted
            $deletedFlow = Get-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $flowToRemove -ErrorAction SilentlyContinue
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
