---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/Az.HdInsightOnAks/new-azhdinsightonaksclusterhotfixupgradeobject
schema: 2.0.0
---

# New-AzHdInsightOnAksClusterHotfixUpgradeObject

## SYNOPSIS
Create an in-memory object for ClusterHotfixUpgradeProperties.

## SYNTAX

```
New-AzHdInsightOnAksClusterHotfixUpgradeObject [-ComponentName <String>] [-TargetBuildNumber <String>]
 [-TargetClusterVersion <String>] [-TargetOssVersion <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ClusterHotfixUpgradeProperties.

## EXAMPLES

### Example 1: Create an object to hold the upgrade parameters.
```powershell
$hotfixObj = New-AzHdInsightOnAksClusterHotfixUpgradeObject -ComponentName Webssh -TargetBuildNumber 7 -TargetClusterVersion "1.1.1" -TargetOssVersion "0.4.2"
```

```output
Property                                    UpgradeType
--------                                    -----------
{…                                          HotfixUpgrade
```

Create an object to hold the flink cluster HotfixUpgrade parameters.

## PARAMETERS

### -ComponentName
Name of component to be upgraded.

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

### -TargetBuildNumber
Target build number of component to be upgraded.

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

### -TargetClusterVersion
Target cluster version of component to be upgraded.

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

### -TargetOssVersion
Target OSS version of component to be upgraded.

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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterUpgrade

## NOTES

## RELATED LINKS

