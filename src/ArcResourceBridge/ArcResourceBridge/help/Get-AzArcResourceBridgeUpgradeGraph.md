---
external help file: Az.ArcResourceBridge-help.xml
Module Name: Az.ArcResourceBridge
online version: https://learn.microsoft.com/powershell/module/az.arcresourcebridge/get-azarcresourcebridgeupgradegraph
schema: 2.0.0
---

# Get-AzArcResourceBridgeUpgradeGraph

## SYNOPSIS
Gets the upgrade graph of an Appliance with a specified resource group and name and specific release train.

## SYNTAX

### Get (Default)
```
Get-AzArcResourceBridgeUpgradeGraph -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -UpgradeGraph <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzArcResourceBridgeUpgradeGraph -InputObject <IArcResourceBridgeIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets the upgrade graph of an Appliance with a specified resource group and name and specific release train.

## EXAMPLES

### Example 1: Gets the upgrade graph of an Appliance with a specified resource group and name and specific release train.
```powershell
Get-AzArcResourceBridgeUpgradeGraph -ResourceGroupName azps_test_group -Name azps-resource-bridge -UpgradeGraph Stable
```

```output
Name   ResourceGroupName
----   -----------------
stable azps_test_group
```

Gets the upgrade graph of an Appliance with a specified resource group and name and specific release train.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Models.IArcResourceBridgeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Models.Api20221027.IUpgradeGraph

## NOTES

## RELATED LINKS
