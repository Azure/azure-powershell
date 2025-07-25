---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azeventhubdirectdestinationobject
schema: 2.0.0
---

# New-AzEventHubDirectDestinationObject

## SYNOPSIS
Create an in-memory object for EventHubDirectDestination.

## SYNTAX

```
New-AzEventHubDirectDestinationObject [-EventHubResourceId <String>] [-Name <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for EventHubDirectDestination.

## EXAMPLES

### Example 1: Create event hub direct destination object
```powershell
New-AzEventHubDirectDestinationObject -EventHubResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.EventHub/namespaces/amcseastushub -Name testHubDirect
```

```output
EventHubResourceId                                                                                                                 Name
------------------                                                                                                                 ----
/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.EventHub/namespaces/amcseastushub testHubDirect
```

This command creates event hub direct destination object.

## PARAMETERS

### -EventHubResourceId
The resource ID of the event hub.

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.EventHubDirectDestination

## NOTES

## RELATED LINKS
