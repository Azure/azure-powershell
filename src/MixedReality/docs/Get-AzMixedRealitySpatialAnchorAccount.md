---
external help file:
Module Name: Az.MixedReality
online version: https://docs.microsoft.com/powershell/module/az.mixedreality/get-azmixedrealityspatialanchoraccount
schema: 2.0.0
---

# Get-AzMixedRealitySpatialAnchorAccount

## SYNOPSIS
List Spatial Anchors Accounts by Subscription

## SYNTAX

### List (Default)
```
Get-AzMixedRealitySpatialAnchorAccount [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzMixedRealitySpatialAnchorAccount -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List Spatial Anchors Accounts by Subscription

## EXAMPLES

### Example 1: List Spatial Anchors Accounts by Subscription.
```powershell
Get-AzMixedRealitySpatialAnchorAccount
```

```output
Location Name                   ResourceGroupName
-------- ----                   -----------------
eastus   azpstestanchorsaccount azps_test_group
```

List Spatial Anchors Accounts by Subscription.

### Example 2: List Spatial Anchors Accounts by Resource Group.
```powershell
Get-AzMixedRealitySpatialAnchorAccount -ResourceGroupName azps_test_group
```

```output
Location Name                   ResourceGroupName
-------- ----                   -----------------
eastus   azpstestanchorsaccount azps_test_group
```

List Spatial Anchors Accounts by Resource Group.

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

### -ResourceGroupName
Name of an Azure resource group.

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.ISpatialAnchorsAccount

## NOTES

ALIASES

## RELATED LINKS

