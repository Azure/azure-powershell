### Example 1: Update the subscriptions that are being monitored by the NewRelic monitor resource
```powershell
$includeFT = New-AzNewRelicFilteringTagObject -Action Include -Name testLogRule1 -Value filteringTag1
$sub1 = New-AzNewRelicMonitoredSubscriptionObject -LogRuleFilteringTag $includeFT -LogRuleSendAadLog Enabled -LogRuleSendActivityLog Enabled -LogRuleSendSubscriptionLog Enabled -MetricRuleFilteringTag $includeFT -MetricRuleUserEmail user1@outlook.com -Status Active -SubscriptionId 11111111-2222-3333-4444-123456789101
Update-AzNewRelicMonitoredSubscription -MonitorName test-01 -ResourceGroupName group-test -PatchOperation AddComplete -MonitoredSubscriptionList $sub1
```

This command updates the subscriptions that are being monitored by the NewRelic monitor resource.

