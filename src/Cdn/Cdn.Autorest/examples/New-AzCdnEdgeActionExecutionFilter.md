### Example 1: Create a new Edge Action Execution Filter
```powershell
New-AzCdnEdgeActionExecutionFilter -ResourceGroupName "testps-rg-da16jm" -EdgeActionName "edgeaction001" -ExecutionFilter "filter001" -Location "global" -ExecutionFilterIdentifierHeaderName "X-Filter-Key" -ExecutionFilterIdentifierHeaderValue "FilterValue1"
```

```output
Name                                  : filter001
Id                                    : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/executionFilters/filter001
Type                                  : Microsoft.Cdn/edgeActions/executionFilters
Location                              : global
ResourceGroupName                     : testps-rg-da16jm
ProvisioningState                     : Succeeded
ExecutionFilterIdentifierHeaderName  : X-Filter-Key
ExecutionFilterIdentifierHeaderValue : FilterValue1
LastUpdateTime                        : 10/27/2025 12:00:00 PM
```

Create a new Edge Action Execution Filter