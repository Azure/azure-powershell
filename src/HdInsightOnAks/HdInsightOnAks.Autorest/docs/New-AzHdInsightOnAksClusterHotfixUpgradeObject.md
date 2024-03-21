---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/new-azhdinsightonaksclusterhotfixupgradeobject
schema: 2.0.0
---

# New-AzHdInsightOnAksClusterHotfixUpgradeObject

## SYNOPSIS


## SYNTAX

```
New-AzHdInsightOnAksClusterHotfixUpgradeObject -ComponentName <String> -TargetBuildNumber <String>
 -TargetClusterVersion <String> -TargetOssVersion <String> [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: Create an object to hold the upgrade parameters.
```powershell
$hotfixObj = New-AzHdInsightOnAksHotfixUpgradeObject -ComponentName Webssh -TargetBuildNumber 7 -TargetClusterVersion "1.1.1" -TargetOssVersion "0.4.2"
```

```output
Property                                    UpgradeType
--------                                    -----------
{…                                          HotfixUpgrade
```

Create an object to hold the flink cluster HotfixUpgrade parameters.

## PARAMETERS

### -ComponentName


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

### -TargetBuildNumber


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

### -TargetClusterVersion


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

### -TargetOssVersion


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

