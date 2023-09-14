---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/new-azhdinsightaksclusterserviceconfig
schema: 2.0.0
---

# New-AzHdInsightAksClusterServiceConfig

## SYNOPSIS


## SYNTAX

```
New-AzHdInsightAksClusterServiceConfig -ComponentName <String> -File <IClusterConfigFile[]>
 [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: Create a component config.
```powershell
$coreSiteConfigFile=New-AzHDInsightAksClusterConfigFile -FileName "core-site.xml" -Value @{"fs.defaultFS"="abfs://testcontainer@$teststorage.dfs.core.windows.net"}
$yarnComponentConfig= New-AzHDInsightAksClusterServiceConfig -ComponentName "yarn-config" -File $coreSiteConfigFile
```

This cmdlet create the component config of "yarn-config" based the existing config file $coreSiteConfigFile.

## PARAMETERS

### -ComponentName


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
To construct, see NOTES section for FILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.IClusterConfigFile[]
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.IClusterServiceConfig

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`FILE <IClusterConfigFile[]>`: 
  - `FileName <String>`: Configuration file name.
  - `[Content <String>]`: Free form content of the entire configuration file.
  - `[Encoding <ContentEncoding?>]`: This property indicates if the content is encoded and is case-insensitive. Please set the value to base64 if the content is base64 encoded. Set it to none or skip it if the content is plain text.
  - `[Path <String>]`: Path of the config file if content is specified.
  - `[Value <IClusterConfigFileValues>]`: List of key value pairs         where key represents a valid service configuration name and value represents the value of the config.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

