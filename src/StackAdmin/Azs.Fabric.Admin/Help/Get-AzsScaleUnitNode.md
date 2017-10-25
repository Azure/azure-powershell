---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsScaleUnitNode

## SYNOPSIS
Get scale unit nodes at a certain location.

## SYNTAX

### ScaleUnitNodes_List (Default)
```
Get-AzsScaleUnitNode [-Filter <String>] [-Skip <Int32>] -Location <String> [-Top <Int32>] [<CommonParameters>]
```

### ScaleUnitNodes_Get
```
Get-AzsScaleUnitNode -ScaleUnitNode <String> -Location <String> [<CommonParameters>]
```

## DESCRIPTION
Get scale unit nodes at a certain location.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsScaleUnitNode -Location "local"

BiosVersion Type                                                  Name        ScaleUnitName CanPowerOff
----------- ----                                                  ----        ------------- -----------
            Microsoft.Fabric.Admin/fabricLocations/scaleUnitNodes Node1 S-Cluster     False
            Microsoft.Fabric.Admin/fabricLocations/scaleUnitNodes Node2 S-Cluster     False
            Microsoft.Fabric.Admin/fabricLocations/scaleUnitNodes Node3 S-Cluster     False
            Microsoft.Fabric.Admin/fabricLocations/scaleUnitNodes Node4 S-Cluster     False
            ...
```

Get all scale unit nodes at a location.

### Example 2
```
PS C:\> Get-AzsScaleUnitNode -Location "local" -ScaleUnitNode "Node1"

BiosVersion Type                                                  Name        ScaleUnitName CanPowerOff
----------- ----                                                  ----        ------------- -----------
            Microsoft.Fabric.Admin/fabricLocations/scaleUnitNodes Node1 S-Cluster     False
```

Get a specific scale unit node at a location given a name.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: ScaleUnitNodes_List
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

### -ScaleUnitNode
Name of the scale unit node.

```yaml
Type: String
Parameter Sets: ScaleUnitNodes_Get
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
Parameter Sets: ScaleUnitNodes_List
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
Parameter Sets: ScaleUnitNodes_List
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

### Microsoft.AzureStack.Management.Fabric.Admin.Models.ScaleUnitNode

## NOTES

## RELATED LINKS

