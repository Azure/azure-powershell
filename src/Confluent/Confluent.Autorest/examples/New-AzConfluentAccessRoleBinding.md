### Example 1: Create a new role binding for a user
```powershell
New-AzConfluentAccessRoleBinding -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -Principal "User:u-123" -RoleName "EnvironmentAdmin" -CrnPattern "crn://confluent.cloud/organization=o-123/environment=env-abc123"
```

```output
Id          Principal     RoleName         CrnPattern
--          ---------     --------         ----------
rb-new123   User:u-123    EnvironmentAdmin crn://confluent.cloud/organization=o-123/environment=env-abc123
```

This command creates a new role binding assigning EnvironmentAdmin role to a user.

### Example 2: Create role binding for service account
```powershell
New-AzConfluentAccessRoleBinding -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -Principal "User:sa-456" -RoleName "CloudClusterAdmin" -CrnPattern "crn://confluent.cloud/organization=o-123/environment=env-abc123/cloud-cluster=lkc-abc123"
```

This command creates a role binding for a service account with cluster admin access.

