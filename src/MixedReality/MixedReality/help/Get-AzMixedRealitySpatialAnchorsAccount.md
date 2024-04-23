---
external help file: Az.MixedReality-help.xml
Module Name: Az.MixedReality
online version: https://learn.microsoft.com/powershell/module/az.mixedreality/get-azmixedrealityspatialanchorsaccount
schema: 2.0.0
---

# Get-AzMixedRealitySpatialAnchorsAccount

## SYNOPSIS
Retrieve a Spatial Anchors Account.

## SYNTAX

### List (Default)
```
Get-AzMixedRealitySpatialAnchorsAccount [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzMixedRealitySpatialAnchorsAccount -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzMixedRealitySpatialAnchorsAccount -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMixedRealitySpatialAnchorsAccount -InputObject <IMixedRealityIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Retrieve a Spatial Anchors Account.

## EXAMPLES

### Example 1: List Spatial Anchors Accounts by Subscription.
```powershell
Get-AzMixedRealitySpatialAnchorsAccount
```

```output
Location Name                   ResourceGroupName
-------- ----                   -----------------
eastus   azpstestanchorsaccount azps_test_group
```

List Spatial Anchors Accounts by Subscription.

### Example 2: List Spatial Anchors Accounts by Resource Group.
```powershell
Get-AzMixedRealitySpatialAnchorsAccount -ResourceGroupName azps_test_group
```

```output
Location Name                   ResourceGroupName
-------- ----                   -----------------
eastus   azpstestanchorsaccount azps_test_group
```

List Spatial Anchors Accounts by Resource Group.

### Example 3: Retrieve a Spatial Anchors Account.
```powershell
Get-AzMixedRealitySpatialAnchorsAccount -Name azpstestanchorsaccount -ResourceGroupName azps_test_group
```

```output
Location Name                   ResourceGroupName
-------- ----                   -----------------
eastus   azpstestanchorsaccount azps_test_group
```

Retrieve a Spatial Anchors Account.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.IMixedRealityIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of an Mixed Reality Account.

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
Name of an Azure resource group.

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
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

```yaml
Type: System.String[]
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.IMixedRealityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.ISpatialAnchorsAccount

## NOTES

## RELATED LINKS
