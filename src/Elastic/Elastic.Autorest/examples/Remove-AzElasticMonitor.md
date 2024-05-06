### Example 1: Delete a monitor resource
```powershell
Remove-AzElasticMonitor -ResourceGroupName azure-elastic-test -Name elastic-pwsh02
```

This command delete a monitor resource.

### Example 2: Delete a monitor resource by pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName azure-elastic-test -Name elastic-pwsh03 | Remove-AzElasticMonitor
```

This command delete a monitor resource by pipeline.

