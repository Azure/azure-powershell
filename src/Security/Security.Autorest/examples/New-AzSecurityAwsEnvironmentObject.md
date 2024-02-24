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

