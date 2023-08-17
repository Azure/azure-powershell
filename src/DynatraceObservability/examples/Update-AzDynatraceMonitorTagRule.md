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

This command updates a tag rule for the dynatrace monitor.

### Example 2: Update a tag rule for the dynatrace monitor by pipeline
```powershell
$tagFilter = New-AzDynatraceMonitorFilteringTagObject -Action 'Include' -Name 'Environment' -Value 'Prod'
Get-AzDynatraceMonitorTagRule -ResourceGroupName dyobrg -MonitorName dyob-pwsh01 | Update-AzDynatraceMonitorTagRule -LogRuleFilteringTag $tagFilter
```

```output
Name    ResourceGroupName ProvisioningState LogRuleSendAadLog
----    ----------------- ----------------- -----------------
default dyobrg            Succeeded         Disabled
```

This command updates a tag rule for the dynatrace monitor by pipeline.