---
external help file:
Module Name: Az.ResourceConnector
online version: https://learn.microsoft.com/powershell/module/az.resourceconnector/get-azresourceconnectorbridgeupgradegraph
schema: 2.0.0
---

# Get-AzResourceConnectorBridgeUpgradeGraph

## SYNOPSIS
Gets the upgrade graph of an Appliance with a specified resource group and name and specific release train.

## SYNTAX

### Get (Default)
```
Get-AzResourceConnectorBridgeUpgradeGraph -Name <String> -ResourceGroupName <String> -UpgradeGraph <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzResourceConnectorBridgeUpgradeGraph -InputObject <IResourceConnectorIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the upgrade graph of an Appliance with a specified resource group and name and specific release train.

## EXAMPLES

### Example 1: Gets the upgrade graph of an Appliance with a specified resource group and name and specific release train.
```powershell
Get-AzResourceConnectorBridgeUpgradeGraph -ResourceGroupName azps_test_group -Name azps-resource-bridge -UpgradeGraph Stable
```

```output
Name   ResourceGroupName
----   -----------------
stable azps_test_group
```

Gets the upgrade graph of an Appliance with a specified resource group and name and specific release train.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResourceConnector.Models.IResourceConnectorIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Appliances name.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradeGraph
Upgrade graph version, ex - stable

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResourceConnector.Models.IResourceConnectorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResourceConnector.Models.Api20221027.IUpgradeGraph

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IResourceConnectorIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceName <String>]`: Appliances name.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[UpgradeGraph <String>]`: Upgrade graph version, ex - stable

## RELATED LINKS

