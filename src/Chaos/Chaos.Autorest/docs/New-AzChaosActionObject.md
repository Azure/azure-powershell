---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/Az.Chaos/new-azchaosactionobject
schema: 2.0.0
---

# New-AzChaosActionObject

## SYNOPSIS
Create an in-memory object for Action.

## SYNTAX

```
New-AzChaosActionObject -Name <String> -Type <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Action.

## EXAMPLES

### Example 1: Create an in-memory object for Action.
```powershell
New-AzChaosActionObject -Name "urn:csci:microsoft:virtualMachine:shutdown/1.0" -Type "continuous"
```

```output
Name                                           Type
----                                           ----
urn:csci:microsoft:virtualMachine:shutdown/1.0 continuous
```

Create an in-memory object for Action.

## PARAMETERS

### -Name
String that represents a Capability URN.

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

### -Type
Enum that discriminates between action models.

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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.Action

## NOTES

## RELATED LINKS

