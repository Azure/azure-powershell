if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzServiceBusPrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzServiceBusPrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzServiceBusPrivateEndpointConnection' {
    $listOfPrivateEndpoints = Get-AzServiceBusPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
    It 'Delete'  {
        Remove-AzServiceBusPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $listOfPrivateEndpoints[0].Name
        { Get-AzServiceBusPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $listOfPrivateEndpoints[0].Name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity'  {
        $privateEndpoint = Get-AzServiceBusPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $listOfPrivateEndpoints[1].Name
        Remove-AzServiceBusPrivateEndpointConnection -InputObject $privateEndpoint
        { Get-AzServiceBusPrivateEndpointConnection -InputObject $privateEndpoint -ErrorAction Stop } | Should -Throw
    }
}
