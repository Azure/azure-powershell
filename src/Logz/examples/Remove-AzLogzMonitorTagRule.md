### Example 1: Delete a tag rule set for a given monitor resource
```powershell
<<<<<<< HEAD
Remove-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04
=======
PS C:\> Remove-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a tag rule set for a given monitor resource.

### Example 2: Delete a tag rule set for a given monitor resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 | Remove-AzLogzMonitorTagRule
=======
PS C:\> Get-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 | Remove-AzLogzMonitorTagRule

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a tag rule set for a given monitor resource by pipeline.
