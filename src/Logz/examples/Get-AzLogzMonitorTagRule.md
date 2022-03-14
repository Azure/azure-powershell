### Example 1: Get the default tag rule set for a given monitor resource
```powershell
Get-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04
```

```output
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command gets the default tag rule set for a given monitor resource.

### Example 2: Get the default tag rule set for a given monitor resource by pipeline
```powershell
Get-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 | Get-AzLogzMonitorTagRule
```

```output
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command gets the default tag rule set for a given monitor resource by pipeline.

