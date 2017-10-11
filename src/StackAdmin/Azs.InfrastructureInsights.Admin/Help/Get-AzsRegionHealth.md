---
external help file: Azs.InfrastructureInsights.Admin-help.xml
Module Name: Azs.InfrastructureInsights.Admin
online version: 
schema: 2.0.0
---

# Get-AzsRegionHealth

## SYNOPSIS
Get the regions health status.  Azure Stack currently only supports a single region.

## SYNTAX

### RegionHealths_List (Default)
```
Get-AzsRegionHealth [-Filter <String>] [-Skip <Int32>] -Location <String> [-Top <Int32>] [<CommonParameters>]
```

### RegionHealths_Get
```
Get-AzsRegionHealth -Region <String> -Location <String> [<CommonParameters>]
```

## DESCRIPTION
Get the regions health status.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsRegionHealth -Location local

Type                                                 Name  Location
----                                                 ----  --------
Microsoft.InfrastructureInsights.Admin/regionHealths local local
```

Get all regions health.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: RegionHealths_List
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Region
Name of the region

```yaml
Type: String
Parameter Sets: RegionHealths_Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: RegionHealths_List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: RegionHealths_List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.RegionHealth

## NOTES

## RELATED LINKS

