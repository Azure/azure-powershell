---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Stop-AzsScaleUnitNode

## SYNOPSIS
Power off a scale unit node.

## SYNTAX

### Stop (Default)
```
Stop-AzsScaleUnitNode -Name <String> [-Location <String>] [-ResourceGroupName <String>] [-Shutdown] [-Wait]
 [<CommonParameters>]
```

### ResourceId
```
Stop-AzsScaleUnitNode -ResourceId <String> [-Shutdown] [-Wait] [<CommonParameters>]
```

## DESCRIPTION
Power off a scale unit node.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Stop-AzsScaleUnitNode -ResourceGroup "System.local" -Location "local" -ScaleUnitNode "HC1n25r2236" -Shutdown
```

ProvisioningState : Succeeded

Shutdown a scale unit node.

### -------------------------- EXAMPLE 2 --------------------------
```
Stop-AzsScaleUnitNode -ResourceGroup "System.local" -Location "local" -ScaleUnitNode "HC1n25r2236"
```

ProvisioningState : Succeeded

Power down a scale unit node.

## PARAMETERS

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: Stop
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
Parameter Sets: Stop
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
Parameter Sets: Stop
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

### -Shutdown
If set gracefully shutdown the scale unit node; otherwise hard power off the scale unit node.

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

