if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDedicatedHsmOutboundNetworkDependencyEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDedicatedHsmOutboundNetworkDependencyEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDedicatedHsmOutboundNetworkDependencyEndpoint' {
    It 'List' {
        { Get-AzDedicatedHsmOutboundNetworkDependencyEndpoint -Name  $env.dedicatedHsmName01 -ResourceGroupName $env.resourceGroup} | Should -Not -Throw
    }
}
