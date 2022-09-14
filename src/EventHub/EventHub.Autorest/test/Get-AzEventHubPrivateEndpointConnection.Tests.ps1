if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEventHubPrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEventHubPrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEventHubPrivateEndpointConnection' {
    $listOfPrivateEndpoints = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
    
    It 'List' {
        $listOfPrivateEndpoints.Count | Should -Be 2
    }

    It 'Get' {
        $privateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $listOfPrivateEndpoints[0].Name
        $privateEndpoint.ConnectionState | Should -Be "Rejected"
        $privateEndpoint.Description | Should -Be ""
    }

    It 'GetViaIdentity' {
        $privateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $listOfPrivateEndpoints[1].Name
        $privateEndpoint = Get-AzEventHubPrivateEndpointConnection -InputObject $privateEndpoint
        $privateEndpoint.ConnectionState | Should -Be "Rejected"
        $privateEndpoint.Description | Should -Be "Bye"
    }
}
