---
external help file: Az.HdInsightOnAks-help.xml
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/New-AzHdInsightOnAksClusterServiceConfigObject
schema: 2.0.0
---

# New-AzHdInsightOnAksClusterServiceConfigObject

## SYNOPSIS
Create a component config.

## SYNTAX

```
New-AzHdInsightOnAksClusterServiceConfigObject -ComponentName <String> -File <IClusterConfigFile[]>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create a component config.

## EXAMPLES

### Example 1: Create a component config.
```powershell
$coreSiteConfigFile=New-AzHdInsightOnAksClusterConfigFileObject -FileName "core-site.xml" -Value @{"fs.defaultFS"="abfs://testcontainer@$teststorage.dfs.core.windows.net"}
$yarnComponentConfig= New-AzHdInsightOnAksClusterServiceConfigObject -ComponentName "yarn-config" -File $coreSiteConfigFile
```

This cmdlet create the component config of "yarn-config" based the existing config file $coreSiteConfigFile.

## PARAMETERS

### -ComponentName
Name of the component the config files should apply to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -File
List of Config Files.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterConfigFile[]
Parameter Sets: (All)
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterConfigFile[]

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterServiceConfig

## NOTES

## RELATED LINKS
