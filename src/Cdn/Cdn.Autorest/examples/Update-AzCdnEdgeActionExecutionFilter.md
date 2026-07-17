### Example 1: Update an EdgeAction execution filter
```powershell
Update-AzCdnEdgeActionExecutionFilter -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -ExecutionFilter filter001 -ExecutionFilterIdentifierHeaderName "X-Updated-Filter" -ExecutionFilterIdentifierHeaderValue "UpdatedValue"
```

Updates the specified EdgeAction execution filter.
