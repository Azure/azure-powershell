---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Add-AzsScaleUnitNode

## SYNOPSIS
Add a new scale unit.

## SYNTAX

### ScaleOut (Default)
```
Add-AzsScaleUnitNode -ScaleUnitName <String> -NodeList <ScaleOutScaleUnitParameters[]>
 [-AwaitStorageConvergence] [-Location <String>] [-ResourceGroupName <String>] [-Wait] [<CommonParameters>]
```

### ResourceId
```
Add-AzsScaleUnitNode -ResourceId <String> [-Wait] [<CommonParameters>]
```

## DESCRIPTION
Add a new scale unit.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Add-AzsScaleUnitNode -ResourceGroup "System.local" -Location "local" - ScaleUnit "Azs-ERC03" -NodeList $nodeList
```

Add a new scale unit node.

## PARAMETERS

### -AwaitStorageConvergence
Flag indicates if the operation should wait for storage to converge before returning.

```yaml
Type: SwitchParameter
Parameter Sets: ScaleOut
Aliases: 

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: ScaleOut
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeList
List of nodes in the scale unit.

```yaml
Type: ScaleOutScaleUnitParameters[]
Parameter Sets: ScaleOut
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group in which the resource provider has been registered.

```yaml
Type: String
Parameter Sets: ScaleOut
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Scale unit node resource ID.

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

### -ScaleUnitName
Name of the scale unit.

```yaml
Type: String
Parameter Sets: ScaleOut
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Wait
{{Fill Wait Description}}

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

