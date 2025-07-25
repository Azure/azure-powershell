### Example 1: Create or update a tag rule set for a given monitor resource
```powershell
New-AzElasticTagRule -ResourceGroupName azps-elastic-test -MonitorName elastic-pwsh02 -LogRuleSendActivityLog
```

```output
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         azps-elastic-test
```

This command creates or updates a tag rule set for a given monitor resource.


