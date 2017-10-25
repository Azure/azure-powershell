---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsScaleUnit

## SYNOPSIS
Get scale units.

## SYNTAX

### ScaleUnits_List (Default)
```
Get-AzsScaleUnit [-Filter <String>] [-Skip <Int32>] -Location <String> [-Top <Int32>] [<CommonParameters>]
```

### ScaleUnits_Get
```
Get-AzsScaleUnit -ScaleUnit <String> -Location <String> [<CommonParameters>]
```

## DESCRIPTION
Get scale units.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsScaleUnit -Location "local"

ScaleUnitType  Type                                              State   Name      Nodes
-------------  ----                                              -----   ----      -----
HyperConverged Microsoft.Fabric.Admin/fabricLocations/scaleUnits Running S-Cluster {/subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Fa...
HyperConverged Microsoft.Fabric.Admin/fabricLocations/scaleUnits Running T-Cluster {/subscriptions/1bc5e5ce-538b-4b18-b262-e6515965a959/resourceGroups/system.local/providers/Microsoft.Fa...
HyperConverged Microsoft.Fabric.Admin/fabricLocations/scaleUnits Running U-Cluster {/subscriptions/7a070dc8-6af5-4f7c-be74-52e5dc7978de/resourceGroups/system.local/providers/Microsoft.Fa...
```

Return a list of information about scale units.

### Example 2
```
PS C:\> Get-AzsScaleUnit -Location "local" -ScaleUnit "S-Cluster"

ScaleUnitType  Type                                              State   Name      Nodes
-------------  ----                                              -----   ----      -----
HyperConverged Microsoft.Fabric.Admin/fabricLocations/scaleUnits Running S-Cluster {/subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Fa...
```

Return information about a specific scale unit.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: ScaleUnits_List
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

### -ScaleUnit
Name of the scale units.

```yaml
Type: String
Parameter Sets: ScaleUnits_Get
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
Parameter Sets: ScaleUnits_List
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
Parameter Sets: ScaleUnits_List
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

### Microsoft.AzureStack.Management.Fabric.Admin.Models.ScaleUnit

## NOTES

## RELATED LINKS

