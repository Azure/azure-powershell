### Example 1: Add two event handlers for a hub
```powershell
$eventHandler = @{UrlTemplate = 'http://example.com/api/{hub}/connect/{event}' ; AuthType = 'None' ; SystemEvent = 'connect' ; } ,
        @{ UrlTemplate = 'http://example.com/api/{hub}/userevent/{event}' ; AuthType = 'None' ; UserEventPattern = '*' }

New-AzWebPubSubHub -Name testHub -ResourceGroupName psdemo -ResourceName psdemo-wps -EventHandler $eventHandler
```

```output
Name    AnonymousConnectPolicy
----    ----------------------
testHub deny
```

The example first creates a list of hash tables containing two event handler settings, one for system events and the other for user events. Then it creates a hub with the event handlers.

### Example 2: Add two event listeners for a hub
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

$hub = New-AzWebPubSubHub -Name hub2 -ResourceGroupName rg -ResourceName psdemo -EventListener $eventListeners
```

```output
Name    AnonymousConnectPolicy
----    ----------------------
hub2 deny
```
The example first creates a list of hash tables containing two event listener settings, one for system events and the other for user events. Then it creates a hub with the event handlers.
