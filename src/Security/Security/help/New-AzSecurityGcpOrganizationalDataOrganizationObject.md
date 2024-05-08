---
external help file: Az.Security-help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritygcporganizationaldataorganizationobject
schema: 2.0.0
---

# New-AzSecurityGcpOrganizationalDataOrganizationObject

## SYNOPSIS
Create an in-memory object for GcpOrganizationalDataOrganization.

## SYNTAX

```
New-AzSecurityGcpOrganizationalDataOrganizationObject [-ExcludedProjectNumber <String[]>]
 [-ServiceAccountEmailAddress <String>] [-WorkloadIdentityProviderId <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for GcpOrganizationalDataOrganization.

## EXAMPLES

### Example 1: Create new GcpOrganizationalDataOrganization object
```powershell
New-AzSecurityGcpOrganizationalDataOrganizationObject -WorkloadIdentityProviderId "provider" -ServiceAccountEmailAddress "my@email.com" -ExcludedProjectNumber @(1,2)
```

```output
ExcludedProjectNumber      : {1, 2}
OrganizationMembershipType : Organization
OrganizationName           : 
ServiceAccountEmailAddress : my@email.com
WorkloadIdentityProviderId : provider
```

## PARAMETERS

### -ExcludedProjectNumber
If the multi cloud account is of membership type organization, list of accounts excluded from offering.

```yaml
Type: System.String[]
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

### -ServiceAccountEmailAddress
The service account email address which represents the organization level permissions container.

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

### -WorkloadIdentityProviderId
The GCP workload identity provider id which represents the permissions required to auto provision security connectors.

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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.GcpOrganizationalDataOrganization

## NOTES

## RELATED LINKS
