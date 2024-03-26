---
external help file: Az.Security-help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecurityawsorganizationaldatamemberobject
schema: 2.0.0
---

# New-AzSecurityAwsOrganizationalDataMemberObject

## SYNOPSIS
Create an in-memory object for AwsOrganizationalDataMember.

## SYNTAX

```
New-AzSecurityAwsOrganizationalDataMemberObject [-ParentHierarchyId <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AwsOrganizationalDataMember.

## EXAMPLES

### Example 1: Create new AwsOrganizationalDataMember object
```powershell
New-AzSecurityAwsOrganizationalDataMemberObject -ParentHierarchyId "123"
```

```output
OrganizationMembershipType ParentHierarchyId
-------------------------- -----------------
Member                     123
```

## PARAMETERS

### -ParentHierarchyId
If the multi cloud account is not of membership type organization, this will be the ID of the account's parent.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.AwsOrganizationalDataMember

## NOTES

## RELATED LINKS
