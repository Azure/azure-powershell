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

### -------------------------- EXAMPLE 1 --------------------------
```powershell
New-AzChaosKeyValuePairObject -Key 'pressureLevel' -Value '95'
```



### -------------------------- EXAMPLE 2 --------------------------
```powershell
$parameters = @(
    New-AzChaosKeyValuePairObject -Key 'pressureLevel' -Value '95'
    New-AzChaosKeyValuePairObject -Key 'target' -Value 'all'
)
```



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

