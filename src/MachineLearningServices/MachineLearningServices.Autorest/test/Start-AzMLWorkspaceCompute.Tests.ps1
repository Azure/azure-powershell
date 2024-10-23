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
        {
            Stop-AzMLWorkspaceCompute -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.computeinstance
            Start-TestSleep -Seconds 60
            Start-AzMLWorkspaceCompute -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.computeinstance
        } | Should -Not -Throw
    }
}
