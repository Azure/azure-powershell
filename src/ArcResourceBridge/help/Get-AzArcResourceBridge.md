---
external help file:
Module Name: Az.ArcResourceBridge
online version: https://learn.microsoft.com/powershell/module/az.arcresourcebridge/get-azarcresourcebridge
schema: 2.0.0
---

# Get-AzArcResourceBridge

## SYNOPSIS
Gets the details of an Appliance with a specified resource group and name.

## SYNTAX

### List (Default)
```
Get-AzArcResourceBridge [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzArcResourceBridge -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzArcResourceBridge -InputObject <IArcResourceBridgeIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzArcResourceBridge -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the details of an Appliance with a specified resource group and name.

## EXAMPLES

### Example 1: List the details of Appliance with a specified subId.
```powershell
Get-AzArcResourceBridge
```

```output
Name                 Location ProvisioningState ResourceGroupName
----                 -------- ----------------- -----------------
azps-resource-bridge eastus   Succeeded         azps_test_group
```

List the details of Appliance with a specified subId.

### Example 2: List the details of Appliance with a specified resource group.
```powershell
Get-AzArcResourceBridge -ResourceGroupName azps_test_group
```

```output
Name                 Location ProvisioningState ResourceGroupName
----                 -------- ----------------- -----------------
azps-resource-bridge eastus   Succeeded         azps_test_group
```

List the details of Appliance with a specified resource group.

### Example 3: Get the details of an Appliance with a specified resource group and name.
```powershell
Get-AzArcResourceBridge -ResourceGroupName azps_test_group -Name azps-resource-bridge
```

```output
Name                 Location ProvisioningState ResourceGroupName
----                 -------- ----------------- -----------------
azps-resource-bridge eastus   Succeeded         azps_test_group
```

Get the details of an Appliance with a specified resource group and name.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Models.IArcResourceBridgeIdentity
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
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Models.IArcResourceBridgeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Models.Api20221027.IAppliance

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IArcResourceBridgeIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceName <String>]`: Appliances name.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[UpgradeGraph <String>]`: Upgrade graph version, ex - stable

## RELATED LINKS

