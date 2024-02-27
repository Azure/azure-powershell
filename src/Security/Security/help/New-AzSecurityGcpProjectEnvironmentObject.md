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
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for GcpProjectEnvironment.

## EXAMPLES

### EXAMPLE 1
```
$orgData = New-AzSecurityGcpOrganizationalDataOrganizationObject -WorkloadIdentityProviderId "provider" -ServiceAccountEmailAddress "my@email.com" -ExcludedProjectNumber @(1,2)
```

New-AzSecurityGcpProjectEnvironmentObject -ProjectDetailProjectId "asc-sdk-samples" -ScanInterval 24 -OrganizationalData $orgData -ProjectDetailProjectNumber "1234"

## PARAMETERS

### -OrganizationalData
The Gcp project's organizational data.
.

```yaml
Type: IGcpOrganizationalData
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectDetailProjectId
The GCP Project id.

```yaml
Type: String
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
Type: String
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
Type: Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.GcpProjectEnvironment
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

ORGANIZATIONALDATA \<IGcpOrganizationalData\>: The Gcp project's organizational data.
  OrganizationMembershipType \<String\>: The multi cloud account's membership type in the organization

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritygcpprojectenvironmentobject](https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritygcpprojectenvironmentobject)

