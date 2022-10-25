### Example 1: Invoke AzCostManagementQuery by Scope
```powershell
Invoke-AzCostManagementQuery -Scope "/subscriptions/***********" -Timeframe MonthToDate -Type Usage -DatasetGranularity 'Daily'
```

```output
Column                Row
------                ---
{UsageDate, Currency} {20201101 USD, 20201102 USD, 20201103 USD, 20201104 USD…}
```

Invoke AzCostManagementQuery by Scope

### Example 2: Invoke AzCostManagementQuery by Scope with Dimensions
```powershell
$dimensions = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceGroup' -Value 'API'
$filter = New-AzCostManagementQueryFilterObject -Dimensions $dimensions
Invoke-AzCostManagementQuery -Type Usage -Scope "subscriptions/***********" -DatasetGranularity 'Monthly' -DatasetFilter $filter -Timeframe MonthToDate -Debug
```

```output
Column                   Row
------                   ---
{BillingMonth, Currency} {}
```

Invoke AzCostManagementQuery by Scope with Dimensions