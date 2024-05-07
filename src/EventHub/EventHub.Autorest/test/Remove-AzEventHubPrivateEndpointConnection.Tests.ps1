if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEventHubPrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEventHubPrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEventHubPrivateEndpointConnection' {
    $listOfPrivateEndpoints = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
    It 'Delete'  {
        Remove-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $listOfPrivateEndpoints[0].Name
        { Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $listOfPrivateEndpoints[0].Name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity'  {
        $privateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $listOfPrivateEndpoints[1].Name
        Remove-AzEventHubPrivateEndpointConnection -InputObject $privateEndpoint
        { Get-AzEventHubPrivateEndpointConnection -InputObject $privateEndpoint -ErrorAction Stop } | Should -Throw
    }
}
