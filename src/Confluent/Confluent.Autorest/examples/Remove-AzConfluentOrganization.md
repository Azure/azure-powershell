### Example 1: Remove a confluent organization by name
```powershell
Remove-AzConfluentOrganization -ResourceGroupName azure-rg-test -Name confluentorg-01-portal
```

```output
- This action cannot be undone.
- This will permanently delete ‘<resource_name>’ and its Azure subscription
- Stop billing for the selected Confluent organization through Azure Marketplace
Do you want to proceed (Y/N)?: y
```

This command removes a confluent organization by name

### Example 2: Remove a confluent organization by pipeline
```powershell
Get-AzConfluentOrganization -ResourceGroupName azure-rg-test -Name confluentorg-02-pwsh | Remove-AzConfluentOrganization
```

```output
- This action cannot be undone.
- This will permanently delete ‘<resource_name>’ and its Azure subscription
- Stop billing for the selected Confluent organization through Azure Marketplace
Do you want to proceed (Y/N)?: y
```

This command removes a confluent organization by pipeline.

