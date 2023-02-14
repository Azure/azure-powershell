### Example 1: Get the default tag rule set for a given monitor resource
```powershell
<<<<<<< HEAD
Get-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04
```

```output
=======
PS C:\> Get-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command gets the default tag rule set for a given monitor resource.

### Example 2: Get the default tag rule set for a given monitor resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 | Get-AzLogzMonitorTagRule
```

```output
=======
PS C:\> Get-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 | Get-AzLogzMonitorTagRule

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command gets the default tag rule set for a given monitor resource by pipeline.

