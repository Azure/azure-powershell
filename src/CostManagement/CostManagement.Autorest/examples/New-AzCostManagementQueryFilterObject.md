### Example 1: Create a filter object of query for cost management export
```powershell
$orDimension = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceLocation' -Value @('East US', 'West Europe')
$orTag = New-AzCostManagementQueryComparisonExpressionObject -Name 'Environment' -Value @('UAT', 'Prod')
New-AzCostManagementQueryFilterObject -or @((New-AzCostManagementQueryFilterObject -Dimensions $orDimension), (New-AzCostManagementQueryFilterObject -Tag $orTag))
```

```output
And       :
Dimension : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.QueryComparisonExpression
Not       : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.QueryFilter
Or        : {Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.QueryFilter, Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.QueryFilter}
Tag       : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.QueryComparisonExpression
```

this command creates a filter object of query for cost management export.

