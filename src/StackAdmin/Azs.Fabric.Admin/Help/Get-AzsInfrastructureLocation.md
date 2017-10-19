---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsInfrastructureLocation

## SYNOPSIS
Get a list of all fabric locations.

## SYNTAX

### FabricLocations_List (Default)
```
Get-AzsInfrastructureLocation [-Filter <String>] [-Skip <Int32>] -Location <String> [-Top <Int32>]
 [<CommonParameters>]
```

### FabricLocations_Get
```
Get-AzsInfrastructureLocation -FabricLocation <String> -Location <String> [<CommonParameters>]
```

## DESCRIPTION
Get a list of all fabric locations.

## EXAMPLES

### Example 1
```
PS C:\> 
Get-AzsInfrastructureLocation -Location "local"

Name  Type                                   Location
----  ----                                   --------
local Microsoft.Fabric.Admin/fabricLocations local
```

Return a list of all fabric locations.

## PARAMETERS

### -FabricLocation
Fabric Location.

```yaml
Type: String
Parameter Sets: FabricLocations_Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: FabricLocations_List
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location of the resource.

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

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: FabricLocations_List
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
Parameter Sets: FabricLocations_List
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

### Microsoft.AzureStack.Management.Fabric.Admin.Models.FabricLocation

## NOTES

## RELATED LINKS

