### Example 1: Update a hub setting.
```powershell
$eventHandler = @{UrlTemplate = 'http://example.com/api/{hub}/connect/{event}' ; AuthType = 'None' ; SystemEvent = 'connect' ; } ,
        @{ UrlTemplate = 'http://example.com/api/{hub}/userevent/{event}' ; AuthType = 'None' ; UserEventPattern = '*' }
Update-AzWebPubSubHub -Name testHub -ResourceGroupName psdemo -ResourceName psdemo-wps -EventHandler $eventHandler
```

```output
Name    AnonymousConnectPolicy
----    ----------------------
testHub deny
```

Update a hub setting.

### Example 2: Update a hub setting.
```powershell
$eventListeners =
@{
    Endpoint = $(New-AzWebPubSubEventHubEndpointObject -EventHubName connectivityHub -FullyQualifiedNamespace example.servicebus.windows.net);
    Filter = $(New-AzWebPubSubEventNameFilterObject -SystemEvent connected, disconnected)
},
@{
    Endpoint = $(New-AzWebPubSubEventHubEndpointObject -EventHubName messageHub -FullyQualifiedNamespace example.servicebus.windows.net);
    Filter = $(New-AzWebPubSubEventNameFilterObject -UserEventPattern *)
}
$hub = Update-AzWebPubSubHub -Name hub2 -ResourceGroupName rg -ResourceName psdemo -EventListener $eventListeners
```

```output
Name    AnonymousConnectPolicy
----    ----------------------
hub2 deny
```

Update a hub setting.