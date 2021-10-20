---
external help file:
Module Name: Az.LabServices
online version: https://docs.microsoft.com/powershell/module/az.LabServices/new-AzLabServicesSaveImageObject
schema: 2.0.0
---

# New-AzLabServicesSaveImageObject

## SYNOPSIS
Create a in-memory object for Lab Services Save Image.

## SYNTAX

```
New-AzLabServicesSaveImageObject -Name <String> -VirtualMachineId <String> [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for Lab Services Save Image.

## EXAMPLES

### Example 1: Create save image body.
```powershell
PS C:\> $saveBody = New-AzLabServicesSaveImageObject -Name "Image Name" -VirtualMachineId "Virtual Machine Id"
Save-AzLabServicesLabPlanImage -ResourceGroupName "Group Name" -LabPlanName "Lab Plan Name" -Body $saveBody

```

This cmdlet creates the minimum information to save an image using the body parameter.

## PARAMETERS

### -Name


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

### -VirtualMachineId


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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ISaveImageBody

## NOTES

ALIASES

## RELATED LINKS

