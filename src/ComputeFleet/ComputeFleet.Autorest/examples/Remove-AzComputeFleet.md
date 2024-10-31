### Example 1: Remove a computefleet organization by name
```powershell
Remove-AzComputeFleetOrganization -ResourceGroupName azure-rg-test -Name computefleetorg-01-portal
```

```output
- This action cannot be undone.
- This will permanently delete ‘<resource_name>’ and its Azure subscription
- Stop billing for the selected ComputeFleet organization through Azure Marketplace
Do you want to proceed (Y/N)?: y
```

This command removes a computefleet organization by name

### Example 2: Remove a computefleet organization by pipeline
```powershell
Get-AzComputeFleetOrganization -ResourceGroupName azure-rg-test -Name computefleetorg-02-pwsh | Remove-AzComputeFleetOrganization
```

```output
- This action cannot be undone.
- This will permanently delete ‘<resource_name>’ and its Azure subscription
- Stop billing for the selected ComputeFleet organization through Azure Marketplace
Do you want to proceed (Y/N)?: y
```

This command removes a computefleet organization by pipeline.

