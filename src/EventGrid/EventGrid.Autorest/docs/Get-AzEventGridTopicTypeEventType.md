---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/get-azeventgridtopictypeeventtype
schema: 2.0.0
---

# Get-AzEventGridTopicTypeEventType

## SYNOPSIS
List event types for a topic type.

## SYNTAX

```
Get-AzEventGridTopicTypeEventType -TopicTypeName <String> [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
List event types for a topic type.

## EXAMPLES

### Example 1: List event types for a topic type.
```powershell
Get-AzEventGridTopicTypeEventType -TopicTypeName Microsoft.Eventhub.Namespaces
```

```output
Name
----
Microsoft.EventHub.CaptureFileCreated
```

List event types for a topic type.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopicTypeName
Name of the topic type.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventType

## NOTES

## RELATED LINKS

