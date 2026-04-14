### Example 1: Remove Organization role bindings
```powershell
Remove-AzConfluentAccessRoleBinding `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -RoleBindingId "crb-xxxxx"
```

```output
""
```

This command removes organization role bindings