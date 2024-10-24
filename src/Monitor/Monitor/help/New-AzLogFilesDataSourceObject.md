---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azlogfilesdatasourceobject
schema: 2.0.0
---

# New-AzLogFilesDataSourceObject

## SYNOPSIS
Create an in-memory object for LogFilesDataSource.

## SYNTAX

```
New-AzLogFilesDataSourceObject -FilePattern <String[]> -Stream <String[]> [-Name <String>]
 [-SettingTextRecordStartTimestampFormat <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LogFilesDataSource.

## EXAMPLES

### Example 1: Create a custom text log data source object
```powershell
New-AzLogFilesDataSourceObject -FilePattern "C:\\JavaLogs\\*.log" -Stream "Custom-TabularData-ABC" -Name myTabularLogDataSource -SettingTextRecordStartTimestampFormat "yyyy-MM-ddTHH:mm:ssK"
```

```output
FilePattern                           : {C:\\JavaLogs\\*.log}
Format                                : text
Name                                  : myTabularLogDataSource
SettingTextRecordStartTimestampFormat : yyyy-MM-ddTHH:mm:ssK
Stream                                : {Custom-TabularData-ABC}
```

This command creates a custom text log data source object.

## PARAMETERS

### -FilePattern
File Patterns where the log files are located.

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

### -SettingTextRecordStartTimestampFormat
One of the supported timestamp formats.

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

### -Stream
List of streams that this data source will be sent to.
        A stream indicates what schema will be used for this data source.

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.LogFilesDataSource

## NOTES

## RELATED LINKS
