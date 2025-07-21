---
external help file: Az.DigitalTwins-help.xml
Module Name: Az.DigitalTwins
online version: https://learn.microsoft.com/powershell/module/az.digitaltwins/update-azdigitaltwinsendpoint
schema: 2.0.0
---

# Update-AzDigitalTwinsEndpoint

## SYNOPSIS
Update DigitalTwinsInstance endpoint.

## SYNTAX

### EventHub (Default)
```
Update-AzDigitalTwinsEndpoint -EndpointName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] -EndpointType <String> -ConnectionStringPrimaryKey <String>
 [-EndpointDescription <IDigitalTwinsEndpointResource>] [-AuthenticationType <String>]
 [-ConnectionStringSecondaryKey <String>] [-DeadLetterSecret <String>] [-DeadLetterUri <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ServiceBus
```
Update-AzDigitalTwinsEndpoint -EndpointName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] -EndpointType <String> [-EndpointDescription <IDigitalTwinsEndpointResource>]
 [-AuthenticationType <String>] [-DeadLetterUri <String>] -PrimaryConnectionString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### EventGrid
```
Update-AzDigitalTwinsEndpoint -EndpointName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] -EndpointType <String> [-EndpointDescription <IDigitalTwinsEndpointResource>]
 [-AuthenticationType <String>] [-DeadLetterUri <String>] -TopicEndpoint <String> -AccessKey1 <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update DigitalTwinsInstance endpoint.

## EXAMPLES

### Example 1: Update an AzDigitalTwinsEndpoint for Eventhub
```powershell
Update-AzDigitalTwinsEndpoint -EndpointName azps-dt-eh -EndpointType EventHub -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -ConnectionStringPrimaryKey 'Endpoint=sb://azps-eventhubs.servicebus.windows.net/;SharedAccessKeyName=abc123;SharedAccessKey=******;EntityPath=azps-eh' -AuthenticationType 'KeyBased'
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

Update an AzDigitalTwinsEndpoint for Eventhub by connectionStringPrimaryKey

### Example 2: Update an AzDigitalTwinsEndpoint for EventGrid
```powershell
Update-AzDigitalTwinsEndpoint -EndpointName azps-dt-eg -EndpointType EventGrid -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -TopicEndpoint 'https://azps-eventgrid.eastus-1.eventgrid.azure.net/api/events' -AccessKey1 '******=' -AuthenticationType 'KeyBased'
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
SystemDataLastModifiedAt     : 2025-06-06 11:22:48 AM
SystemDataLastModifiedBy     : xxxxx.xxxxx@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.DigitalTwins/digitalTwinsInstances/endpoints
```

Update an AzDigitalTwinsEndpoint for Eventhub by TopicEndpoint and accessKey1

### Example 3: Update an AzDigitalTwinsEndpoint for ServiceBus
```powershell
Update-AzDigitalTwinsEndpoint -EndpointName azps-dt-sb -EndpointType ServiceBus -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -PrimaryConnectionString "Endpoint=sb://azps-servicebus.servicebus.windows.net/;SharedAccessKeyName=abc123;SharedAccessKey=******;EntityPath=azps-sb" -AuthenticationType 'KeyBased'
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

Update an AzDigitalTwinsEndpoint for ServicBus by PrimaryConnectionString

## PARAMETERS

### -AccessKey1
The subscription identifier.

```yaml
Type: System.String
Parameter Sets: EventGrid
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthenticationType
Specifies the authentication type being used for connecting to the endpoint.
Defaults to 'KeyBased'.
If 'KeyBased' is selected, a connection string must be specified (at least the primary connection string).
If 'IdentityBased' is select, the endpointUri and entityPath properties must be specified.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionStringPrimaryKey
The subscription identifier.

```yaml
Type: System.String
Parameter Sets: EventHub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionStringSecondaryKey
The subscription identifier.

```yaml
Type: System.String
Parameter Sets: EventHub
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeadLetterSecret
Dead letter storage secret for key-based authentication.
Will be obfuscated during read.

```yaml
Type: System.String
Parameter Sets: EventHub
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeadLetterUri
Dead letter storage URL for identity-based authentication.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointDescription
DigitalTwinsInstance endpoint resource.
To construct, see NOTES section for ENDPOINTDESCRIPTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsEndpointResource
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EndpointName
Name of Endpoint Resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointType
The type of Digital Twins endpoint

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrimaryConnectionString
The subscription identifier.

```yaml
Type: System.String
Parameter Sets: ServiceBus
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the DigitalTwinsInstance.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the DigitalTwinsInstance.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription identifier.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopicEndpoint
The subscription identifier.

```yaml
Type: System.String
Parameter Sets: EventGrid
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsEndpointResource

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsEndpointResource

## NOTES

## RELATED LINKS
