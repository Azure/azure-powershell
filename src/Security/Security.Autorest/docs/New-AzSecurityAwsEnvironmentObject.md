---
external help file:
Module Name: Az.Security
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

### Example 1: Create new AwsEnvironment object as member
```powershell
$member = New-AzSecurityAwsOrganizationalDataMemberObject -ParentHierarchyId "123"
New-AzSecurityAwsEnvironmentObject -Region "Central US" -ScanInterval 24 -OrganizationalData $member
```

```output
AccountName        : 
EnvironmentType    : AwsAccount
OrganizationalData : {
                       "organizationMembershipType": "Member",
                       "parentHierarchyId": "123"
                     }
Region             : {Central US}
ScanInterval       : 24
```



### Example 2: Create new AwsEnvironment object as organization
```powershell
$organization = New-AzSecurityAwsOrganizationalDataMasterObject -StacksetName "myAwsStackSet" -ExcludedAccountId "123456789012"
New-AzSecurityAwsEnvironmentObject -Region "Central US" -ScanInterval 24 -OrganizationalData $organization
```

```output
AccountName        : 
EnvironmentType    : AwsAccount
OrganizationalData : {
                       "organizationMembershipType": "Organization",
                       "stacksetName": "myAwsStackSet",
                       "excludedAccountIds": [ "123456789012" ]
                     }
Region             : {Central US}
ScanInterval       : 24
```



## PARAMETERS

### -OrganizationalData
The AWS account's organizational data.
To construct, see NOTES section for ORGANIZATIONALDATA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAwsOrganizationalData
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
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.AwsEnvironment

## NOTES

## RELATED LINKS

