if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzWorkloadsSapVirtualInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWorkloadsSapVirtualInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzWorkloadsSapVirtualInstance' {
    It 'Delete' {
        $deletedVIS = Remove-AzWorkloadsSapVirtualInstance -Name $env.DeletionVIS -ResourceGroupName $env.DeletionRG
        $deletedVIS.Status | Should -Be $env.ProvisioningState
    }

    It 'DeleteViaIdentity' {
        $deletedVIS = Remove-AzWorkloadsSapVirtualInstance -InputObject $env.DeletionVISID
        $deletedVIS.Status | Should -Be $env.ProvisioningState
    }
}
