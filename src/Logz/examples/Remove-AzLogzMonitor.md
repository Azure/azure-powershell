### Example 1: Delete a monitor resource
```powershell
Remove-AzLogzMonitor -ResourceGroupName logz-rg-test -Name logz-portal01
```

This command deletes a monitor resource

### Example 2: Delete a monitor resource by pipeline
```powershell
Get-AzLogzMonitor -ResourceGroupName logz-rg-test -Name logz-portal01 | Remove-AzLogzMonitor
```

This command deletes a monitor resource by pipeline

