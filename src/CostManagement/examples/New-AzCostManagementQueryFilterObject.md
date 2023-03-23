### Example 1: Create a filter object of query for cost management export
```powershell
$orDimension = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceLocation' -Value @('East US', 'West Europe')
$orTag = New-AzCostManagementQueryComparisonExpressionObject -Name 'Environment' -Value @('UAT', 'Prod')
New-AzCostManagementQueryFilterObject -or @((New-AzCostManagementQueryFilterObject -Dimensions $orDimension), (New-AzCostManagementQueryFilterObject -Tag $orTag))
```

```output
And       :
Dimension : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.QueryComparisonExpression
Not       : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.QueryFilter
Or        : {Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.QueryFilter, Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.QueryFilter}
Tag       : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.QueryComparisonExpression
```

this command creates a filter object of query for cost management export.

