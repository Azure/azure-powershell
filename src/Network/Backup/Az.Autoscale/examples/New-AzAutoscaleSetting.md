### Example 1: Create autoscale setting for vmss
```powershell
$subscriptionId = (Get-AzContext).SubscriptionId
$rule1=New-AzAutoscaleScaleRuleObject -MetricTriggerMetricName "Percentage CPU" -MetricTriggerMetricResourceUri "/subscriptions/$subscriptionId/resourceGroups/test-group/providers/Microsoft.Compute/virtualMachineScaleSets/test-vmss" -MetricTriggerTimeGrain ([System.TimeSpan]::New(0,1,0)) -MetricTriggerStatistic "Average" -MetricTriggerTimeWindow ([System.TimeSpan]::New(0,5,0)) -MetricTriggerTimeAggregation "Average" -MetricTriggerOperator "GreaterThan" -MetricTriggerThreshold 10 -MetricTriggerDividePerInstance $false -ScaleActionDirection "Increase" -ScaleActionType "ChangeCount" -ScaleActionValue 1 -ScaleActionCooldown ([System.TimeSpan]::New(0,5,0))
$profile1=New-AzAutoscaleProfileObject -Name "adios" -CapacityDefault 1 -CapacityMaximum 10 -CapacityMinimum 1 -Rule $rule1 -FixedDateEnd ([System.DateTime]::Parse("2022-12-31T14:00:00Z")) -FixedDateStart ([System.DateTime]::Parse("2022-12-31T13:00:00Z")) -FixedDateTimeZone "UTC"
$webhook1=New-AzAutoscaleWebhookNotificationObject -Property @{} -ServiceUri "http://myservice.com"
$notification1=New-AzAutoscaleNotificationObject -EmailCustomEmail "gu@ms.com" -EmailSendToSubscriptionAdministrator $true -EmailSendToSubscriptionCoAdministrator $true -Webhook $webhook1
New-AzAutoscaleSetting -Name test-autoscalesetting -ResourceGroupName test-group -Location westeurope -Profile $profile1 -Enabled -Notification $notification1 -PredictiveAutoscalePolicyScaleLookAheadTime ([System.TimeSpan]::New(0,5,0)) -PredictiveAutoscalePolicyScaleMode 'Enabled' -PropertiesName "test-autoscalesetting" -TargetResourceUri "/subscriptions/$subscriptionId/resourceGroups/test-group/providers/Microsoft.Compute/virtualMachineScaleSets/test-vmss"
```

Create autoscale setting for vmss