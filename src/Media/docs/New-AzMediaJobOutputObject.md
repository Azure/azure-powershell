---
external help file:
Module Name: Az.Media
online version: https://learn.microsoft.com/powershell/module/az.Media/new-AzMediaJobOutputObject
schema: 2.0.0
---

# New-AzMediaJobOutputObject

## SYNOPSIS
Create an in-memory object for JobOutput.

## SYNTAX

```
New-AzMediaJobOutputObject -OdataType <String> [-Label <String>] [-PresetOverrideOdataType <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for JobOutput.

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

### -Label
A label that is assigned to a JobOutput in order to help uniquely identify it.
This is useful when your Transform has more than one TransformOutput, whereby your Job has more than one JobOutput.
In such cases, when you submit the Job, you will add two or more JobOutputs, in the same order as TransformOutputs in the Transform.
Subsequently, when you retrieve the Job, either through events or on a GET request, you can use the label to easily identify the JobOutput.
If a label is not provided, a default value of '{presetName}_{outputIndex}' will be used, where the preset name is the name of the preset in the corresponding TransformOutput and the output index is the relative index of the this JobOutput within the Job.
Note that this index is the same as the relative index of the corresponding TransformOutput within its Transform.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OdataType
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

### -PresetOverrideOdataType
The discriminator for derived types.

```yaml
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20211101.JobOutput

## NOTES

ALIASES

## RELATED LINKS

