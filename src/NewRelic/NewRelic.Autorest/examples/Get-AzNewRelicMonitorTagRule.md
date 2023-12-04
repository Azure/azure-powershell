### Example 1: Get tag rule with specified monitor and resource group
```powershell
Get-AzNewRelicMonitorTagRule -MonitorName test-03 -ResourceGroupName ps-test
```

```output
Name    SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName RetryAfter
----    -------------------  -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----------------- ----------
default 6/28/2023 6:03:14 AM v-jiaji@outlook.com User                    6/28/2023 6:03:14 AM     v-jiaji@outlook.com    User                         ps-test
```

Get tag rule with specified monitor and resource group