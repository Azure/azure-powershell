### Example 1: Create an AzDigitalTwinsEndpoint for Eventhub
```powershell
New-AzDigitalTwinsEndpoint -EndpointName youriEventHubEndPoint -EndpointType EventHub -ResourceGroupName youritemp -ResourceName youriDigitalTwins -connectionStringPrimaryKey 'Endpoint=sb://yourieventhubnp.servicebus.windows.net/;SharedAccessKeyName=youriEventhubPolicy;SharedAccessKey=********;EntityPath=yourieventhub'
```

```output
Name                  Type
----                  ----
youriEventHubEndPoint Microsoft.DigitalTwins/digitalTwinsInstances/endpoints
```

Create an AzDigitalTwinsEndpoint for Eventhub by connectionStringPrimaryKey

### Example 2: Create an AzDigitalTwinsEndpoint for EventGrid
```powershell
New-AzDigitalTwinsEndpoint -EndpointName youriEventGridPoint -EndpointType EventGrid -ResourceGroupName youritemp -ResourceName youriDigitalTwins -TopicEndpoint 'https://yourieventgrid.eastus-1.eventgrid.azure.net/api/events' -AccessKey1 'xxxxxxxxx='
```

```output
Name                  Type
----                  ----
youriEventGridPoint Microsoft.DigitalTwins/digitalTwinsInstances/endpoints
```

Create an AzDigitalTwinsEndpoint for Eventhub by TopicEndpoint and accessKey1


### Example 3: Create an AzDigitalTwinsEndpoint for ServiceBus
```powershell
New-AzDigitalTwinsEndpoint -EndpointName youriServiceBusPoint -EndpointType ServiceBus -ResourceGroupName youritemp -ResourceName youriDigitalTwins -PrimaryConnectionString "Endpoint=sb://yourieventhubnp.servicebus.windows.net/;SharedAccessKeyName=******;SharedAccessKey=********;EntityPath=yourieventhub"
```

```output
Name                  Type
----                  ----
youriServiceBusPoint Microsoft.DigitalTwins/digitalTwinsInstances/endpoints
```

Create an AzDigitalTwinsEndpoint for ServicBus by PrimaryConnectionString
