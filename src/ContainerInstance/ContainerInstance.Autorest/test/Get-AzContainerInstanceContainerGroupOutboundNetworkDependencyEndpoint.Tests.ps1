if(($null -eq $TestName) -or ($TestName -contains 'Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint' {
    It 'Get' {
        { 
            Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint -ResourceGroupName $env.resourceGroupName -ContainerGroupName $env.containerGroupName
        }
    }

    It 'GetViaIdentity' {
        { 
            $get = Update-AzContainerGroup -Name $env.containerGroupName -ResourceGroupName $env.resourceGroupName -Tag @{"key"="value"}
            Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint -InputObject $get
        }
    }
}
