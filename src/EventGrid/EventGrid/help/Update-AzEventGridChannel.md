---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/update-azeventgridchannel
schema: 2.0.0
---

# Update-AzEventGridChannel

## SYNOPSIS
Synchronously updates a channel with the specified parameters.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzEventGridChannel -Name <String> -PartnerNamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-EventTypeInfoInlineEventType <Hashtable>] [-EventTypeInfoKind <String>]
 [-ExpirationTimeIfNotActivatedUtc <DateTime>] [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzEventGridChannel -Name <String> -PartnerNamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzEventGridChannel -Name <String> -PartnerNamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityPartnerNamespaceExpanded
```
Update-AzEventGridChannel -Name <String> -PartnerNamespaceInputObject <IEventGridIdentity>
 [-EventTypeInfoInlineEventType <Hashtable>] [-EventTypeInfoKind <String>]
 [-ExpirationTimeIfNotActivatedUtc <DateTime>] [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzEventGridChannel -InputObject <IEventGridIdentity> [-EventTypeInfoInlineEventType <Hashtable>]
 [-EventTypeInfoKind <String>] [-ExpirationTimeIfNotActivatedUtc <DateTime>] [-DefaultProfile <PSObject>]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Synchronously updates a channel with the specified parameters.

## EXAMPLES

### Example 1: Synchronously updates a channel with the specified parameters.
```powershell
$dateObj = Get-Date -Year 2023 -Month 11 -Day 10 -Hour 11 -Minute 06 -Second 07
Update-AzEventGridChannel -Name azps-channel -PartnerNamespaceName azps-partnernamespace -ResourceGroupName azps_test_group_eventgrid -ExpirationTimeIfNotActivatedUtc $dateObj.ToUniversalTime()
```

```output
Name         ResourceGroupName
----         -----------------
azps-channel azps_test_group_eventgrid
```

Synchronously updates a channel with the specified parameters.

## PARAMETERS

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

### -EventTypeInfoInlineEventType
A collection of inline event types for the resource.
The inline event type keys are of type string which represents the name of the event.An example of a valid inline event name is "Contoso.OrderCreated".The inline event type values are of type InlineEventProperties and will contain additional information for every inline event type.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityPartnerNamespaceExpanded, UpdateViaIdentityExpanded
Aliases: InlineEvent

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventTypeInfoKind
The kind of event type used.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityPartnerNamespaceExpanded, UpdateViaIdentityExpanded
Aliases: EventTypeKind

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpirationTimeIfNotActivatedUtc
Expiration time of the channel.
If this timer expires while the corresponding partner topic or partner destination is never activated,the channel and corresponding partner topic or partner destination are deleted.

```yaml
Type: System.DateTime
Parameter Sets: UpdateExpanded, UpdateViaIdentityPartnerNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the channel.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityPartnerNamespaceExpanded
Aliases: ChannelName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerNamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: UpdateViaIdentityPartnerNamespaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PartnerNamespaceName
Name of the partner namespace.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
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
The name of the resource group within the partners subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases: ResourceGroup

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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IChannel

## NOTES

## RELATED LINKS
