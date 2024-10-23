if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspaceEnvironmentVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspaceEnvironmentVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspaceEnvironmentVersion' {
    It 'List' {
        { Get-AzMLWorkspaceEnvironmentVersion  -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name batchenv1 } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzMLWorkspaceEnvironmentVersion  -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name batchenv1 -Version 1 } | Should -Not -Throw
    }
}
