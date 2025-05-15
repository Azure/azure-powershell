### Example 1: Create an AzDigitalTwinsEndpoint for Eventhub
```powershell
New-AzDigitalTwinsEndpoint -EndpointName azps-dt-eh -EndpointType EventHub -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -connectionStringPrimaryKey 'Endpoint=sb://azps-eventhubs.servicebus.windows.net/;SharedAccessKeyName=abc123;SharedAccessKey=******;EntityPath=azps-eh' -AuthenticationType 'KeyBased'
```

```output
Name       EndpointType AuthenticationType ResourceGroupName
----       ------------ ------------------ -----------------
azps-dt-eh EventHub     KeyBased           azps_test_group
```

Create an AzDigitalTwinsEndpoint for Eventhub by connectionStringPrimaryKey

### Example 2: Create an AzDigitalTwinsEndpoint for EventGrid
```powershell
New-AzDigitalTwinsEndpoint -EndpointName azps-dt-eg -EndpointType EventGrid -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -TopicEndpoint 'https://azps-eventgrid.eastus-1.eventgrid.azure.net/api/events' -AccessKey1 '******=' -AuthenticationType 'KeyBased'
```

```output
Name       EndpointType AuthenticationType ResourceGroupName
----       ------------ ------------------ -----------------
azps-dt-eg EventGrid    KeyBased           azps_test_group
```

Create an AzDigitalTwinsEndpoint for Eventhub by TopicEndpoint and accessKey1


### Example 3: Create an AzDigitalTwinsEndpoint for ServiceBus
```powershell
New-AzDigitalTwinsEndpoint -EndpointName azps-dt-sb -EndpointType ServiceBus -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -PrimaryConnectionString "Endpoint=sb://azps-servicebus.servicebus.windows.net/;SharedAccessKeyName=abc123;SharedAccessKey=******;EntityPath=azps-sb" -AuthenticationType 'KeyBased'
```

```output
Name       EndpointType AuthenticationType ResourceGroupName
----       ------------ ------------------ -----------------
azps-dt-sb ServiceBus   KeyBased           azps_test_group
```

Create an AzDigitalTwinsEndpoint for ServicBus by PrimaryConnectionString
