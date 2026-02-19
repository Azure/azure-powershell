### Example 1: List all role bindings in a Confluent organization
```powershell
Get-AzConfluentAccessRoleBinding -ResourceGroupName confluent-rg -OrganizationName confluentorg-01
```

```output
Id          Principal     RoleName         CrnPattern
--          ---------     --------         ----------
rb-abc123   User:u-123    OrganizationAdmin crn://confluent.cloud/organization=o-123
rb-def456   User:u-456    EnvironmentAdmin  crn://confluent.cloud/organization=o-123/environment=env-789
```

This command lists all role bindings in the specified Confluent organization.

### Example 2: List role bindings with search filters
```powershell
$searchFilters = @{SearchFilters = @{Principal = "User:u-123"}}
Get-AzConfluentAccessRoleBinding -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -SearchFilter $searchFilters
```

This command lists role bindings filtered by principal user.

