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
    It 'SetExpanded' {
        $privateEndpoint = Deny-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.pe1
        $privateEndpoint.ConnectionState | Should -Be "Rejected"
        $privateEndpoint.Description | Should -Be ""
    }

    It 'SetViaIdentityExpanded' {
        $privateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.pe2

        $privateEndpoint = Deny-AzEventHubPrivateEndpointConnection -InputObject $privateEndpoint -Description "Bye"
        $privateEndpoint.ConnectionState | Should -Be "Rejected"
        $privateEndpoint.Description | Should -Be "Bye"
    }
}
