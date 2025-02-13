---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/Az.Chaos/new-azchaosselectorobject
schema: 2.0.0
---

# New-AzChaosSelectorObject

## SYNOPSIS
Create an in-memory object for Selector.

## SYNTAX

```
New-AzChaosSelectorObject -Id <String> -Type <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Selector.

## EXAMPLES

### Example 1: Create an in-memory object for Selector.
```powershell
New-AzChaosSelectorObject -Id "selector1" -Type List
```

```output
Filter               : {
                         "type": "Simple"
                       }
FilterType           : Simple
Id                   : selector1
Type                 : List
Keys                 : {}
Values               : {}
Count                : 0
AdditionalProperties : {}
```

Create an in-memory object for Selector.

## PARAMETERS

### -Id
String of the selector ID.

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
Enum of the selector type.

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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.Selector

## NOTES

## RELATED LINKS

