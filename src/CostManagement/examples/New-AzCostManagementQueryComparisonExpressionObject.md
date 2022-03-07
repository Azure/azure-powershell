### Example 1: Create a comparison expression object of query for cost management export
```powershell
New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceLocation' -Value @('East US', 'West Europe')
```

```output
Name             Operator Value
----             -------- -----
ResourceLocation In       {East US, West Europe}
```

This command creates a comparison expression object of query for cost management export.

