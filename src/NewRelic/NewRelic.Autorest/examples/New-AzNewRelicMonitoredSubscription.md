### Example 1: Add subscriptions
```powershell
$includeFT = New-AzNewRelicFilteringTagObject -Action Include -Name testLogRule1 -Value filteringTag1
$sub1 = New-AzNewRelicMonitoredSubscriptionObject -LogRuleFilteringTag $includeFT -LogRuleSendAadLog Enabled -LogRuleSendActivityLog Enabled -LogRuleSendSubscriptionLog Enabled -MetricRuleFilteringTag $includeFT -MetricRuleUserEmail user1@outlook.com -Status Active -SubscriptionId 00000000-0000-0000-0000-000000000000
New-AzNewRelicMonitoredSubscription -MonitorName test-01 -ResourceGroupName group-test -MonitoredSubscriptionList $sub1 -PatchOperation AddBegin
```

Select subscriptions to monitor their resources using NewRelic. Only subscriptions where you have owner access are allowed.

