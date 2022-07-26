### Example 1: Create activity log alert
```powershell
$SubscriptionId = (Get-AzContext).Subscription.ID
$actiongroup=New-AzActionGroupObject -Id $ActionGroupResourceId -WebhookProperty @{"sampleWebhookProperty"="SamplePropertyValue"}
$condition1=New-AzAlertRuleAnyOfOrLeafConditionObject -Equal Administrative -Field category
$condition2=New-AzAlertRuleAnyOfOrLeafConditionObject -Equal Error -Field level
$any=New-AzAlertRuleLeafConditionObject -Field properties.incidentType -Equal Maintenance
$condition3=New-AzAlertRuleAnyOfOrLeafConditionObject -AnyOf $any
New-AzActivityLogAlert -Name $AlertName -ResourceGroupName $ResourceGroupName -Action $actiongroup -Condition @($condition1,$condition2,$condition3) -Location global -Scope "subscriptions/"$SubscriptionId
```

Create activity log alert for subscription