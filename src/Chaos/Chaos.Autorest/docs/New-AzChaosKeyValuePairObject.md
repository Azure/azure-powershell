---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/Az.Chaos/new-azchaoskeyvaluepairobject
schema: 2.0.0
---

# New-AzChaosKeyValuePairObject

## SYNOPSIS
Create an in-memory object for KeyValuePair.

## SYNTAX

```
New-AzChaosKeyValuePairObject -Key <String> -Value <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for KeyValuePair.

## EXAMPLES

### Example 1: Create a key/value pair
```powershell
New-AzChaosKeyValuePairObject -Key 'pressureLevel' -Value '95'
```

```output
Key           Value
---           -----
pressureLevel 95
```

Creates an in-memory key/value pair for use as an action parameter or an exclusion tag.

### Example 2: Build a list of key/value pairs
```powershell
$parameters = @(
    New-AzChaosKeyValuePairObject -Key 'pressureLevel' -Value '95'
    New-AzChaosKeyValuePairObject -Key 'target' -Value 'all'
)
```

```output
Key           Value
---           -----
pressureLevel 95
target        all
```

Builds an array of key/value pairs to pass to a parameter that accepts multiple entries.

## PARAMETERS

### -Key
The name of the setting for the action.

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

### -Value
The value of the setting for the action.

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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.KeyValuePair

## NOTES

## RELATED LINKS

