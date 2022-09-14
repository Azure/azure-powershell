if(($null -eq $TestName) -or ($TestName -contains 'Deny-AzEventHubPrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Deny-AzEventHubPrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Deny-AzEventHubPrivateEndpointConnection' {
    $privateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace

    It 'SetExpanded' {
        $privateEndpoint[0].ConnectionState | Should -Be "Approved"
        $privateEndpoint[0].Description | Should -Be ""
        
        $firstPrivateEndpoint = Deny-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $privateEndpoint[0].Name
        $firstPrivateEndpoint.ConnectionState | Should -Be "Rejected"
        $firstPrivateEndpoint.Description | Should -Be ""
    }

    It 'SetViaIdentityExpanded' {
        $secondPrivateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $privateEndpoint[1].Name

        $secondPrivateEndpoint = Deny-AzEventHubPrivateEndpointConnection -InputObject $secondPrivateEndpoint -Description "Bye"
        $secondPrivateEndpoint.ConnectionState | Should -Be "Rejected"
        $secondPrivateEndpoint.Description | Should -Be "Bye"
    }
}
