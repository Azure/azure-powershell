if(($null -eq $TestName) -or ($TestName -contains 'RemoveOperationsAzWorkloads'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'RemoveOperationsAzWorkloads.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'RemoveOperationsAzWorkloads' {
    It 'RemoveOperationsAzWorkloads' {
        $RemoveOperationsAzWorkloadsResponse = Remove-AzWorkloadsSapVirtualInstance -Name $env.DeletionVIS -ResourceGroupName $env.DeletionRG
        $RemoveOperationsAzWorkloadsResponse.Status | Should -Be $null
    }

    It 'RemoveOperationsAzWorkloadsAlias' {
        $RemoveOperationsAzWorkloadsAliasResponse = Remove-AzVIS -Name $env.DeletionVIS -ResourceGroupName $env.DeletionRG
        $RemoveOperationsAzWorkloadsAliasResponse.Status | Should -Be $null
    }
}
