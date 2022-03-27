### Example 1: Create or update a tag rule set for a given monitor resource
```powershell
New-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04
```

```output
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command creates or update a tag rule set for a given monitor resource.
