### Example 1: Update a MongoDB organization
```powershell
Update-AzMongoDbOrganization -Name "MongoDBCLITestOrg4" -ResourceGroupName "cli-test-rg" -UserEmailAddress "ajaykumar@microsoft.com"
```

```output
Name                 : MongoDBCLITestOrg4
ResourceGroupName    : cli-test-rg
Location             : East US 2
Type                 : Microsoft.MongoDB/organizations
```

Updates the email address for an existing MongoDB organization.

