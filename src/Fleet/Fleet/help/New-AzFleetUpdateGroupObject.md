---
external help file: Az.Fleet-help.xml
Module Name: Az.Fleet
online version: https://learn.microsoft.com/powershell/module/Az.Fleet/new-azfleetupdategroupobject
schema: 2.0.0
---

# New-AzFleetUpdateGroupObject

## SYNOPSIS
Create an in-memory object for UpdateGroup.

## SYNTAX

```
New-AzFleetUpdateGroupObject -Name <String> [-AfterGate <IGateConfiguration[]>]
 [-BeforeGate <IGateConfiguration[]>] [-MaxConcurrency <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for UpdateGroup.

## EXAMPLES

### Example 1: Create a fleet update group
```powershell
New-AzFleetUpdateGroupObject -Name 'Group-a'
```

```output
Name
----
Group-a
```

This command create a fleet update group object.

## PARAMETERS

### -AfterGate
A list of Gates that will be created after this Group is executed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IGateConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BeforeGate
A list of Gates that will be created before this Group is executed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IGateConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxConcurrency
The max number of upgrades that can run concurrently in this specific group.
        Acts as a ceiling (and not a quota) for the number of concurrent upgrades within the group you want to tolerate at a time.
        Actual concurrency may be lower depending on stage-level concurrency limits or individual member conditions.
        Group maxConcurrency has a min value of "1".
The max value is min(number of clusters in the group, the stage maxConcurrency).
        If no value is provided, defaults to 1.
        Accepts either:
            • A fixed count, e.g.
"3"
            • A percentage, e.g.
"25%" (range 1-100).
Percentage is of the number of clusters in the group.
              Fractional results are rounded down.
A minimum of 1 upgrade is enforced.
        Examples:
            • "3" --\> up to 3 members from this group upgrade at once.
            • "100%" --\> "all at once", up to all members for this group upgrade at the same time.
            • "25%" --\> up to 25% of the members in the group will be upgraded at the same time.

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
Name of the group.
        It must match a group name of an existing fleet member.
.

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

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.UpdateGroup

## NOTES

## RELATED LINKS
