### Example 1: Create activity log alert
```powershell
$scope = "subscriptions/"+(Get-AzContext).Subscription.ID
$actiongroup=New-AzActionGroupObject -Id $ActionGroupResourceId -WebhookProperty @{"sampleWebhookProperty"="SamplePropertyValue"}
$condition1=New-AzAlertRuleAnyOfOrLeafConditionObject -Equal Administrative -Field category
$condition2=New-AzAlertRuleAnyOfOrLeafConditionObject -Equal Error -Field level
$any1=New-AzAlertRuleLeafConditionObject -Field properties.incidentType -Equal Maintenance
$any2=New-AzAlertRuleLeafConditionObject -Field properties.incidentType -Equal Incident
$condition3=New-AzAlertRuleAnyOfOrLeafConditionObject -AnyOf $any1,$any2
New-AzActivityLogAlert -Name $AlertName -ResourceGroupName $ResourceGroupName -Action $actiongroup -Condition @($condition1,$condition2,$condition3) -Location global -Scope $scope
```

Create activity log alert for subscription, when `$condition1` and `$condition2` and (`$any1` or `$any2`) fulfilled
