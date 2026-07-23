### Example 1: Create new ItemDetailsQueryFilterObject object
```powershell
New-AzCarbonItemDetailsQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3') -CategoryType 'Resource' -DateRangeEnd 2025-03-01 -DateRangeStart 2025-03-01 -OrderBy 'ItemName' -PageSize 100 -SortDirection 'Desc' -SubscriptionList ('00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000001')
```

```output
CarbonScopeList      : {Scope1, Scope2, Scope3}
CategoryType         : Resource
DateRangeEnd         : 3/1/2025 12:00:00 AM
DateRangeStart       : 3/1/2025 12:00:00 AM
LocationList         :
OrderBy              : ItemName
PageSize             : 100
ReportType           : ItemDetailsReport
ResourceGroupUrlList :
ResourceTypeList     :
SkipToken            :
SortDirection        : Desc
SubscriptionList     : {00000000-0000-0000-0000-000000000000, 00000000-0000-0000-0000-000000000001}
```

