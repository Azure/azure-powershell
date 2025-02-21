---
external help file:
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/deny-azservicebusprivateendpointconnection
schema: 2.0.0
---

# Deny-AzServiceBusPrivateEndpointConnection

## SYNOPSIS
Denies a ServiceBus PrivateEndpointConnection

## SYNTAX

### SetExpanded (Default)
```
Deny-AzServiceBusPrivateEndpointConnection -NamespaceName <String> -ResourceGroupName <String>
 [-Name <String>] [-SubscriptionId <String>] [-Description <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [<CommonParameters>]
```

### SetViaIdentityExpanded
```
Deny-AzServiceBusPrivateEndpointConnection -InputObject <IServiceBusIdentity> [-Description <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [<CommonParameters>]
```

## DESCRIPTION
Denies a ServiceBus PrivateEndpointConnection

## EXAMPLES

### Example 1: Rejects a ServiceBus Namespace Private Endpoint Connection
```powershell
Deny-AzServiceBusPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
```

```output
ConnectionState              : Rejected
Description                  :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/privateEndpointConnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/subscriptionId/resourceGroups/{resourceGroup}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
ProvisioningState            : Succeeded
ResourceGroupName            : myResourceGroup
```

Rejects private endpoint connection `00000000000` on ServiceBus namespace `myNamespace`.

### Example 2: Rejects a ServiceBus Namespace Private Endpoint Connection using InputObject
```powershell
$privateEndpoint = Get-AzServiceBusPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
Deny-AzServiceBusPrivateEndpointConnection -InputObject $privateEndpoint
```

```output
ConnectionState              : Rejected
Description                  :
Id                           : /subscriptions/subscriptionId/resourceGroups/{resourceGroup}/providers/Microsoft.ServiceBus/namespaces/{namespace}/privateEndpointC
                               onnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/subscriptionId/resourceGroups/{resourceGroup}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
ProvisioningState            : Succeeded
ResourceGroupName            : myResourceGroup
```

Rejects private endpoint connection `00000000000` on ServiceBus namespace `myNamespace` using InputObject parameter set.

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

### -Description
PrivateEndpoint information.

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

### -InputObject
Identity parameter.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity
Parameter Sets: SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Private Endpoint Connection

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases: PrivateEndpointConnectionName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The name of ServiceBus namespace

```yaml
Type: System.String
Parameter Sets: SetExpanded
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: SetExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IPrivateEndpointConnection

## NOTES

## RELATED LINKS

