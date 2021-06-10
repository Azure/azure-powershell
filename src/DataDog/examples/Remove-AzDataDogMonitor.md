### Example 1: Delete a monitor resource
```powershell
PS C:\> Remove-AzDataDogMonitor -ResourceGroupName azure-rg-test -Name datadog-portal03

```

This command deletes a monitor resource.

### Example 2: Delete a monitor resource by pipeline
```powershell
PS C:\> Get-AzDataDogMonitor -ResourceGroupName azure-rg-test -Name datadog-portal02 | Remove-AzDataDogMonitor

```

This command deletes a monitor resource by pipeline.

