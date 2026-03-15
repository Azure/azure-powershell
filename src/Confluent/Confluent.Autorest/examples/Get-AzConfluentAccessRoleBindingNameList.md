### Example 1: List all available role binding names
```powershell
Get-AzConfluentAccessRoleBindingNameList -ResourceGroupName confluent-rg -OrganizationName confluentorg-01
```

```output
OrganizationAdmin
EnvironmentAdmin
CloudClusterAdmin
MetricsViewer
Developer
```

This command lists all available role names that can be used for role bindings in the Confluent organization.

### Example 2: Get role binding names for specific resource
```powershell
Get-AzConfluentAccessRoleBindingNameList -ResourceGroupName confluent-rg -OrganizationName confluentorg-01
```

This command retrieves the available role binding names for the organization.

