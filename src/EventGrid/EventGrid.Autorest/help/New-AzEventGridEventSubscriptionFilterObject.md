---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgrideventsubscriptionfilterobject
schema: 2.0.0
---

# New-AzEventGridEventSubscriptionFilterObject

## SYNOPSIS
Create an in-memory object for EventSubscriptionFilter.

## SYNTAX

```
New-AzEventGridEventSubscriptionFilterObject [-AdvancedFilter <IAdvancedFilter[]>]
 [-EnableAdvancedFilteringOnArray <Boolean>] [-IncludedEventType <String[]>]
 [-IsSubjectCaseSensitive <Boolean>] [-SubjectBeginsWith <String>] [-SubjectEndsWith <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for EventSubscriptionFilter.

## EXAMPLES

### Example 1: Create an in-memory object for EventSubscriptionFilter.
```powershell
$adviceObj = New-AzEventGridBoolEqualsAdvancedFilterObject -Key "testKey" -Value:$true
New-AzEventGridEventSubscriptionFilterObject -AdvancedFilter $adviceObj -EnableAdvancedFilteringOnArray:$true -IncludedEventType "test" -IsSubjectCaseSensitive:$true -SubjectBeginsWith "startTest" -SubjectEndsWith "endTest"
```

```output
EnableAdvancedFilteringOnArray IsSubjectCaseSensitive SubjectBeginsWith SubjectEndsWith
------------------------------ ---------------------- ----------------- ---------------
True                           True                   startTest         endTest
```

Create an in-memory object for EventSubscriptionFilter.

## PARAMETERS

### -AdvancedFilter
An array of advanced filters that are used for filtering event subscriptions.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IAdvancedFilter[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableAdvancedFilteringOnArray
Allows advanced filters to be evaluated against an array of values instead of expecting a singular value.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludedEventType
A list of applicable event types that need to be part of the event subscription.
If it is desired to subscribe to all default event types, set the IncludedEventTypes to null.

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

### -IsSubjectCaseSensitive
Specifies if the SubjectBeginsWith and SubjectEndsWith properties of the filter
        should be compared in a case sensitive manner.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubjectBeginsWith
An optional string to filter events for an event subscription based on a resource path prefix.
        The format of this depends on the publisher of the events.
        Wildcard characters are not supported in this path.

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

### -SubjectEndsWith
An optional string to filter events for an event subscription based on a resource path suffix.
        Wildcard characters are not supported in this path.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.EventSubscriptionFilter

## NOTES

## RELATED LINKS

