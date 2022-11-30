### Example 1: Create an Event Hubs endpoint object
```powershell
$eventHub = New-AzWebPubSubEventHubEndpointObject -EventHubName hub1 -FullyQualifiedNamespace example.servicebus.windows.net
$eventHub
```

```output
EventHubName FullyQualifiedNamespace
------------ -----------------------
hub1         example.servicebus.windows.net
```

