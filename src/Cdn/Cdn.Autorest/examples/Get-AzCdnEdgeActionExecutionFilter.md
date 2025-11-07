### Example 1: List all Edge Action Execution Filters
```powershell
Get-AzCdnEdgeActionExecutionFilter -ResourceGroupName "testps-rg-da16jm" -EdgeActionName "edgeaction001"
```

```output
Name                              : filter001
Id                                : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/executionFilters/filter001
Type                              : Microsoft.Cdn/edgeActions/executionFilters
Location                          : global
ProvisioningState                 : Succeeded
ExecutionFilterIdentifierHeaderName  : X-Filter-Key
ExecutionFilterIdentifierHeaderValue : FilterValue1
LastUpdateTime                    : 10/27/2025 10:30:45 AM

Name                              : filter002
Id                                : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/executionFilters/filter002
Type                              : Microsoft.Cdn/edgeActions/executionFilters
Location                          : global
ProvisioningState                 : Succeeded
ExecutionFilterIdentifierHeaderName  : X-Filter-Key
ExecutionFilterIdentifierHeaderValue : FilterValue2
LastUpdateTime                    : 10/27/2025 10:35:20 AM
```

List all Execution Filters of the specified Edge Action

### Example 2: Get a specific Edge Action Execution Filter by name
```powershell
Get-AzCdnEdgeActionExecutionFilter -ResourceGroupName "testps-rg-da16jm" -EdgeActionName "edgeaction001" -ExecutionFilter "filter001"
```

```output
Name                              : filter001
Id                                : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/executionFilters/filter001
Type                              : Microsoft.Cdn/edgeActions/executionFilters
Location                          : global
ProvisioningState                 : Succeeded
ExecutionFilterIdentifierHeaderName  : X-Filter-Key
ExecutionFilterIdentifierHeaderValue : FilterValue1
LastUpdateTime                    : 10/27/2025 10:30:45 AM
```

Get a specific Edge Action Execution Filter by name

