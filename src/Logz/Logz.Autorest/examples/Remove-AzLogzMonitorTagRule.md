### Example 1: Delete a tag rule set for a given monitor resource
```powershell
PS C:\> Remove-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04

```

This command deletes a tag rule set for a given monitor resource.

### Example 2: Delete a tag rule set for a given monitor resource by pipeline
```powershell
PS C:\> Get-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 | Remove-AzLogzMonitorTagRule

```

This command deletes a tag rule set for a given monitor resource by pipeline.
