if(($null -eq $TestName) -or ($TestName -contains 'Start-AzMLWorkspaceCompute'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzMLWorkspaceCompute.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzMLWorkspaceCompute' {
    It 'ComputeInstance' {
        { Start-AzMLWorkspaceCompute -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name v-diya1 } | Should -Not -Throw
    }
}
