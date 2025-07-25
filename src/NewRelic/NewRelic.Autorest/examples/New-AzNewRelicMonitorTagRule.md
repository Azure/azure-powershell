### Example 1: Create tag rule
```powershell
New-AzNewRelicMonitorTagRule -MonitorName test-01 -ResourceGroupName ps-test -RuleSetName default -LogRuleSendAadLog 'Disabled' -LogRuleSendActivityLog 'Enabled' -LogRuleSendSubscriptionLog 'Disabled' -MetricRuleSendMetric 'Enabled' -MetricRuleUserEmail user1@outlook.com
```

```output
Name    SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName RetryAfter
----    -------------------  -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----------------- ----------
default 6/28/2023 6:03:14 AM user1@outlook.com User                    6/28/2023 6:03:14 AM     user1@outlook.com    User                         ps-test
```

Create monitor tag rule with specified monitor and default name

