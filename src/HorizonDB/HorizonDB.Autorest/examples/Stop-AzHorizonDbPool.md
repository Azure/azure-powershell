### Example 1: Stop a pool
```powershell
Stop-AzHorizonDbPool -ResourceGroupName 'exampleresourcegroup' -ClusterName 'examplecluster' -Name 'example-pool-01' | Format-List -Property Name, ComputeModelVCore, NodeCount, HighAvailabilityMode, State, ProvisioningState, ParameterGroupApplyMethod, ParameterGroupSyncStatus
```

```output
Name                      : example-pool-01
ComputeModelVCore         : 2
NodeCount                 : 1
HighAvailabilityMode      : Disabled
State                     : Stopped
ProvisioningState         : Succeeded
ParameterGroupApplyMethod : PendingReboot
ParameterGroupSyncStatus  : PendingReboot
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
