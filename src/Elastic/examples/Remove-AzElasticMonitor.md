### Example 1: Delete a monitor resource
```powershell
Remove-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor01
```

Delete a monitor resource.

### Example 2: Delete a monitor resource via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor02 | Remove-AzElasticMonitor
```

Delete a monitor resource via pipeline.
