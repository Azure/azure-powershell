---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azwindowseventlogdatasourceobject
schema: 2.0.0
---

# New-AzWindowsEventLogDataSourceObject

## SYNOPSIS
Create an in-memory object for WindowsEventLogDataSource.

## SYNTAX

```
New-AzWindowsEventLogDataSourceObject [-Name <String>] [-Stream <String[]>] [-XPathQuery <String[]>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for WindowsEventLogDataSource.

## EXAMPLES

### Example 1: Create a windows event log data source object
```powershell
New-AzWindowsEventLogDataSourceObject -Name cloudSecurityTeamEvents -Stream Microsoft-WindowsEvent -XPathQuery "Security!"
```

```output
Name                    Stream                   XPathQuery
----                    ------                   ----------
cloudSecurityTeamEvents {Microsoft-WindowsEvent} {Security!}
```

This command creates a windows event log data source object with XPathQuery.

### Example 2: Create a windows event log data source object
```powershell
New-AzWindowsEventLogDataSourceObject -Name appTeam1AppEvents -Stream Microsoft-WindowsEvent -XPathQuery "System![System[(Level = 1 or Level = 2 or Level = 3)]]","Application!*[System[(Level = 1 or Level = 2 or Level = 3)]]"
```

```output
Name              Stream                   XPathQuery
----              ------                   ----------
appTeam1AppEvents {Microsoft-WindowsEvent} {System![System[(Level = 1 or Level = 2 or Level = 3)]], Application!*[System[(Level = 1 or Level = 2 or Level = 3)]]}
```

This command creates a windows event log data source object with XPathQueries.

## PARAMETERS

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

### -XPathQuery
A list of Windows Event Log queries in XPATH format.

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.WindowsEventLogDataSource

## NOTES

## RELATED LINKS
