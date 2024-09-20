---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-aziislogsdatasourceobject
schema: 2.0.0
---

# New-AzIisLogsDataSourceObject

## SYNOPSIS
Create an in-memory object for IisLogsDataSource.

## SYNTAX

```
New-AzIisLogsDataSourceObject -Stream <String[]> [-LogDirectory <String[]>] [-Name <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for IisLogsDataSource.

## EXAMPLES

### Example 1: Create iis logs data source object
```powershell
New-AzIisLogsDataSourceObject -Stream "Microsoft-W3CIISLog" -LogDirectory "c:\\test" -Name "iisLogsDataSource"
```

```output
LogDirectory Name              Stream
------------ ----              ------
{c:\\test}   iisLogsDataSource {Microsoft-W3CIISLog}
```

This command creates iis logs data source object.

## PARAMETERS

### -LogDirectory
Absolute paths file location.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
A friendly name for the data source.
        This name should be unique across all data sources (regardless of type) within the data collection rule.

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

### -Stream
IIS streams.

```yaml
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IisLogsDataSource

## NOTES

## RELATED LINKS
