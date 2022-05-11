---
external help file:
Module Name: Az.EventGrid
online version: https://docs.microsoft.com/en-us/powershell/module/az.eventgrid/get-azeventgriddomaineventsubscription
schema: 2.0.0
---

# Get-AzEventGridDomainEventSubscription

## SYNOPSIS
Get properties of an event subscription of a domain.

## SYNTAX

### List (Default)
```
Get-AzEventGridDomainEventSubscription -DomainName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

### Get
```
Get-AzEventGridDomainEventSubscription -DomainName <String> -EventSubscriptionName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEventGridDomainEventSubscription -InputObject <IEventGridIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Get properties of an event subscription of a domain.

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

### -DomainName
Name of the partner topic.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventSubscriptionName
Name of the event subscription to be found.
Event subscription names must be between 3 and 100 characters in length and use alphanumeric letters only.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.Api20211015Preview.IEventSubscription

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

