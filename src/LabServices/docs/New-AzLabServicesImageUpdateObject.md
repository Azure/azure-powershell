---
external help file:
Module Name: Az.LabServices
online version: https://docs.microsoft.com/powershell/module/az.LabServices/new-AzLabServicesImageObject
schema: 2.0.0
---

# New-AzLabServicesImageUpdateObject

## SYNOPSIS
Create a in-memory object for Lab Services Image.

## SYNTAX

```
New-AzLabServicesImageUpdateObject -EnabledState <EnableState> [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for Lab Services Image.

## EXAMPLES

### Example 1: Create the update plan image body.
```powershell
PS C:\> $body = New-AzLabServicesImageUpdateObject -EnabledState "Enabled"
PS C:\> Update-AzLabServicesLabPlanImage -ImageName 'canonical.0001-com-ubuntu-server-focal.20_04-lts' -LabPlanName "Plan Name" -ResourceGroupName "Group Name" -Body $body

Name
----
canonical.0001-com-ubuntu-server-focal.20_04-lts
```

This cmdlet creates the minimum information to update an image in a lab plan using the body parameter.

## PARAMETERS

### -EnabledState


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState
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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IImageUpdate

## NOTES

ALIASES

## RELATED LINKS

