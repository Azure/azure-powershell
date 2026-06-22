### Example 1: Create an EdgeAction execution filter
```powershell
New-AzCdnEdgeActionExecutionFilter -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -ExecutionFilter filter001 -Location global -ExecutionFilterIdentifierHeaderName "X-Filter-Key" -ExecutionFilterIdentifierHeaderValue "FilterValue1"
```

Creates an execution filter for the specified EdgeAction.
