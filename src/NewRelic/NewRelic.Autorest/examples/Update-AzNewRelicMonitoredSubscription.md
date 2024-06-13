### Example 1: Update the subscriptions that are being monitored by the NewRelic monitor resource
```powershell
$includeFT = New-AzNewRelicFilteringTagObject -Action Include -Name testLogRule1 -Value filteringTag1
$sub1 = New-AzNewRelicMonitoredSubscriptionObject -LogRuleFilteringTag $includeFT -LogRuleSendAadLog Enabled -LogRuleSendActivityLog Enabled -LogRuleSendSubscriptionLog Enabled -MetricRuleFilteringTag $includeFT -MetricRuleUserEmail user1@outlook.com -Status Active -SubscriptionId 11111111-2222-3333-4444-12345678910122
Update-AzNewRelicMonitoredSubscription -MonitorName test-01 -ResourceGroupName group-test -PatchOperation AddComplete -MonitoredSubscriptionList $sub1
```

```output
Id                        : /subscriptions/11111111-2222-3333-4444-123456789123/resourceGroups/group_test/providers/NewRelic.Observability/monitors/test-01/monitoredSubscriptions/default
MonitoredSubscriptionList : {{
                              "tagRules": {
                                "provisioningState": "Accepted"
                              },
                              "subscriptionId": "00000000-0000-0000-0000-000000000000",
                              "status": "Active"
                            }, {
                              "tagRules": {
                                "provisioningState": "Accepted"
                              },
                              "subscriptionId": "11111111-2222-3333-4444-123456789101",
                              "status": "Active"
                            }}
Name                      : default
PatchOperation            : 
ProvisioningState         : 
ResourceGroupName         : group_test
Type                      : NewRelic.Observability/monitors/monitoredSubscriptions
```

This command updates the subscriptions that are being monitored by the NewRelic monitor resource.

