---
external help file: Az.HdInsightOnAks-help.xml
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/Az.HdInsightOnAks/new-azhdinsightonaksclusterconfigfileobject
schema: 2.0.0
---

# New-AzHdInsightOnAksClusterConfigFileObject

## SYNOPSIS
Create an in-memory object for ClusterConfigFile.

## SYNTAX

```
New-AzHdInsightOnAksClusterConfigFileObject -FileName <String> [-Content <String>] [-Encoding <String>]
 [-Path <String>] [-Value <IClusterConfigFileValues>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ClusterConfigFile.

## EXAMPLES

### Example 1: Create cluster config file
```powershell
$coreSiteConfigFile=New-AzHdInsightOnAksClusterConfigFileObject -FileName "core-site.xml" -Value @{"fs.defaultFS"="abfs://testcontainer@$teststorage.dfs.core.windows.net"}
```

This cmdlet create the config file "core-site.xml" and set the key "fs.defaultFS" with the value "abfs://testcontainer@$teststorage.dfs.core.windows.net" in this file.

## PARAMETERS

### -Content
Free form content of the entire configuration file.

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

### -Encoding
This property indicates if the content is encoded and is case-insensitive.
Please set the value to base64 if the content is base64 encoded.
Set it to none or skip it if the content is plain text.

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

### -FileName
Configuration file name.

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

### -Path
Path of the config file if content is specified.

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

### -Value
List of key value pairs
        where key represents a valid service configuration name and value represents the value of the config.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterConfigFileValues
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ClusterConfigFile

## NOTES

## RELATED LINKS
