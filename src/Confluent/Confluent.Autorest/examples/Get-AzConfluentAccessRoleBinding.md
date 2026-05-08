### Example 1: List all Role Bindings under organization in the resource group
```powershell
Get-AzConfluentAccessRoleBinding -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Get-AzConfluentAccessRoleBinding_ListExpanded: must not be null
```

This command lists all confluent Role Bindings under a organization and resource group
