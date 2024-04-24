---
external help file: Az.MixedReality-help.xml
Module Name: Az.MixedReality
online version: https://learn.microsoft.com/powershell/module/az.mixedreality/get-azmixedrealityspatialanchorsaccountkey
schema: 2.0.0
---

# Get-AzMixedRealitySpatialAnchorsAccountKey

## SYNOPSIS
List Both of the 2 Keys of a Spatial Anchors Account

## SYNTAX

```
Get-AzMixedRealitySpatialAnchorsAccountKey -AccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
List Both of the 2 Keys of a Spatial Anchors Account

## EXAMPLES

### Example 1: List Both of the 2 Keys of a Spatial Anchors Account.
```powershell
Get-AzMixedRealitySpatialAnchorsAccountKey -AccountName azpstestanchorsaccount -ResourceGroupName azps_test_group
```

```output
PrimaryKey             SecondaryKey
----------             ------------
OAocrh+K******8VRRO/I= froxBip******KVs6tqyPA=
```

List Both of the 2 Keys of a Spatial Anchors Account.

## PARAMETERS

### -AccountName
Name of an Mixed Reality Account.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -ResourceGroupName
Name of an Azure resource group.

```yaml
Type: System.String
Parameter Sets: (All)
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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IAccountKeys

## NOTES

## RELATED LINKS
