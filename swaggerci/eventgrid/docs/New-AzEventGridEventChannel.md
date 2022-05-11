---
external help file:
Module Name: Az.EventGrid
online version: https://docs.microsoft.com/en-us/powershell/module/az.eventgrid/new-azeventgrideventchannel
schema: 2.0.0
---

# New-AzEventGridEventChannel

## SYNOPSIS
Asynchronously creates a new event channel with the specified parameters.

## SYNTAX

```
New-AzEventGridEventChannel -Name <String> -PartnerNamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DestinationAzureSubscriptionId <String>] [-DestinationPartnerTopicName <String>]
 [-DestinationResourceGroup <String>] [-EventChannelSource <String>]
 [-ExpirationTimeIfNotActivatedUtc <DateTime>] [-FilterAdvancedFilter <IAdvancedFilter[]>]
 [-FilterEnableAdvancedFilteringOnArray] [-PartnerTopicFriendlyDescription <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Asynchronously creates a new event channel with the specified parameters.

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

### -DestinationAzureSubscriptionId
Azure subscription ID of the customer creating the event channel.
The partner topicassociated with the event channel will be created under this Azure subscription.

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

### -DestinationPartnerTopicName
Name of the partner topic associated with the event channel.

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

### -DestinationResourceGroup
Azure Resource Group of the customer creating the event channel.
The partner topicassociated with the event channel will be created under this resource group.

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

### -EventChannelSource
The identifier of the resource that's the source of the events.This represents a unique resource in the partner's resource model.

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

### -ExpirationTimeIfNotActivatedUtc
Expiration time of the event channel.
If this timer expires while the corresponding partner topic is never activated,the event channel and corresponding partner topic are deleted.

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

### -FilterAdvancedFilter
An array of advanced filters that are used for filtering event channels.
To construct, see NOTES section for FILTERADVANCEDFILTER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.Api20211015Preview.IAdvancedFilter[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterEnableAdvancedFilteringOnArray
Allows advanced filters to be evaluated against an array of values instead of expecting a singular value.
The default value is either false or null.

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

### -Name
Name of the event channel.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: EventChannelName

Required: True
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

### -PartnerTopicFriendlyDescription
Friendly description about the topic.
This can be set by the publisher/partner to show custom description for the customer partner topic.This will be helpful to remove any ambiguity of the origin of creation of the partner topic for the customer.

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

### -ResourceGroupName
The name of the resource group within the user's subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.Api20211015Preview.IEventChannel

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


FILTERADVANCEDFILTER <IAdvancedFilter[]>: An array of advanced filters that are used for filtering event channels.
  - `OperatorType <AdvancedFilterOperatorType>`: The operator type used for filtering, e.g., NumberIn, StringContains, BoolEquals and others.
  - `[Key <String>]`: The field/property in the event based on which you want to filter.

## RELATED LINKS

