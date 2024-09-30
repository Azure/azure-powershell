---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/Az.HdInsightOnAks/new-azhdinsightonaksclusterpoolakspatchversionupgradeobject
schema: 2.0.0
---

# New-AzHdInsightOnAksClusterPoolAksPatchVersionUpgradeObject

## SYNOPSIS
Create an in-memory object for ClusterPoolAksPatchVersionUpgradeProperties.

## SYNTAX

```
New-AzHdInsightOnAksClusterPoolAksPatchVersionUpgradeObject [-TargetAksVersion <String>]
 [-UpgradeAllClusterNode <Boolean>] [-UpgradeClusterPool <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ClusterPoolAksPatchVersionUpgradeProperties.

## EXAMPLES

### Example 1: Create an object to hold the cluster pool upgrade parameters.
```powershell
New-AzHdInsightOnAksClusterPoolAksPatchVersionUpgradeObject -TargetAksVersion "1.27.9" -UpgradeClusterPool $true
```

```output
Property                                                                                                                                    UpgradeType
--------                                                                                                                                    -----------
{…                                                                                                                                          AKSPatchUpgrade
```

Create an object to hold the flink cluster AKSPatchUpgrade parameters.

## PARAMETERS

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
Type: System.Boolean
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
Type: System.Boolean
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ClusterPoolAksPatchVersionUpgradeProperties

## NOTES

## RELATED LINKS

