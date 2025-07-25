---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azeventhubdestinationobject
schema: 2.0.0
---

# New-AzEventHubDestinationObject

## SYNOPSIS
Create an in-memory object for EventHubDestination.

## SYNTAX

```
New-AzEventHubDestinationObject [-EventHubResourceId <String>] [-Name <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for EventHubDestination.

## EXAMPLES

### Example 1: Create event hub destination object
```powershell
New-AzEventHubDestinationObject -EventHubResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.EventHub/namespaces/amcseastushub -Name testHub
```

```output
EventHubResourceId                                                                                                                 Name
------------------                                                                                                                 ----
/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.EventHub/namespaces/amcseastushub testHub
```

This command creates event hub destination object.

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.EventHubDestination

## NOTES

## RELATED LINKS
