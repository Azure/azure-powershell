---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/new-azhdinsightonaksclusterpoolaksupgradeobject
schema: 2.0.0
---

# New-AzHdInsightOnAksClusterPoolAKSUpgradeObject

## SYNOPSIS


## SYNTAX

```
New-AzHdInsightOnAksClusterPoolAKSUpgradeObject [-TargetAksVersion <String>] [-UpgradeAllClusterNode <String>]
 [-UpgradeClusterPool <String>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: Create an object to hold the cluster pool upgrade parameters.
```powershell
New-AzHdInsightOnAksClusterPoolAKSUpgradeObject -TargetAksVersion "1.27.9" -UpgradeClusterPool $true-UpgradeClusterPool $false
```

```output
Property                                                                                                                                    UpgradeType
--------                                                                                                                                    -----------
{…                                                                                                                                          AKSPatchUpgrade
```

Create an object to hold the flink cluster AKSPatchUpgrade parameters.

## PARAMETERS

### -TargetAksVersion


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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterUpgrade

## NOTES

## RELATED LINKS

