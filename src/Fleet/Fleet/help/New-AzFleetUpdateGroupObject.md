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
New-AzFleetUpdateGroupObject -Name <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.UpdateGroup

## NOTES

## RELATED LINKS
