### Example 1: Create an AzDigitalTwinsEndpoint for Eventhub
```powershell
New-AzDigitalTwinsEndpoint -EndpointName azps-dt-eh -EndpointType EventHub -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -ConnectionStringPrimaryKey 'Endpoint=sb://azps-eventhubs.servicebus.windows.net/;SharedAccessKeyName=abc123;SharedAccessKey=******;EntityPath=azps-eh' -AuthenticationType 'KeyBased'
```

```output
AuthenticationType           : KeyBased
CreatedTime                  : 2025-06-06 11:16:50 AM
DeadLetterSecret             :
DeadLetterUri                :
EndpointType                 : EventHub
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.DigitalTwins/digitalTwinsInstances/azps-digitaltwins-instance/endpoints/az
                               ps-dt-eh
Name                         : azps-dt-eh
Property                     : {
                                 "endpointType": "EventHub",
                                 "provisioningState": "Succeeded",
                                 "createdTime": "2025-06-06T11:16:50.9480318Z",
                                 "authenticationType": "KeyBased",
                                 "connectionStringPrimaryKey": "Endpoint=sb://(PLACEHOLDER)/;SharedAccessKeyName=(PLACEHOLDER);SharedAccessKey=(PLACEHOLDER);EntityPath=(PLACEHOLDER)"
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group
SystemDataCreatedAt          : 2025-06-06 11:16:50 AM
SystemDataCreatedBy          : xxxxx.xxxxx@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2025-06-06 11:16:50 AM
SystemDataLastModifiedBy     : xxxxx.xxxxx@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.DigitalTwins/digitalTwinsInstances/endpoints
```

Create an AzDigitalTwinsEndpoint for Eventhub by connectionStringPrimaryKey

### Example 2: Create an AzDigitalTwinsEndpoint for EventGrid
```powershell
New-AzDigitalTwinsEndpoint -EndpointName azps-dt-eg -EndpointType EventGrid -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -TopicEndpoint 'https://azps-eventgrid.eastus-1.eventgrid.azure.net/api/events' -AccessKey1 '******=' -AuthenticationType 'KeyBased'
```

```output
AuthenticationType           : KeyBased
CreatedTime                  : 2025-06-06 11:22:11 AM
DeadLetterSecret             :
DeadLetterUri                :
EndpointType                 : EventGrid
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.DigitalTwins/digitalTwinsInstances/azps-digitaltwins-instance/endpoints/az
                               ps-dt-eg
Name                         : azps-dt-eg
Property                     : {
                                 "endpointType": "EventGrid",
                                 "provisioningState": "Succeeded",
                                 "createdTime": "2025-06-06T11:22:11.8112861Z",
                                 "authenticationType": "KeyBased",
                                 "TopicEndpoint": "https://azps-eventgrid.eastus-1.eventgrid.azure.net/api/events",
                                 "accessKey1": "(PLACEHOLDER)"
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group
SystemDataCreatedAt          : 2025-06-06 11:22:11 AM
SystemDataCreatedBy          : xxxxx.xxxxx@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2025-06-06 11:22:11 AM
SystemDataLastModifiedBy     : xxxxx.xxxxx@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.DigitalTwins/digitalTwinsInstances/endpoints
```

Create an AzDigitalTwinsEndpoint for Eventhub by TopicEndpoint and accessKey1


### Example 3: Create an AzDigitalTwinsEndpoint for ServiceBus
```powershell
New-AzDigitalTwinsEndpoint -EndpointName azps-dt-sb -EndpointType ServiceBus -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -PrimaryConnectionString "Endpoint=sb://azps-servicebus.servicebus.windows.net/;SharedAccessKeyName=abc123;SharedAccessKey=******;EntityPath=azps-sb" -AuthenticationType 'KeyBased'
```

```output
AuthenticationType           : KeyBased
CreatedTime                  : 2025-06-06 09:52:54 AM
DeadLetterSecret             :
DeadLetterUri                :
EndpointType                 : ServiceBus
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.DigitalTwins/digitalTwinsInstances/azps-digitaltwins-instance/endpoints/az
                               ps-dt-sb
Name                         : azps-dt-sb
Property                     : {
                                 "endpointType": "ServiceBus",
                                 "provisioningState": "Succeeded",
                                 "createdTime": "2025-06-06T09:52:54.5788470Z",
                                 "authenticationType": "KeyBased",
                                 "primaryConnectionString": "Endpoint=sb://(PLACEHOLDER)/;SharedAccessKeyName=(PLACEHOLDER);SharedAccessKey=(PLACEHOLDER);EntityPath=(PLACEHOLDER)"
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group
SystemDataCreatedAt          : 2025-06-06 09:52:53 AM
SystemDataCreatedBy          : xxxxx.xxxxx@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2025-06-06 09:52:53 AM
SystemDataLastModifiedBy     : xxxxx.xxxxx@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.DigitalTwins/digitalTwinsInstances/endpoints
```

Create an AzDigitalTwinsEndpoint for ServiceBus by PrimaryConnectionString
