### Example 1: Remove a confluent organization by name
```powershell
<<<<<<< HEAD
Remove-AzConfluentOrganization -ResourceGroupName azure-rg-test -Name confluentorg-01-portal
```

```output
=======
PS C:\> Remove-AzConfluentOrganization -ResourceGroupName azure-rg-test -Name confluentorg-01-portal
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
- This action cannot be undone.
- This will permanently delete ‘<resource_name>’ and its Azure subscription
- Stop billing for the selected Confluent organization through Azure Marketplace
Do you want to proceed (Y/N)?: y
```

This command removes a confluent organization by name

### Example 2: Remove a confluent organization by pipeline
```powershell
<<<<<<< HEAD
Get-AzConfluentOrganization -ResourceGroupName azure-rg-test -Name confluentorg-02-pwsh | Remove-AzConfluentOrganization
```

```output
=======
PS C:\>  Get-AzConfluentOrganization -ResourceGroupName azure-rg-test -Name confluentorg-02-pwsh | Remove-AzConfluentOrganization
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
- This action cannot be undone.
- This will permanently delete ‘<resource_name>’ and its Azure subscription
- Stop billing for the selected Confluent organization through Azure Marketplace
Do you want to proceed (Y/N)?: y
```

This command removes a confluent organization by pipeline.

