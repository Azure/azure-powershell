if(($null -eq $TestName) -or ($TestName -contains 'New-AzMLWorkspaceEnvironmentVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMLWorkspaceEnvironmentVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMLWorkspaceEnvironmentVersion' {
    It 'CreateExpanded' {
        { 
            New-AzMLWorkspaceEnvironmentVersion -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name commandjobenv -Version 1 -Image "library/python:latest" 
            Remove-AzMLWorkspaceEnvironmentVersion -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name commandjobenv -Version 1 
        } | Should -Not -Throw
    }
}
