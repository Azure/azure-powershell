### Example 1: Create new OverallSummaryReportQueryFilterObject object
```powershell
New-AzCarbonOverallSummaryReportQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3') -DateRangeEnd 2025-03-01 -DateRangeStart 2024-03-01 -SubscriptionList ('00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000001')
```

```output
CarbonScopeList      : {Scope1, Scope2, Scope3}
DateRangeEnd         : 3/1/2025 12:00:00 AM
DateRangeStart       : 3/1/2024 12:00:00 AM
LocationList         :
ReportType           : OverallSummaryReport
ResourceGroupUrlList :
ResourceTypeList     :
SubscriptionList     : {00000000-0000-0000-0000-000000000000, 00000000-0000-0000-0000-000000000001}
```

