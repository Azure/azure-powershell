---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Disable-AzsScaleUnitNode

## SYNOPSIS
Start maintenance mode for a scale unit node.  This begins the process of moving all resources off the node.

## SYNTAX

```
Disable-AzsScaleUnitNode -ScaleUnitNode <String> -Location <String> [-AsJob] [<CommonParameters>]
```

## DESCRIPTION
Start maintenance mode for a scale unit node.  This begins the process of moving all resources off the node.

## EXAMPLES

### Example 1
```
PS C:\> Disable-AzsScaleUnitNode -Location "local" -ScaleUnitNode "Node1"

ProvisioningState
-----------------------
Succeeded
```

Begin maintenance mode for a scale unit node.

## PARAMETERS

### -AsJob
Runs as job.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Fabric.Admin.Models.OperationStatus

## NOTES

## RELATED LINKS

