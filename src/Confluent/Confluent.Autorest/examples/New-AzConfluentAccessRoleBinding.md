### Example 1: Create Organization Role Bindings
```powershell
New-AzConfluentAccessRoleBinding `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -Principal "User:u-abc123" `
    -RoleName "OrganizationAdmin" `
    -CrnPattern "crn://confluent.cloud/organization=org-xxxxx"
```

```output
New-AzConfluentAccessRoleBinding_CreateExpanded: Forbidden Access
```

This command creates new organization role bindings