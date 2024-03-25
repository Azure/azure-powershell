---
external help file: Az.HdInsightOnAks-help.xml
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/New-AzHdInsightOnAksClusterPoolAKSUpgradeObject
schema: 2.0.0
---

# New-AzHdInsightOnAksClusterPoolAKSUpgradeObject

## SYNOPSIS
Create an object to hold the cluster pool upgrade parameters.

## SYNTAX

```
New-AzHdInsightOnAksClusterPoolAKSUpgradeObject [-TargetAksVersion <String>] [-UpgradeAllClusterNode <String>]
 [-UpgradeClusterPool <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an object to hold the cluster pool upgrade parameters.

## EXAMPLES

### Example 1: Create an object to hold the cluster pool upgrade parameters.
```powershell
New-AzHdInsightOnAksClusterPoolAKSUpgradeObject -TargetAksVersion "1.27.9" -UpgradeClusterPool $true
```

```output
Property                                                                                                                                    UpgradeType
--------                                                                                                                                    -----------
{…                                                                                                                                          AKSPatchUpgrade
```

Create an object to hold the flink cluster AKSPatchUpgrade parameters.

## PARAMETERS

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

### -TargetAksVersion
Target AKS version.
When it's not set, latest version will be used.
When upgradeClusterPool is true and upgradeAllClusterNodes is false, target version should be greater or equal to current version.
When upgradeClusterPool is false and upgradeAllClusterNodes is true, target version should be equal to AKS version of cluster pool.

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

### -UpgradeAllClusterNode
whether upgrade all clusters' nodes.
If it's true, upgradeClusterPool should be false.

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

### -UpgradeClusterPool
whether upgrade cluster pool or not.
If it's true, upgradeAllClusterNodes should be false.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPoolUpgrade

## NOTES

## RELATED LINKS
