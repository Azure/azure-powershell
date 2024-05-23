### Example 1: Create a in-memory object for FilteringTag pass into parameter LogRuleFilteringTag when creating a tage rule for the monitor resource
```powershell
$filter = New-AzLogzFilteringTagObject -Action 'Include' -Name 'Env' -Value "Prod"
New-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -LogRuleFilteringTag $filter
```

```output
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command creates a in-memory object for FilteringTag pass into parameter LogRuleFilteringTag when creating a tage rule for the monitor resource.

