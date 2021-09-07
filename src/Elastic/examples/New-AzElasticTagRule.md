### Example 1: Create or update a tag rule set for a given monitor resource
```powershell
PS C:\> New-AzElasticTagRule -ResourceGroupName azps-elastic-test -MonitorName elastic-pwsh02 -LogRuleSendActivityLog

Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         azps-elastic-test
```

This command creates or updates a tag rule set for a given monitor resource.


