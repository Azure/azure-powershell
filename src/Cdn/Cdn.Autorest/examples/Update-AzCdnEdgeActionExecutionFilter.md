### Example 1: Update Edge Action Execution Filter with expanded parameters
```powershell
Update-AzCdnEdgeActionExecutionFilter -ResourceGroupName "testps-rg-da16jm" -EdgeActionName "edgeaction001" -ExecutionFilter "filter001" -ExecutionFilterIdentifierHeaderName "X-Updated-Filter" -ExecutionFilterIdentifierHeaderValue "UpdatedValue"
```

```output
Name                                  : filter001
Id                                    : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/executionFilters/filter001
Type                                  : Microsoft.Cdn/edgeActions/executionFilters
Location                              : global
ResourceGroupName                     : testps-rg-da16jm
ProvisioningState                     : Succeeded
ExecutionFilterIdentifierHeaderName  : X-Updated-Filter
ExecutionFilterIdentifierHeaderValue : UpdatedValue
LastUpdateTime                        : 10/27/2025 12:30:00 PM
```

Update an Edge Action Execution Filter with new header configuration

