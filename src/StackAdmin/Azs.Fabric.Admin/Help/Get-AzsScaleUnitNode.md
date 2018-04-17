---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsScaleUnitNode

## SYNOPSIS
Returns a list of all scale unit nodes in a location.

## SYNTAX

### List (Default)
```
Get-AzsScaleUnitNode [-Location <String>] [-ResourceGroupName <String>] [-Filter <String>] [-Skip <Int32>]
 [-Top <Int32>] [<CommonParameters>]
```

### Get
```
Get-AzsScaleUnitNode [-Name] <String> [-Location <String>] [-ResourceGroupName <String>] [<CommonParameters>]
```

### ResourceId
```
Get-AzsScaleUnitNode -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Returns a list of all scale unit nodes in a location.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsScaleUnitNode -ResourceGroup "System.local" -Location "local"
```

BiosVersion Type                                                  Name        ScaleUnitName CanPowerOff
----------- ----                                                  ----        ------------- -----------
            Microsoft.Fabric.Admin/fabricLocations/scaleUnitNodes HC1n25r2230 S-Cluster     False
            Microsoft.Fabric.Admin/fabricLocations/scaleUnitNodes HC1n25r2231 S-Cluster     False
            Microsoft.Fabric.Admin/fabricLocations/scaleUnitNodes HC1n25r2232 S-Cluster     False
            Microsoft.Fabric.Admin/fabricLocations/scaleUnitNodes HC1n25r2233 S-Cluster     False

Get all scale unit nodes at a location.

### -------------------------- EXAMPLE 2 --------------------------
```
Get-AzsScaleUnitNode -ResourceGroup "System.local" -Location "local" -ScaleUnitNode "HC1n25r2231"
```

BiosVersion Type                                                  Name        ScaleUnitName CanPowerOff
----------- ----                                                  ----        ------------- -----------
            Microsoft.Fabric.Admin/fabricLocations/scaleUnitNodes HC1n25r2231 S-Cluster     False

Get a specific scale unit node at a location given a name.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: List
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
Parameter Sets: List, Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the scale unit node.

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group in which the resource provider has been registered.

```yaml
Type: String
Parameter Sets: List, Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: List
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
Parameter Sets: List
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

