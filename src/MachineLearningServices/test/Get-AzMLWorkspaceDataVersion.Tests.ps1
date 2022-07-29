if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspaceDataVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspaceDataVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspaceDataVersion' {
    It 'List' {
        { Get-AzMLWorkspaceDataVersion  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name iris-data } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzMLWorkspaceDataVersion  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name iris-data -Version 1} | Should -Not -Throw
    }
}
