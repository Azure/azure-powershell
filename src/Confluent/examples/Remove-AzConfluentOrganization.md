### Example 1: Remove a confluent organization by name
```powershell
PS C:\> Remove-AzConfluentOrganization -ResourceGroupName azure-rg-test -Name confluentorg-01-portal

```

This command removes a confluent organization by name

### Example 2: Remove a confluent organization by pipeline
```powershell
PS C:\>  Get-AzConfluentOrganization -ResourceGroupName azure-rg-test -Name confluentorg-02-pwsh | Remove-AzConfluentOrganization

```

This command removes a confluent organization by pipeline.

