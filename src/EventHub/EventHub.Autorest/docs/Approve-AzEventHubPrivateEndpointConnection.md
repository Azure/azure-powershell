---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/approve-azeventhubprivateendpointconnection
schema: 2.0.0
---

# Approve-AzEventHubPrivateEndpointConnection

## SYNOPSIS
Approves an EventHub PrivateEndpointConnection

## SYNTAX

### SetExpanded (Default)
```
Approve-AzEventHubPrivateEndpointConnection -NamespaceName <String> -ResourceGroupName <String>
 [-Name <String>] [-SubscriptionId <String>] [-Description <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [<CommonParameters>]
```

### SetViaIdentityExpanded
```
Approve-AzEventHubPrivateEndpointConnection -InputObject <IEventHubIdentity> [-Description <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [<CommonParameters>]
```

## DESCRIPTION
Approves an EventHub PrivateEndpointConnection

## EXAMPLES

### Example 1: Approve an Event Hub Namespace Private Endpoint Connection
```powershell
Approve-AzEventHubPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
```

```output
ConnectionState              : Approved
Description                  :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/privateEndpointConnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Network/privateEndpoints/privateEndpointName
ProvisioningState            : Succeeded
ResourceGroupName            : myResourceGroup
```

Approves private endpoint connection `00000000000` on EventHub namespace `myNamespace`.

### Example 2: Approve an Event Hub Namespace Private Endpoint Connection using InputObject
```powershell
$privateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
Approve-AzEventHubPrivateEndpointConnection -InputObject $privateEndpoint
```

```output
ConnectionState              : Approved
Description                  :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/privateEndpointConnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Network/privateEndpoints/privateEndpointName
ProvisioningState            : Succeeded
ResourceGroupName            : myResourceGroup
```

Approves private endpoint connection `00000000000` on EventHub namespace `myNamespace` using InputObject parameter set.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
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
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The name of EventHub namespace

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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IPrivateEndpointConnection

## NOTES

## RELATED LINKS

