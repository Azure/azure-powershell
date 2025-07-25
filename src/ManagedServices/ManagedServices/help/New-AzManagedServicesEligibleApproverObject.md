---
external help file: Az.ManagedServices-help.xml
Module Name: Az.ManagedServices
online version: https://learn.microsoft.com/powershell/module/Az.ManagedServices/new-AzManagedServicesEligibleApproverObject
schema: 2.0.0
---

# New-AzManagedServicesEligibleApproverObject

## SYNOPSIS
Create an in-memory object for EligibleApprover.

## SYNTAX

```
New-AzManagedServicesEligibleApproverObject -PrincipalId <String> [-PrincipalIdDisplayName <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for EligibleApprover.

## EXAMPLES

### Example 1: Creates Azure Lighthouse eligible authorization approver object
```powershell
New-AzManagedServicesEligibleApproverObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Approvers group"
```

```output
PrincipalId                          PrincipalIdDisplayName
-----------                          ----------------------
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Approvers group
```

Creates Azure Lighthouse eligible authorization approver object.

## PARAMETERS

### -PrincipalId
The identifier of the Azure Active Directory principal.

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

### -PrincipalIdDisplayName
The display name of the Azure Active Directory principal.

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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.EligibleApprover

## NOTES

## RELATED LINKS
