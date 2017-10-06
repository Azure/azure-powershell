---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Start-AzsScaleUnitNode

## SYNOPSIS
Power on a scale unit node.

## SYNTAX

```
Start-AzsScaleUnitNode -ScaleUnitNode <String> -Location <String> [-AsJob]
```

## DESCRIPTION
Power on a scale unit node.

## EXAMPLES

### Example 1
```
PS C:\> Start-AzsScaleUnitNode -Location "local" -InfrastructureRoleInstance "AzS-ACS01"

ProvisioningState
-----------------
Succeeded
```

Power on a scale unit node.

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

