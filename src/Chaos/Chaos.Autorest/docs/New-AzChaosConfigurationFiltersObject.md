---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/Az.Chaos/new-azchaosconfigurationfiltersobject
schema: 2.0.0
---

# New-AzChaosConfigurationFiltersObject

## SYNOPSIS
Create an in-memory object for ConfigurationFilters.

## SYNTAX

```
New-AzChaosConfigurationFiltersObject [-Location <String[]>] [-PhysicalZone <String[]>] [-Zone <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ConfigurationFilters.

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

### -Location
Array of Azure location strings.
Only resources in these locations are included.

        Null or omitted means all locations (no filter).
Empty array means include nothing.

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

### -PhysicalZone
SENTRECURSIVE.

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

### -Zone
Array of availability zone identifiers ("1", "2", "3", "zone-redundant").
        Only resources whose zones intersect this list are included.

        Null or omitted means all zones (including non-zonal).
Empty array means include nothing.

        Mutually exclusive with physicalZones — set one or the other, not both.

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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ConfigurationFilters

## NOTES

## RELATED LINKS

