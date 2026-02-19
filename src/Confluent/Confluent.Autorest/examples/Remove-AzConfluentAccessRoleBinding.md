### Example 1: Remove a role binding by ID
```powershell
Remove-AzConfluentAccessRoleBinding -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -RoleBindingId rb-abc123
```

This command removes a specific role binding from the organization.

### Example 2: Remove role binding with confirmation
```powershell
Remove-AzConfluentAccessRoleBinding -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -RoleBindingId rb-def456 -Confirm:$false
```

This command removes a role binding without prompting for confirmation.

