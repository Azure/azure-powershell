if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspaceCompute'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspaceCompute.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspaceCompute' {
    It 'List' {
        {
            Get-AzMLWorkspaceCompute -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            Get-AzMLWorkspaceCompute -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.computeinstance
        } | Should -Not -Throw
    }
}
