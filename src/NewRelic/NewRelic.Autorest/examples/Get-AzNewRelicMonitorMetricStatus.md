### Example 1: Get a list of metrics resource ids
```powershell
Get-AzNewRelicMonitorMetricStatus -MonitorName test-03 -ResourceGroupName ps-test -UserEmail user1@outlook.com -AzureResourceId /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ps-test/providers/Microsoft.Web/sites/grouptest
```

```output
/subscriptions/11111111-2222-3333-4444-123456789101/resourcegroups/ps-test/providers/microsoft.web/sites/grouptest
```

List resource ids.