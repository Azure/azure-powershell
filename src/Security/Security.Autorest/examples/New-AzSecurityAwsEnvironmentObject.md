### Example 1: Create new AwsEnvironment object
```powershell
$organization = New-AzSecurityAwsOrganizationalDataMasterObject -StacksetName "myAwsStackSet" -ExcludedAccountId "123456789012"
$environment = New-AzSecurityAwsEnvironmentObject -Region "Central US" -ScanInterval 24 -OrganizationalData $organization

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


