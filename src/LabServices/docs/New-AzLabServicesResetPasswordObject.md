---
external help file:
Module Name: Az.LabServices
online version: https://docs.microsoft.com/powershell/module/az.LabServices/new-AzLabServicesResetPasswordObject
schema: 2.0.0
---

# New-AzLabServicesResetPasswordObject

## SYNOPSIS
Create a in-memory object for Lab Services Reset Password.

## SYNTAX

```
New-AzLabServicesResetPasswordObject -Password <SecureString> [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for Lab Services Reset Password.

## EXAMPLES

### Example 1: Create reset vm password body.
```powershell
PS C:\> $resetBody = New-AzLabServicesResetPasswordObject -Password $(ConvertTo-SecureString "Password" -AsPlainText -Force)
PS C:\> Reset-AzLabServicesVMPassword -LabName "Lab Name" -ResourceGroupName "Group Name" -VirtualMachineName 1 -Body $resetBody 

```

This cmdlet creates the minimum information to reset a VM password using the body parameter.

## PARAMETERS

### -Password


```yaml
Type: System.Security.SecureString
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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IResetPasswordBody

## NOTES

ALIASES

## RELATED LINKS

