### Example 1: Get a list of metrics resource ids
```powershell
Get-AzNewRelicMonitorMetricStatus -MonitorName test-03 -ResourceGroupName ps-test -UserEmail v-jiaji@outlook.com -AzureResourceId /subscriptions/272c26cb-7026-4b37-b190-7cb7b2abecb0/resourceGroups/ps-test/providers/Microsoft.Web/sites/joyertest
```

```output
/subscriptions/272c26cb-7026-4b37-b190-7cb7b2abecb0/resourcegroups/ps-test/providers/microsoft.web/sites/joyertest
```

List resource ids.