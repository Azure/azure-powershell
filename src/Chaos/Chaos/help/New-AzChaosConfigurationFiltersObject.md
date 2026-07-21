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

### Example 1: Create configuration filters for a region and zone
```powershell
New-AzChaosConfigurationFiltersObject -Location 'eastus' -Zone '1'
```

```output
Location Zone
-------- ----
{eastus} {1}
```

Creates an in-memory configuration filter that limits a scenario configuration to `eastus` availability zone `1`.
Pass the result to `New-AzChaosScenarioConfiguration`.

### Example 2: Create configuration filters spanning multiple zones
```powershell
New-AzChaosConfigurationFiltersObject -Location 'eastus','westus2' -Zone '1','2','3'
```

```output
Location           Zone
--------           ----
{eastus, westus2}  {1, 2, 3}
```

Creates a configuration filter that spans two regions and three availability zones.

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
Array of physical availability zone identifiers in '{region}-az{N}' format (for example, 'westus2-az1').
Only resources in the corresponding logical zone for each subscription are included.
At execution time, each physical zone is resolved to per-subscription logical zones via the Azure locations API.
The resolved mapping is surfaced on the scenario run response.
Null or omitted means physical zone targeting is not used.
Only one physical zone is supported in preview.
Mutually exclusive with the zones filter; set one or the other, not both.

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

