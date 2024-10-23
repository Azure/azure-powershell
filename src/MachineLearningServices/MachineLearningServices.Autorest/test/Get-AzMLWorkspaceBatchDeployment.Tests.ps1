if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspaceBatchDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspaceBatchDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspaceBatchDeployment' {
    It 'List' {
        { Get-AzMLWorkspaceBatchDeployment -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeworkspace -EndpointName $env.batchEndpoint } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzMLWorkspaceBatchDeployment -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeworkspace -EndpointName $env.batchEndpoint -Name $env.batchDeployment } | Should -Not -Throw
    }
}
