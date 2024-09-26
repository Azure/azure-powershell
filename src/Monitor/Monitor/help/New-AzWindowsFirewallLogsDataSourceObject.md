---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azwindowsfirewalllogsdatasourceobject
schema: 2.0.0
---

# New-AzWindowsFirewallLogsDataSourceObject

## SYNOPSIS
Create an in-memory object for WindowsFirewallLogsDataSource.

## SYNTAX

```
New-AzWindowsFirewallLogsDataSourceObject -Stream <String[]> [-Name <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for WindowsFirewallLogsDataSource.

## EXAMPLES

### Example 1: Create windows firewall logs data source object
```powershell
New-AzWindowsFirewallLogsDataSourceObject -Stream "Microsoft-WindowsFirewall","Microsoft-ASimNetworkSessionLogs-WindowsFirewall" -Name "myFirewallLogsDataSource1"
```

```output
Name                      Stream
----                      ------
myFirewallLogsDataSource1 {Microsoft-WindowsFirewall, Microsoft-ASimNetworkSessionLogs-WindowsFirewall}
```

This command creates a windows firewall log data source object.

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

### -Stream
Firewall logs streams.

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.WindowsFirewallLogsDataSource

## NOTES

## RELATED LINKS
