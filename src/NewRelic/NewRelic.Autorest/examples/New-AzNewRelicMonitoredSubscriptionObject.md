### Example 1: Create subscription object
```powershell
$includeFT = New-AzNewRelicFilteringTagObject -Action Include -Name testLogRule1 -Value filteringTag1
New-AzNewRelicMonitoredSubscriptionObject -LogRuleFilteringTag $includeFT -LogRuleSendAadLog Enabled -LogRuleSendActivityLog Enabled -LogRuleSendSubscriptionLog Enabled -MetricRuleFilteringTag $includeFT -MetricRuleUserEmail test@testing.com -Status Active -SubscriptionId 00000000-0000-0000-0000-000000000000
```

```output
Error                      : 
LogRuleFilteringTag        : {{
                               "name": "testLogRule1",
                               "value": "filteringTag1",
                               "action": "Include"
                             }}
LogRuleSendAadLog          : Enabled
LogRuleSendActivityLog     : Enabled
LogRuleSendSubscriptionLog : Enabled
MetricRuleFilteringTag     : {{
                               "name": "testLogRule1",
                               "value": "filteringTag1",
                               "action": "Include"
                             }}
MetricRuleSendMetric       : 
MetricRuleUserEmail        : test@testing.com
Status                     : Active
SubscriptionId             : 00000000-0000-0000-0000-000000000000
TagRuleProvisioningState   : 
```

This command creates a subscription object.

