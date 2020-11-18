$Aggregation1 = @{ name = 'Cost' }
$AggregationDict = @{total=$aggregation1;}
$group = @{name='ResourceGroup'; type='Dimension'}
Invoke-AzCostManagementQuery -Type Usage -Scope "subscriptions/6b085460-5f21-477e-ba44-1035046e9101" -DatasetGranularity 'Daily' -Debug -TimePeriodFrom "2020-08-03T20:00:00Z" -TimePeriodTo "2020-11-10T00:00:00Z" -Timeframe Custom -DatasetAggregation $AggregationDict -DatasetGrouping @($group)