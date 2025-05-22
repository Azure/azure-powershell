### Example 1: Update a tag rule for the dynatrace monitor
```powershell
$tagFilter = New-AzDynatraceMonitorFilteringTagObject -Action 'Include' -Name 'Environment' -Value 'Prod'
Update-AzDynatraceMonitorTagRule -ResourceGroupName dyobrg -MonitorName dyob-pwsh01 -LogRuleFilteringTag $tagFilter
```

```output
Name    ResourceGroupName ProvisioningState LogRuleSendAadLog
----    ----------------- ----------------- -----------------
default dyobrg            Succeeded         Disabled
```

This command update a tag rule for the dynatrace monitor.