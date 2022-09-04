if(($null -eq $TestName) -or ($TestName -contains 'Approve-AzEventHubPrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Approve-AzEventHubPrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Approve-AzEventHubPrivateEndpointConnection' {
    It 'SetExpanded' {
        $privateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $privateEndpoint[0].ConnectionState | Should -Be "Pending"
        $privateEndpoint[0].Description | Should -Be "Hello"

        $env.Add("pe1", $privateEndpoint[0].Name)
        $env.Add("pe2", $privateEndpoint[1].Name)

        $privateEndpoint = Approve-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.pe1
        $privateEndpoint.ConnectionState | Should -Be "Approved"
        $privateEndpoint.Description | Should -Be ""
    }

    It 'SetViaIdentityExpanded' {
        $privateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.pe2

        $privateEndpoint = Approve-AzEventHubPrivateEndpointConnection -InputObject $privateEndpoint -Description "Bye"
        $privateEndpoint.ConnectionState | Should -Be "Approved"
        $privateEndpoint.Description | Should -Be "Bye"
    }
}
