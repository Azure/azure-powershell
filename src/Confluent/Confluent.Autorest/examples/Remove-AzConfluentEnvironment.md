### Example 1: Remove an environment
```powershell
Remove-AzConfluentEnvironment -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123
```

This command removes an environment from the Confluent organization.

### Example 2: Remove environment by name
```powershell
Remove-AzConfluentEnvironment -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -Name dev-env -Force
```

This command removes an environment by name without confirmation prompt.

