### Example 1: Delete a sub account resource
```powershell
PS C:\> Remove-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName logz-portal01 -Name logz01-subaccount01

```

This command deletes a sub account resource.

### Example 2: Delete a sub account resource by pipeline
```powershell
PS C:\> Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName logz-portal01 -Name logz01-subaccount02 | Remove-AzLogzSubAccount

```

This command deletes a sub account resource by pipeline.

