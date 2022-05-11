---
external help file:
Module Name: Az.EventGrid
online version: https://docs.microsoft.com/en-us/powershell/module/az.eventgrid/update-azeventgridpartnertopic
schema: 2.0.0
---

# Update-AzEventGridPartnerTopic

## SYNOPSIS
Asynchronously updates a partner topic with the specified parameters.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzEventGridPartnerTopic -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IdentityPrincipalId <String>] [-IdentityTenantId <String>] [-IdentityType <IdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzEventGridPartnerTopic -InputObject <IEventGridIdentity> [-IdentityPrincipalId <String>]
 [-IdentityTenantId <String>] [-IdentityType <IdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Asynchronously updates a partner topic with the specified parameters.

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

### -IdentityPrincipalId
The principal ID of resource identity.

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

### -IdentityTenantId
The tenant ID of resource.

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

### -IdentityType
The type of managed identity used.
The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user-assigned identities.
The type 'None' will remove any identity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Support.IdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The list of user identities associated with the resource.
The user identity dictionary key references will be ARM resource ids in the form:'/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.This property is currently not used and reserved for future usage.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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

### -Name
Name of the partner topic.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: PartnerTopicName

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
The name of the resource group within the user's subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tags of the Partner Topic resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.Api20211015Preview.IPartnerTopic

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IEventGridIdentity>: Identity Parameter
  - `[ChannelName <String>]`: Name of the channel.
  - `[DomainName <String>]`: Name of the domain.
  - `[DomainTopicName <String>]`: Name of the topic.
  - `[EventChannelName <String>]`: Name of the event channel.
  - `[EventSubscriptionName <String>]`: Name of the event subscription.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: Name of the location.
  - `[ParentName <String>]`: The name of the parent resource (namely, either, the topic name, domain name, or partner namespace name).
  - `[ParentType <ParentType?>]`: The type of the parent resource. This can be either \'topics\', \'domains\', or \'partnerNamespaces\'.
  - `[PartnerDestinationName <String>]`: Name of the partner destination.
  - `[PartnerNamespaceName <String>]`: Name of the partner namespace.
  - `[PartnerRegistrationName <String>]`: Name of the partner registration.
  - `[PartnerTopicName <String>]`: Name of the partner topic.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection connection.
  - `[PrivateLinkResourceName <String>]`: The name of private link resource.
  - `[ProviderNamespace <String>]`: Namespace of the provider of the topic.
  - `[ResourceGroupName <String>]`: The name of the resource group within the partners subscription.
  - `[ResourceName <String>]`: Name of the resource.
  - `[ResourceTypeName <String>]`: Name of the resource type.
  - `[Scope <String>]`: The scope of the event subscription. The scope can be a subscription, or a resource group, or a top level resource belonging to a resource provider namespace, or an EventGrid topic. For example, use '/subscriptions/{subscriptionId}/' for a subscription, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for a resource group, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}' for a resource, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{topicName}' for an EventGrid topic.
  - `[SubscriptionId <String>]`: Subscription credentials that uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[SystemTopicName <String>]`: Name of the system topic.
  - `[TopicName <String>]`: Name of the domain topic.
  - `[TopicTypeName <String>]`: Name of the topic type.
  - `[VerifiedPartnerName <String>]`: Name of the verified partner.

## RELATED LINKS

