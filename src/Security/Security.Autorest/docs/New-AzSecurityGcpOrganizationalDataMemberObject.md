---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritygcporganizationaldatamemberobject
schema: 2.0.0
---

# New-AzSecurityGcpOrganizationalDataMemberObject

## SYNOPSIS
Create an in-memory object for GcpOrganizationalDataMember.

## SYNTAX

```
New-AzSecurityGcpOrganizationalDataMemberObject [-ManagementProjectNumber <String>]
 [-ParentHierarchyId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for GcpOrganizationalDataMember.

## EXAMPLES

### Example 1: Create new GcpOrganizationalDataMember object
```powershell
New-AzSecurityGcpOrganizationalDataMemberObject -ManagementProjectNumber "12345" -ParentHierarchyId "00000"
```

```output
ManagementProjectNumber OrganizationMembershipType ParentHierarchyId
----------------------- -------------------------- -----------------
12345                   Member                     00000
```



## PARAMETERS

### -ManagementProjectNumber
The GCP management project number from organizational onboarding.

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

### -ParentHierarchyId
If the multi cloud account is not of membership type organization, this will be the ID of the project's parent.

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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.GcpOrganizationalDataMember

## NOTES

## RELATED LINKS

