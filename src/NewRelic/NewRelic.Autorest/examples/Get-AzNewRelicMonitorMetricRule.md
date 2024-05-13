### Example 1: Get specific monitor metric rule with specified resource group
```powershell
Get-AzNewRelicMonitorMetricRule -MonitorName test-01 -ResourceGroupName ps-test -UserEmail user1@outlook.com
```

```output
SendMetric UserEmail
---------- ---------
Disabled
```

Get specific monitor metric rule with specified resource group

