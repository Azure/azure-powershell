---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Stop-AzsScaleUnitNode

## SYNOPSIS
Power off a scale unit node.  This will turn off your physical machine and should be used with extreme caution.

## SYNTAX

```
Stop-AzsScaleUnitNode -ScaleUnitNode <String> -Location <String> [-AsJob]
```

## DESCRIPTION
Power off a scale unit node.  This will turn off your physical machine and should be used with extreme caution.

## EXAMPLES

### Example 1
```
PS C:\> Stop-AzsScaleUnitNode -Location "local" -ScaleUnitNode "HC1n25r2236"

ProvisioningState
-----------------------
Succeeded
```

Power down a scale unit node.  

## PARAMETERS

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
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Fabric.Admin.Models.OperationStatus

## NOTES

## RELATED LINKS

