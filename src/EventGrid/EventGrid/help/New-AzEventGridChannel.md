---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/new-azeventgridchannel
schema: 2.0.0
---

# New-AzEventGridChannel

## SYNOPSIS
Synchronously creates or updates a new channel with the specified parameters.

## SYNTAX

### CreateExpanded (Default)
```
New-AzEventGridChannel -Name <String> -PartnerNamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ChannelType <String>] [-EventTypeInfoInlineEventType <Hashtable>]
 [-EventTypeInfoKind <String>] [-ExpirationTimeIfNotActivatedUtc <DateTime>] [-MessageForActivation <String>]
 [-PartnerDestinationInfoAzureSubscriptionId <String>] [-PartnerDestinationInfoEndpointServiceContext <String>]
 [-PartnerDestinationInfoName <String>] [-PartnerDestinationInfoResourceGroupName <String>]
 [-PartnerDestinationInfoResourceMoveChangeHistory <IResourceMoveChangeHistory[]>]
 [-PartnerTopicInfoAzureSubscriptionId <String>] [-PartnerTopicInfoName <String>]
 [-PartnerTopicInfoResourceGroupName <String>] [-PartnerTopicInfoSource <String>] [-ProvisioningState <String>]
 [-ReadinessState <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzEventGridChannel -Name <String> -PartnerNamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzEventGridChannel -Name <String> -PartnerNamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityPartnerNamespaceExpanded
```
New-AzEventGridChannel -Name <String> -PartnerNamespaceInputObject <IEventGridIdentity> [-ChannelType <String>]
 [-EventTypeInfoInlineEventType <Hashtable>] [-EventTypeInfoKind <String>]
 [-ExpirationTimeIfNotActivatedUtc <DateTime>] [-MessageForActivation <String>]
 [-PartnerDestinationInfoAzureSubscriptionId <String>] [-PartnerDestinationInfoEndpointServiceContext <String>]
 [-PartnerDestinationInfoName <String>] [-PartnerDestinationInfoResourceGroupName <String>]
 [-PartnerDestinationInfoResourceMoveChangeHistory <IResourceMoveChangeHistory[]>]
 [-PartnerTopicInfoAzureSubscriptionId <String>] [-PartnerTopicInfoName <String>]
 [-PartnerTopicInfoResourceGroupName <String>] [-PartnerTopicInfoSource <String>] [-ProvisioningState <String>]
 [-ReadinessState <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzEventGridChannel -InputObject <IEventGridIdentity> [-ChannelType <String>]
 [-EventTypeInfoInlineEventType <Hashtable>] [-EventTypeInfoKind <String>]
 [-ExpirationTimeIfNotActivatedUtc <DateTime>] [-MessageForActivation <String>]
 [-PartnerDestinationInfoAzureSubscriptionId <String>] [-PartnerDestinationInfoEndpointServiceContext <String>]
 [-PartnerDestinationInfoName <String>] [-PartnerDestinationInfoResourceGroupName <String>]
 [-PartnerDestinationInfoResourceMoveChangeHistory <IResourceMoveChangeHistory[]>]
 [-PartnerTopicInfoAzureSubscriptionId <String>] [-PartnerTopicInfoName <String>]
 [-PartnerTopicInfoResourceGroupName <String>] [-PartnerTopicInfoSource <String>] [-ProvisioningState <String>]
 [-ReadinessState <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Synchronously creates or updates a new channel with the specified parameters.

## EXAMPLES

### Example 1: Synchronously Create a new channel with the specified parameters.
```powershell
$dateObj = Get-Date -Year 2023 -Month 11 -Day 10 -Hour 11 -Minute 06 -Second 07
New-AzEventGridChannel -Name azps-channel -PartnerNamespaceName azps-partnernamespace -ResourceGroupName azps_test_group_eventgrid -ChannelType PartnerTopic -PartnerTopicInfoAzureSubscriptionId "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX" -PartnerTopicInfoResourceGroupName "azps_test_group_eventgrid2" -PartnerTopicInfoName "default" -PartnerTopicInfoSource "ContosoCorp.Accounts.User1" -ExpirationTimeIfNotActivatedUtc $dateObj.ToUniversalTime()
```

```output
Name         ResourceGroupName
----         -----------------
azps-channel azps_test_group_eventgrid
```

Synchronously Create a new channel with the specified parameters.

## PARAMETERS

### -ChannelType
The type of the event channel which represents the direction flow of events.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
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

### -EventTypeInfoInlineEventType
A collection of inline event types for the resource.
The inline event type keys are of type string which represents the name of the event.An example of a valid inline event name is "Contoso.OrderCreated".The inline event type values are of type InlineEventProperties and will contain additional information for every inline event type.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
Aliases: EventTypeKind

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
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MessageForActivation
Context or helpful message that can be used during the approval process by the subscriber.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityPartnerNamespaceExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerDestinationInfoResourceMoveChangeHistory
Change history of the resource move.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IResourceMoveChangeHistory[]
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerNamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: CreateViaIdentityPartnerNamespaceExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
Aliases: PartnerTopicName

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
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
Aliases: PartnerTopicSource

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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityPartnerNamespaceExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
