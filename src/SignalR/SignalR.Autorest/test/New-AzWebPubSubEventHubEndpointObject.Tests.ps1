if(($null -eq $TestName) -or ($TestName -contains 'New-AzWebPubSubEventHubEndpointObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWebPubSubEventHubEndpointObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWebPubSubEventHubEndpointObject' {
    It '__AllParameterSets' {
        $eventHubEndpoint = New-AzWebPubSUbEventHubEndpointObject -EventHubName "hub1" -FullyQualifiedNamespace "example.servicebus.windows.net"
        $eventHubEndpoint.EventHubName | Should -Be "hub1"
        $eventHubEndpoint.FullyQualifiedNamespace | Should -Be "example.servicebus.windows.net"
    }
}
