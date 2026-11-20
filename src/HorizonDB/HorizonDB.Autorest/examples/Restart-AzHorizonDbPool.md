### Example 1: Restart a pool
```powershell
Restart-AzHorizonDbPool -ResourceGroupName 'exampleresourcegroup' -ClusterName 'examplecluster' -Name 'example-pool-01' | Format-List -Property Name, ComputeModelVCore, NodeCount, HighAvailabilityMode, State, ProvisioningState, ParameterGroupApplyMethod, ParameterGroupSyncStatus
```

```output
Name                      : example-pool-01
ComputeModelVCore         : 2
NodeCount                 : 3
HighAvailabilityMode      : AnyZone
State                     : Ready
ProvisioningState         : Succeeded
ParameterGroupApplyMethod : PendingReboot
ParameterGroupSyncStatus  : InSync
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
