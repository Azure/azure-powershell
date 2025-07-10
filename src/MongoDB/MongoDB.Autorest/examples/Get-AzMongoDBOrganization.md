### Example 1: Get a specific MongoDB organization
```powershell
Get-AzMongoDbOrganization -Name "MongoDBCLITestOrg4" -ResourceGroupName "cli-test-rg"
```

```output
Name                 : MongoDBCLITestOrg4
ResourceGroupName    : cli-test-rg
Location             : East US 2
Type                 : Microsoft.MongoDB/organizations
```

Gets details of a specific MongoDB organization by name.

### Example 2: List all MongoDB organizations in a resource group
```powershell
Get-AzMongoDbOrganization -ResourceGroupName "cli-test-rg"
```

```output
Name                 : MongoDBCLITestOrg4
ResourceGroupName    : cli-test-rg
Location             : East US 2
Type                 : Microsoft.MongoDB/organizations
```

Lists all MongoDB organizations in the specified resource group.

