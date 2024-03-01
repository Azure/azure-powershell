---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azsyslogdatasourceobject
schema: 2.0.0
---

# New-AzSyslogDataSourceObject

## SYNOPSIS
Create an in-memory object for SyslogDataSource.

## SYNTAX

```
New-AzSyslogDataSourceObject [-FacilityName <String[]>] [-LogLevel <String[]>] [-Name <String>]
 [-Stream <String[]>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SyslogDataSource.

## EXAMPLES

### Example 1: Create a sys log data source object with cron facility
```powershell
New-AzSyslogDataSourceObject -FacilityName cron -LogLevel Debug,Critical,Emergency -Name cronSyslog -Stream Microsoft-Syslog
```

```output
FacilityName LogLevel                     Name       Stream
------------ --------                     ----       ------
{cron}       {Debug, Critical, Emergency} cronSyslog {Microsoft-Syslog}
```

This command creates a sys log data source object.

### Example 2: Create a sys log data source object with sys log facility
```powershell
New-AzSyslogDataSourceObject -FacilityName syslog -LogLevel Alert,Critical,Emergency -Name syslogBase -Stream Microsoft-Syslog
```

```output
FacilityName LogLevel                     Name       Stream
------------ --------                     ----       ------
{syslog}     {Alert, Critical, Emergency} syslogBase {Microsoft-Syslog}
```

This command creates a sys log data source object.

## PARAMETERS

### -FacilityName
The list of facility names.

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

### -LogLevel
The log levels to collect.

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
List of streams that this data source will be sent to.
        A stream indicates what schema will be used for this data and usually what table in Log Analytics the data will be sent to.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.SyslogDataSource

## NOTES

## RELATED LINKS
