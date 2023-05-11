---
external help file: Az.EventHub-help.xml
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/remove-azeventhubnamespacev2
schema: 2.0.0
---

# Remove-AzEventHubNamespaceV2

## SYNOPSIS
Deletes an existing namespace.
This operation also removes all associated resources under the namespace.

## SYNTAX

## DESCRIPTION
Deletes an existing namespace.
This operation also removes all associated resources under the namespace.

## EXAMPLES

### Example 1: Delete an EventHub namespace
```powershell
Remove-AzEventHubNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace
```

Deletes an EventHub namespace `myNamespace` under resource group `myResourceGroup`.

### Example 2: Delete an EventHub namespace using InputObject parameter set
```powershell
$namespace = Get-AzEventHubNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace
Remove-AzEventHubNamespaceV2 -InputObject $namespace
```

Deletes an EventHub namespace `myNamespace` under resource group `myResourceGroup` using InputObject parameter set.

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IEventHubIdentity>`: Identity Parameter
  - `[Alias <String>]`: The Disaster Recovery configuration name
  - `[ApplicationGroupName <String>]`: The Application Group name 
  - `[AuthorizationRuleName <String>]`: The authorization rule name.
  - `[ClusterName <String>]`: The name of the Event Hubs Cluster.
  - `[ConsumerGroupName <String>]`: The consumer group name
  - `[EventHubName <String>]`: The Event Hub name
  - `[Id <String>]`: Resource identity path
  - `[NamespaceName <String>]`: The Namespace name
  - `[PrivateEndpointConnectionName <String>]`: The PrivateEndpointConnection name
  - `[ResourceAssociationName <String>]`: The ResourceAssociation Name
  - `[ResourceGroupName <String>]`: Name of the resource group within the azure subscription.
  - `[SchemaGroupName <String>]`: The Schema Group name 
  - `[SubscriptionId <String>]`: Subscription credentials that uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS
