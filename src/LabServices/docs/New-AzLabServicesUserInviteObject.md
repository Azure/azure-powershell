---
external help file:
Module Name: Az.LabServices
online version: https://docs.microsoft.com/powershell/module/az.LabServices/new-AzLabServicesUserInviteObject
schema: 2.0.0
---

# New-AzLabServicesUserInviteObject

## SYNOPSIS
Create a in-memory object for Lab Services User Invite.

## SYNTAX

```
New-AzLabServicesUserInviteObject -Text <String> [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for Lab Services User Invite.

## EXAMPLES

### Example 1: Create the user invite body.
```powershell
PS C:\> $inviteBody = New-AzLabServicesUserInviteObject -Text "Text Body"
PS C:\> Send-AzLabServicesUserInvite -LabName "Lab Name" -ResourceGroupName "Group Name" -UserName "User Name" -Body $inviteBody

```

This cmdlet creates the minimum information to invite users using the body parameter.

## PARAMETERS

### -Text


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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IInviteBody

## NOTES

ALIASES

## RELATED LINKS

