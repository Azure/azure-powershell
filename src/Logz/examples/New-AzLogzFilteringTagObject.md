### Example 1: Create a in-memory object for FilteringTag pass into parameter LogRuleFilteringTag when creating a tage rule for the monitor resource
```powershell
<<<<<<< HEAD
$filter = New-AzLogzFilteringTagObject -Action 'Include' -Name 'Env' -Value "Prod"
New-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -LogRuleFilteringTag $filter
```

```output
=======
PS C:\> $filter = New-AzLogzFilteringTagObject -Action 'Include' -Name 'Env' -Value "Prod"
PS C:\> New-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -LogRuleFilteringTag $filter

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command creates a in-memory object for FilteringTag pass into parameter LogRuleFilteringTag when creating a tage rule for the monitor resource.

