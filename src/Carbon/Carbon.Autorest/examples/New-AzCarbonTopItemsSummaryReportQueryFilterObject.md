### Example 1: Create new TopItemsSummaryReportQueryFilterObject object
```powershell
New-AzCarbonTopItemsSummaryReportQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3') -CategoryType 'Resource' -DateRangeEnd 2025-03-01 -DateRangeStart 2025-03-01 -TopItem 5 -SubscriptionList ('00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000001')
```

```output
CarbonScopeList      : {Scope1, Scope2, Scope3}
CategoryType         : Resource
DateRangeEnd         : 3/1/2025 12:00:00 AM
DateRangeStart       : 3/1/2025 12:00:00 AM
LocationList         :
ReportType           : TopItemsSummaryReport
ResourceGroupUrlList :
ResourceTypeList     :
SubscriptionList     : {00000000-0000-0000-0000-000000000000, 00000000-0000-0000-0000-000000000001}
TopItem              : 5
```

