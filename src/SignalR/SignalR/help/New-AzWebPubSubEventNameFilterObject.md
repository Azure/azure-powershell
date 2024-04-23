---
external help file: Az.SignalR-help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/new-azwebpubsubeventnamefilterobject
schema: 2.0.0
---

# New-AzWebPubSubEventNameFilterObject

## SYNOPSIS
Create an in-memory object for EventNameFilter.

## SYNTAX

```
New-AzWebPubSubEventNameFilterObject [-SystemEvent <String[]>] [-UserEventPattern <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for EventNameFilter.

## EXAMPLES

### Example 1: Create an event name filter object
```powershell
$filter = New-AzWebPubSubEventNameFilterObject -SystemEvent connected,disconnected -UserEventPattern *
$filter
```

```output
SystemEvent               UserEventPattern
-----------               ----------------
{connected, disconnected} *
```

## PARAMETERS

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

### -SystemEvent
Gets or sets a list of system events.
Supported events: "connected" and "disconnected".
Blocking event "connect" is not supported because it requires a response.

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

### -UserEventPattern
Gets or sets a matching pattern for event names.
        There are 3 kinds of patterns supported:
            1.
"*", it matches any event name
            2.
Combine multiple events with ",", for example "event1,event2", it matches events "event1" and "event2"
            3.
A single event name, for example, "event1", it matches "event1".

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

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20220801Preview.EventNameFilter

## NOTES

## RELATED LINKS
