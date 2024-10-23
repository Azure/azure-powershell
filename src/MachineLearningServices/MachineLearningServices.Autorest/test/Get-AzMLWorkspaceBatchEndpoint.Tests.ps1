if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspaceBatchEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspaceBatchEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspaceBatchEndpoint' {
    It 'List' {
        {
            Get-AzMLWorkspaceBatchEndpoint -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            Get-AzMLWorkspaceBatchEndpoint -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.batchEndpoint
        } | Should -Not -Throw
    }
}
