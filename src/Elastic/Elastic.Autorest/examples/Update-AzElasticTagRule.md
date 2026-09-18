### Example 1: Update a tag rule set for a given monitor resource
```powershell
Update-AzElasticTagRule -ResourceGroupName azps-elastic-test -MonitorName elastic-pwsh02 -LogRuleSendActivityLog
```

```output
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         azps-elastic-test
```

This command updates a tag rule set for a given monitor resource.