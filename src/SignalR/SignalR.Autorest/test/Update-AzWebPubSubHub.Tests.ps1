if(($null -eq $TestName) -or ($TestName -contains 'Update-AzWebPubSubHub'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWebPubSubHub.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzWebPubSubHub' {
    It 'UpdateExpanded' {
        $hubName = "hub" + "removehub" + "Delete"
        New-AzWebPubSubHub -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1 -Name $hubName

        $eventHandlers = @{UrlTemplate = 'http://example.com/api/{hub}/connect/{event}' ; AuthType = 'None' ; SystemEvent = 'connect' ; } ,
        @{ UrlTemplate = 'http://example.com/api/{hub}/userevent/{event}' ; AuthType = 'None' ; UserEventPattern = '*' }

        $eventListeners =
        @{
            Endpoint = $(New-AzWebPubSubEventHubEndpointObject -EventHubName connectivityHub -FullyQualifiedNamespace example.servicebus.windows.net);
            Filter = $(New-AzWebPubSubEventNameFilterObject -SystemEvent connected, disconnected)
        },
        @{
            Endpoint = $(New-AzWebPubSubEventHubEndpointObject -EventHubName messageHub -FullyQualifiedNamespace example.servicebus.windows.net);
            Filter = $(New-AzWebPubSubEventNameFilterObject -UserEventPattern *)
        }

        $hub = Update-AzWebPubSubHub -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1 -Name $hubName -EventHandler $eventHandlers -EventListener $eventListeners

        $hub.Name | Should -Be $hubName
        $hub.EventHandler | Should -HaveCount 2
        $hub.EventListener | Should -HaveCount 2
    }
}
