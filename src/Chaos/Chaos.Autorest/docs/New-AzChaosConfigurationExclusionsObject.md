---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/Az.Chaos/new-azchaosconfigurationexclusionsobject
schema: 2.0.0
---

# New-AzChaosConfigurationExclusionsObject

## SYNOPSIS
Create an in-memory object for ConfigurationExclusions.

## SYNTAX

```
New-AzChaosConfigurationExclusionsObject [-Resource <String[]>] [-Tag <IKeyValuePair[]>] [-Type <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ConfigurationExclusions.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -Resource
Array of specific resource IDs to exclude from fault injection.

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

### -Tag
Array of tag key-value pairs.
Resources with matching tags are excluded.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IKeyValuePair[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Array of resource types.
All resources of these types are excluded.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ConfigurationExclusions

## NOTES

## RELATED LINKS

