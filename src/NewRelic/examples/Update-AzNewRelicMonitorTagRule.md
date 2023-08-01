### Example 1: Update specific TagRule with specified monitor resource
```powershell
Update-AzNewRelicMonitorTagRule -MonitorName test-03 -ResourceGroupName ps-test -RuleSetName default -LogRuleSendActivityLog 'Enabled'
```

```output
Name    SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName RetryAfter
----    -------------------  -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----------------- ----------
default 6/28/2023 9:29:45 AM v-jiaji@microsoft.com User                    6/29/2023 8:12:51 AM     v-jiaji@microsoft.com    User                         ps-test
```

Update specific TagRule with specified monitor resource