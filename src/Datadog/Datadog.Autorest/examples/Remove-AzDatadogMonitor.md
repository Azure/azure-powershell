### Example 1: Delete a monitor resource
```powershell
PS C:\> Remove-AzDatadogMonitor -ResourceGroupName azure-rg-test -Name Datadog-portal03

```

This command deletes a monitor resource.

### Example 2: Delete a monitor resource by pipeline
```powershell
PS C:\> Get-AzDatadogMonitor -ResourceGroupName azure-rg-test -Name Datadog-portal02 | Remove-AzDatadogMonitor

```

This command deletes a monitor resource by pipeline.

