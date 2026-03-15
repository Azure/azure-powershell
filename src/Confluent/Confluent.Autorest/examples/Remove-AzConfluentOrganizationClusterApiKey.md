### Example 1: Remove a cluster API key
```powershell
Remove-AzConfluentOrganizationClusterApiKey -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -ApiKeyId key-abc123
```

This command removes an API key from the cluster.

### Example 2: Remove API key without confirmation
```powershell
Remove-AzConfluentOrganizationClusterApiKey -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -ApiKeyId key-def456 -Confirm:$false
```

This command removes an API key without prompting for confirmation.

