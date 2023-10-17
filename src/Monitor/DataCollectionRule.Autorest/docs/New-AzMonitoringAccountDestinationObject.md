---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azmonitoringaccountdestinationobject
schema: 2.0.0
---

# New-AzMonitoringAccountDestinationObject

## SYNOPSIS
Create an in-memory object for MonitoringAccountDestination.

## SYNTAX

```
New-AzMonitoringAccountDestinationObject [-AccountResourceId <String>] [-Name <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for MonitoringAccountDestination.

## EXAMPLES

### Example 1: Create monitoring account destination object
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

This command creates a monitoring account destination object.

## PARAMETERS

### -AccountResourceId
The resource ID of the monitoring account.

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

### -Name
A friendly name for the destination.
        This name should be unique across all destinations (regardless of type) within the data collection rule.

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.MonitoringAccountDestination

## NOTES

## RELATED LINKS

