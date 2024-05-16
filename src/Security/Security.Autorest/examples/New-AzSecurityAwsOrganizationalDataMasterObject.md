### Example 1: Create new AwsOrganizationalDataMaster object
```powershell
New-AzSecurityAwsOrganizationalDataMasterObject -StacksetName "myAwsStackSet" -ExcludedAccountId "123456789012"
```

```output
ExcludedAccountId OrganizationMembershipType StacksetName
----------------- -------------------------- ------------
{123456789012}    Organization               myAwsStackSet
```

