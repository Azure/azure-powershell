---
external help file: Az.Security-help.xml
Module Name: Az.security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecurityawsenvironmentobject
schema: 2.0.0
---

# New-AzSecurityAwsEnvironmentObject

## SYNOPSIS
Create an in-memory object for AwsEnvironment.

## SYNTAX

```
New-AzSecurityAwsEnvironmentObject [-OrganizationalData <IAwsOrganizationalData>] [-Region <String[]>]
 [-ScanInterval <Int64>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AwsEnvironment.

## EXAMPLES

### EXAMPLE 1
```
$member = New-AzSecurityAwsOrganizationalDataMemberObject -ParentHierarchyId "123"
```

New-AzSecurityAwsEnvironmentObject -Region "Central US" -ScanInterval 24 -OrganizationalData $member

### EXAMPLE 2
```
$organization = New-AzSecurityAwsOrganizationalDataMasterObject -StacksetName "myAwsStackSet" -ExcludedAccountId "123456789012"
```

New-AzSecurityAwsEnvironmentObject -Region "Central US" -ScanInterval 24 -OrganizationalData $organization

## PARAMETERS

### -OrganizationalData
The AWS account's organizational data.
.

```yaml
Type: IAwsOrganizationalData
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Region
list of regions to scan.

```yaml
Type: String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.AwsEnvironment
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

ORGANIZATIONALDATA \<IAwsOrganizationalData\>: The AWS account's organizational data.
  OrganizationMembershipType \<String\>: The multi cloud account's membership type in the organization

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/Az.Security/new-azsecurityawsenvironmentobject](https://learn.microsoft.com/powershell/module/Az.Security/new-azsecurityawsenvironmentobject)

