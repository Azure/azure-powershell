if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspaceConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspaceConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspaceConnection' {
    It 'List' {
        { Get-AzMLWorkspaceConnection -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzMLWorkspaceConnection -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name test } | Should -Not -Throw
    }
}
