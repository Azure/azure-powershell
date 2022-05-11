---
external help file:
Module Name: Az.EventGrid
online version: https://docs.microsoft.com/en-us/powershell/module/az.eventgrid/new-azeventgridchannel
schema: 2.0.0
---

# New-AzEventGridChannel

## SYNOPSIS
Synchronously creates or updates a new channel with the specified parameters.

## SYNTAX

```
New-AzEventGridChannel -Name <String> -PartnerNamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ChannelType <ChannelType>] [-EventTypeInfoInlineEventType <Hashtable>]
 [-EventTypeInfoKind <EventDefinitionKind>] [-ExpirationTimeIfNotActivatedUtc <DateTime>]
 [-MessageForActivation <String>] [-PartnerDestinationInfoAzureSubscriptionId <String>]
 [-PartnerDestinationInfoEndpointServiceContext <String>] [-PartnerDestinationInfoName <String>]
 [-PartnerDestinationInfoResourceGroupName <String>]
 [-PartnerDestinationInfoResourceMoveChangeHistory <IResourceMoveChangeHistory[]>]
 [-PartnerTopicInfoAzureSubscriptionId <String>] [-PartnerTopicInfoName <String>]
 [-PartnerTopicInfoResourceGroupName <String>] [-PartnerTopicInfoSource <String>]
 [-ProvisioningState <ChannelProvisioningState>] [-ReadinessState <ReadinessState>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Synchronously creates or updates a new channel with the specified parameters.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -ChannelType
The type of the event channel which represents the direction flow of events.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Support.ChannelType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -EventTypeInfoInlineEventType
A collection of inline event types for the resource.
The inline event type keys are of type string which represents the name of the event.An example of a valid inline event name is "Contoso.OrderCreated".The inline event type values are of type InlineEventProperties and will contain additional information for every inline event type.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventTypeInfoKind
The kind of event type used.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Support.EventDefinitionKind
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpirationTimeIfNotActivatedUtc
Expiration time of the channel.
If this timer expires while the corresponding partner topic is never activated,the channel and corresponding partner topic are deleted.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MessageForActivation
Context or helpful message that can be used during the approval process by the subscriber.

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

### -Name
Name of the channel.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ChannelName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerDestinationInfoAzureSubscriptionId
Azure subscription ID of the subscriber.
The partner destination associated with the channel will becreated under this Azure subscription.

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

### -PartnerDestinationInfoEndpointServiceContext
Additional context of the partner destination endpoint.

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

### -PartnerDestinationInfoName
Name of the partner destination associated with the channel.

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

### -PartnerDestinationInfoResourceGroupName
Azure Resource Group of the subscriber.
The partner destination associated with the channel will becreated under this resource group.

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

### -PartnerDestinationInfoResourceMoveChangeHistory
Change history of the resource move.
To construct, see NOTES section for PARTNERDESTINATIONINFORESOURCEMOVECHANGEHISTORY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.Api20211015Preview.IResourceMoveChangeHistory[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerNamespaceName
Name of the partner namespace.

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

### -PartnerTopicInfoAzureSubscriptionId
Azure subscription ID of the subscriber.
The partner topic associated with the channel will becreated under this Azure subscription.

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

### -PartnerTopicInfoName
Name of the partner topic associated with the channel.

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

### -PartnerTopicInfoResourceGroupName
Azure Resource Group of the subscriber.
The partner topic associated with the channel will becreated under this resource group.

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

### -PartnerTopicInfoSource
The source information is provided by the publisher to determine the scope or context from which the eventsare originating.
This information can be used by the subscriber during the approval process of thecreated partner topic.

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

### -PassThru
Returns true when the command succeeds

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

### -ProvisioningState
Provisioning state of the channel.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Support.ChannelProvisioningState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadinessState
The readiness state of the corresponding partner topic.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Support.ReadinessState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the partners subscription.

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
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.Api20211015Preview.IChannel

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


PARTNERDESTINATIONINFORESOURCEMOVECHANGEHISTORY <IResourceMoveChangeHistory[]>: Change history of the resource move.
  - `[AzureSubscriptionId <String>]`: Azure subscription ID of the resource.
  - `[ChangedTimeUtc <DateTime?>]`: UTC timestamp of when the resource was changed.
  - `[ResourceGroupName <String>]`: Azure Resource Group of the resource.

## RELATED LINKS

