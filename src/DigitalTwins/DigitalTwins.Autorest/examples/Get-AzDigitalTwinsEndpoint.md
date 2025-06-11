### Example 1: List AzDigitalTwinsEndpoint in ResourceGroup
```powershell
Get-AzDigitalTwinsEndpoint -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance
```

```output
Name       EndpointType AuthenticationType ResourceGroupName
----       ------------ ------------------ -----------------
azps-dt-sb ServiceBus   KeyBased           azps_test_group
azps-dt-eh EventHub     KeyBased           azps_test_group
azps-dt-eg EventGrid    KeyBased           azps_test_group
```

List all AzDigitalTwinsEndpoints by ResourceGroupName

### Example 2: Get AzDigitalTwinsEndpoint by EndpointName
```powershell
Get-AzDigitalTwinsEndpoint -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -EndpointName azps-dt-eh
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
SystemDataLastModifiedAt     : 2025-06-06 11:18:27 AM
SystemDataLastModifiedBy     : xxxxx.xxxxx@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.DigitalTwins/digitalTwinsInstances/endpoints
```

Get AzDigitalTwinsEndpoint by EndpointName in ResourceGroup