### Example 1: List execution filters for an EdgeAction
```powershell
Get-AzCdnEdgeActionExecutionFilter -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001
```

Lists execution filters under the specified EdgeAction resource.

### Example 2: Get an execution filter
```powershell
Get-AzCdnEdgeActionExecutionFilter -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -ExecutionFilter filter001
```

Gets the specified EdgeAction execution filter.
