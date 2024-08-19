---
external help file: Az.Security-help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritygcpprojectenvironmentobject
schema: 2.0.0
---

# New-AzSecurityGcpProjectEnvironmentObject

## SYNOPSIS
Create an in-memory object for GcpProjectEnvironment.

## SYNTAX

```
New-AzSecurityGcpProjectEnvironmentObject [-OrganizationalData <IGcpOrganizationalData>]
 [-ProjectDetailProjectId <String>] [-ProjectDetailProjectNumber <String>] [-ScanInterval <Int64>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for GcpProjectEnvironment.

## EXAMPLES

### Example 1: Create new GcpOrganizationalDataOrganization object
```powershell
$orgData = New-AzSecurityGcpOrganizationalDataOrganizationObject -WorkloadIdentityProviderId "provider" -ServiceAccountEmailAddress "my@email.com" -ExcludedProjectNumber @(1,2)
New-AzSecurityGcpProjectEnvironmentObject -ProjectDetailProjectId "asc-sdk-samples" -ScanInterval 24 -OrganizationalData $orgData -ProjectDetailProjectNumber "1234"
```

```output
EnvironmentType                     : GcpProject
OrganizationalData                  : {
                                        "organizationMembershipType": "Organization",
                                        "excludedProjectNumbers": [ "1", "2" ],
                                        "serviceAccountEmailAddress": "my@email.com",
                                        "workloadIdentityProviderId": "provider"
                                      }
ProjectDetailProjectId              : asc-sdk-samples
ProjectDetailProjectName            : 
ProjectDetailProjectNumber          : 1234
ProjectDetailWorkloadIdentityPoolId : 
ScanInterval                        : 24
```

## PARAMETERS

### -OrganizationalData
The Gcp project's organizational data.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IGcpOrganizationalData
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

### -ProjectDetailProjectId
The GCP Project id.

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

### -ProjectDetailProjectNumber
The unique GCP Project number.

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

### -ScanInterval
Scan interval in hours (value should be between 1-hour to 24-hours).

```yaml
Type: System.Int64
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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.GcpProjectEnvironment

## NOTES

## RELATED LINKS
