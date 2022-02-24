if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDatabricksOutboundNetworkDependenciesEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDatabricksOutboundNetworkDependenciesEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDatabricksOutboundNetworkDependenciesEndpoint' {
    It 'List' {
        { 
            Get-AzDatabricksOutboundNetworkDependenciesEndpoint -WorkspaceName $env.testWorkspace4 -ResourceGroupName $env.resourceGroup
            # The virtual network only be use by one workspace.
            Remove-AzDatabricksWorkspace -Name $env.testWorkspace4 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
