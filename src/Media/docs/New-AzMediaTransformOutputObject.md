---
external help file:
Module Name: Az.Media
online version: https://learn.microsoft.com/powershell/module/az.Media/new-AzMediaTransformOutputObject
schema: 2.0.0
---

# New-AzMediaTransformOutputObject

## SYNOPSIS
Create an in-memory object for TransformOutput.

## SYNTAX

```
New-AzMediaTransformOutputObject -PresetOdataType <String> [-OnError <OnErrorType>]
 [-RelativePriority <Priority>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for TransformOutput.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -OnError
A Transform can define more than one outputs.
This property defines what the service should do when one output fails - either continue to produce other outputs, or, stop the other outputs.
The overall Job state will not reflect failures of outputs that are specified with 'ContinueJob'.
The default is 'StopProcessingJob'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Media.Support.OnErrorType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PresetOdataType
The discriminator for derived types.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RelativePriority
Sets the relative priority of the TransformOutputs within a Transform.
This sets the priority that the service uses for processing TransformOutputs.
The default priority is Normal.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Media.Support.Priority
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20211101.TransformOutput

## NOTES

ALIASES

## RELATED LINKS

