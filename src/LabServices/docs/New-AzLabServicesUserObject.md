---
external help file:
Module Name: Az.LabServices
online version: https://docs.microsoft.com/powershell/module/az.LabServices/new-AzLabServicesUserObject
schema: 2.0.0
---

# New-AzLabServicesUserObject

## SYNOPSIS
Create a in-memory object for Lab Services User.

## SYNTAX

```
New-AzLabServicesUserObject -Email <String> [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for Lab Services User.

## EXAMPLES

### Example 1: Create user body.
```powershell
PS C:\> $userBody = New-AzLabServicesUserObject -Email "Email@contoso.com"
PS C:\> New-AzLabServicesUser -ResourceGroupName "Group Name" -LabName "Lab Name" -Name "User Name" ` $rg -Body $userBody

Name
----
User Name
```

This cmdlet creates the minimum information to save or update a User using the body parameter.

## PARAMETERS

### -Email


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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IUser

## NOTES

ALIASES

## RELATED LINKS

