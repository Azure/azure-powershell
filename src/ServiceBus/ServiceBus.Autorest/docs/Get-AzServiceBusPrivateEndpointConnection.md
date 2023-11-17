---
external help file:
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/get-azservicebusprivateendpointconnection
schema: 2.0.0
---

# Get-AzServiceBusPrivateEndpointConnection

## SYNOPSIS
Gets a description for the specified Private Endpoint Connection.

## SYNTAX

### List (Default)
```
Get-AzServiceBusPrivateEndpointConnection -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzServiceBusPrivateEndpointConnection -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzServiceBusPrivateEndpointConnection -InputObject <IServiceBusIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a description for the specified Private Endpoint Connection.

## EXAMPLES

### Example 1: Get a ServiceBus Namespace Private Endpoint Connection
```powershell
Get-AzServiceBusPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
```

```output
ConnectionState              : Approved
Description                  :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/privateEndpointC
                               onnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
ProvisioningState            : Succeeded
ResourceGroupName            : myResourceGroup
```

Gets details of private endpoint connection `00000000000` created under ServiceBus namespace `myNamespace`.

### Example 2: List all private endpoint connections on a ServiceBus namespace
```powershell
Get-AzServiceBusPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

Lists all private endpoint connections of ServiceBus namespace `myNamespace`.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The PrivateEndpointConnection name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PrivateEndpointConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The namespace name

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

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.IPrivateEndpointConnection

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IServiceBusIdentity>`: Identity Parameter
  - `[Alias <String>]`: The Disaster Recovery configuration name
  - `[AuthorizationRuleName <String>]`: The authorization rule name.
  - `[ConfigName <MigrationConfigurationName?>]`: The configuration name. Should always be "$default".
  - `[Id <String>]`: Resource identity path
  - `[NamespaceName <String>]`: The namespace name
  - `[PrivateEndpointConnectionName <String>]`: The PrivateEndpointConnection name
  - `[QueueName <String>]`: The queue name.
  - `[ResourceGroupName <String>]`: Name of the Resource group within the Azure subscription.
  - `[RuleName <String>]`: The rule name.
  - `[SubscriptionId <String>]`: Subscription credentials that uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[SubscriptionName <String>]`: The subscription name.
  - `[TopicName <String>]`: The topic name.

## RELATED LINKS

