---
external help file:
Module Name: Az.EventGrid
online version: https://docs.microsoft.com/en-us/powershell/module/az.eventgrid/update-azeventgridpartnerregistration
schema: 2.0.0
---

# Update-AzEventGridPartnerRegistration

## SYNOPSIS
Updates a partner registration with the specified parameters.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzEventGridPartnerRegistration -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AuthorizedAzureSubscriptionId <String[]>] [-LogoUri <String>] [-PartnerTopicTypeDescription <String>]
 [-PartnerTopicTypeDisplayName <String>] [-PartnerTopicTypeName <String>] [-SetupUri <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzEventGridPartnerRegistration -InputObject <IEventGridIdentity>
 [-AuthorizedAzureSubscriptionId <String[]>] [-LogoUri <String>] [-PartnerTopicTypeDescription <String>]
 [-PartnerTopicTypeDisplayName <String>] [-PartnerTopicTypeName <String>] [-SetupUri <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates a partner registration with the specified parameters.

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

### -AuthorizedAzureSubscriptionId
List of IDs of Azure AD applications that are authorized to create a partner namespaceassociated with this partner registration.
This is an optional property.
Creatingpartner namespaces is always permitted under the same Azure subscription as the one usedfor creating the partner registration.

```yaml
Type: System.String[]
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

### -LogoUri
URI of the partner logo.

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
Name of the partner registration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: PartnerRegistrationName

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

### -PartnerTopicTypeDescription
Description of the partner topic type.

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

### -PartnerTopicTypeDisplayName
Display name of the partner topic type.

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

### -PartnerTopicTypeName
Name of the partner topic type.

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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SetupUri
URI of the partner website that can be used by Azure customers to setup Event Gridintegration on an event source.

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
Tags of the partner registration resource.

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

### System.Boolean

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

