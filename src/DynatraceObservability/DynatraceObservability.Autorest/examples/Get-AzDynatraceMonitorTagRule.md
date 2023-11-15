### Example 1: Get a tag rule of the dynatrace monitor
```powershell
Get-AzDynatraceMonitorTagRule -ResourceGroupName dyobrg -MonitorName dyob-pwsh01
```

```output
Name    ResourceGroupName ProvisioningState LogRuleSendAadLog
----    ----------------- ----------------- -----------------
default dyobrg            Succeeded         Disabled
```

This command gets a tag rule of the dynatrace monitor.

### Example 2: Get a tag rule of the dynatrace monitor by pipeline
```powershell
$tagFilter = New-AzDynatraceMonitorFilteringTagObject -Action 'Include' -Name 'Environment' -Value 'Prod'
New-AzDynatraceMonitorTagRule -ResourceGroupName dyobrg -MonitorName dyob-pwsh01 -LogRuleFilteringTag $tagFilter | Get-AzDynatraceMonitorTagRule
```

```output
Name    ResourceGroupName ProvisioningState LogRuleSendAadLog
----    ----------------- ----------------- -----------------
default dyobrg            Succeeded         Disabled
```

This command gets a tag rule of the dynatrace monitor by pipeline.