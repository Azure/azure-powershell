---
external help file: Az.HdInsightOnAks-help.xml
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/Az.HdInsightOnAks/new-azhdinsightonaksclusterserviceconfigobject
schema: 2.0.0
---

# New-AzHdInsightOnAksClusterServiceConfigObject

## SYNOPSIS
Create an in-memory object for ClusterServiceConfig.

## SYNTAX

```
New-AzHdInsightOnAksClusterServiceConfigObject -ComponentName <String> -File <IClusterConfigFile[]>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ClusterServiceConfig.

## EXAMPLES

### Example 1: Create a component config.
```powershell
$coreSiteConfigFile=New-AzHdInsightOnAksClusterConfigFileObject -FileName "core-site.xml" -Value @{"fs.defaultFS"="abfs://testcontainer@$teststorage.dfs.core.windows.net"}
New-AzHdInsightOnAksClusterServiceConfigObject -ComponentName "yarn-config" -File $coreSiteConfigFile
```

```output
Component   File
---------   ----
yarn-config {{…
```

This cmdlet create the component config of "yarn-config" based the existing config file $coreSiteConfigFile.

## PARAMETERS

### -ComponentName
Name of the component the config files should apply to.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ClusterServiceConfig

## NOTES

## RELATED LINKS
