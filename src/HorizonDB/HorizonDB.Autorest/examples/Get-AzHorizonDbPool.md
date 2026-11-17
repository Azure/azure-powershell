### Example 1: List cluster pools
```powershell
Get-AzHorizonDbPool -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' | Format-List -Property Name, ComputeModelVCore, NodeCount, HighAvailabilityMode, State, ProvisioningState, ParameterGroupApplyMethod, ParameterGroupSyncStatus
```

```output
Name                      : example-pool-01
ComputeModelVCore         : 8
NodeCount                 : 3
HighAvailabilityMode      : AnyZone
State                     : Ready
ProvisioningState         : Succeeded
ParameterGroupApplyMethod : Immediate
ParameterGroupSyncStatus  : InSync
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get a pool
```powershell
Get-AzHorizonDbPool -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'example-pool-01' | Format-List -Property Name, ComputeModelVCore, NodeCount, HighAvailabilityMode, State, ProvisioningState, ParameterGroupApplyMethod, ParameterGroupSyncStatus
```

```output
Name                      : example-pool-01
ComputeModelVCore         : 8
NodeCount                 : 3
HighAvailabilityMode      : AnyZone
State                     : Ready
ProvisioningState         : Succeeded
ParameterGroupApplyMethod : Immediate
ParameterGroupSyncStatus  : InSync
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
