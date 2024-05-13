### Example 1: List linked Azure resources
```powershell
Get-AzNewRelicMonitorLinkedResource -MonitorName test-01 -ResourceGroupName group-test
```

```output
Id
--
/SUBSCRIPTIONS/11111111-2222-3333-4444-123456789101/RESOURCEGROUPS/group-TEST/PROVIDERS/NEWRELIC.OBSERVABILITY/MONITORS/TEST-01
```

This command lists all Azure resources associated to the same NewRelic organization and account as the target resource.

