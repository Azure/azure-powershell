### Example 1: Scale a pool and use system-managed maintenance
```powershell
Update-AzHorizonDbPool -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'example-pool-01' -ComputeModelVCore 16 -ScheduledMaintenanceManagementType 'System' | Format-List -Property Name, ComputeModelVCore, NodeCount, HighAvailabilityMode, State, ProvisioningState, ParameterGroupApplyMethod, ParameterGroupSyncStatus
```

```output
Name                      : example-pool-01
ComputeModelVCore         : 16
NodeCount                 : 3
HighAvailabilityMode      : AnyZone
State                     : Ready
ProvisioningState         : Succeeded
ParameterGroupApplyMethod : Immediate
ParameterGroupSyncStatus  : InSync
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Enable zone-redundant high availability
```powershell
Update-AzHorizonDbPool -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'example-pool-01' -HighAvailabilityMode 'ZoneRedundant' | Format-List -Property Name, ComputeModelVCore, NodeCount, HighAvailabilityMode, State, ProvisioningState, ParameterGroupApplyMethod, ParameterGroupSyncStatus
```

```output
Name                      : example-pool-01
ComputeModelVCore         : 8
NodeCount                 : 3
HighAvailabilityMode      : ZoneRedundant
State                     : Ready
ProvisioningState         : Succeeded
ParameterGroupApplyMethod : Immediate
ParameterGroupSyncStatus  : InSync
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 3: Apply a custom parameter group immediately
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$parameterGroupId = "/subscriptions/$subscriptionId/resourceGroups/example-resource-group/providers/Microsoft.HorizonDb/parameterGroups/production-parameters"

Update-AzHorizonDbPool -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'example-pool-01' -ParameterGroupResourceId $parameterGroupId -ParameterGroupApplyMethod 'Immediate' | Format-List -Property Name, ComputeModelVCore, NodeCount, HighAvailabilityMode, State, ProvisioningState, ParameterGroupApplyMethod, ParameterGroupSyncStatus, ParameterGroupResourceId
```

```output
Name                      : example-pool-01
ComputeModelVCore         : 8
NodeCount                 : 3
HighAvailabilityMode      : AnyZone
State                     : Ready
ProvisioningState         : Succeeded
ParameterGroupApplyMethod : Immediate
ParameterGroupSyncStatus  : Applying
ParameterGroupResourceId  : /subscriptions/ffffffff-ffff-ffff-ffff-ffffffffffff/resourceGroups/example-resource-group/providers/Microsoft.HorizonDb/parameterGroups/production-parameters
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 4: Apply a custom parameter group on the next reboot
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$parameterGroupId = "/subscriptions/$subscriptionId/resourceGroups/example-resource-group/providers/Microsoft.HorizonDb/parameterGroups/maintenance-window-parameters"

Update-AzHorizonDbPool -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'example-pool-01' -ParameterGroupResourceId $parameterGroupId -ParameterGroupApplyMethod 'PendingReboot' | Format-List -Property Name, ComputeModelVCore, NodeCount, HighAvailabilityMode, State, ProvisioningState, ParameterGroupApplyMethod, ParameterGroupSyncStatus, ParameterGroupResourceId
```

```output
Name                      : example-pool-01
ComputeModelVCore         : 8
NodeCount                 : 3
HighAvailabilityMode      : AnyZone
State                     : Ready
ProvisioningState         : Succeeded
ParameterGroupApplyMethod : PendingReboot
ParameterGroupSyncStatus  : PendingReboot
ParameterGroupResourceId  : /subscriptions/ffffffff-ffff-ffff-ffff-ffffffffffff/resourceGroups/example-resource-group/providers/Microsoft.HorizonDb/parameterGroups/maintenance-window-parameters
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 5: Restore the default parameter group
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$parameterGroupId = "/subscriptions/$subscriptionId/providers/Microsoft.HorizonDb/locations/eastus2/parameterGroups/default-postgresql-17-provisioned"

Update-AzHorizonDbPool -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'example-pool-01' -ParameterGroupResourceId $parameterGroupId -ParameterGroupApplyMethod 'Immediate' | Format-List -Property Name, ComputeModelVCore, NodeCount, HighAvailabilityMode, State, ProvisioningState, ParameterGroupApplyMethod, ParameterGroupSyncStatus, ParameterGroupResourceId
```

```output
Name                      : example-pool-01
ComputeModelVCore         : 8
NodeCount                 : 3
HighAvailabilityMode      : AnyZone
State                     : Ready
ProvisioningState         : Succeeded
ParameterGroupApplyMethod : Immediate
ParameterGroupSyncStatus  : Applying
ParameterGroupResourceId  : /subscriptions/ffffffff-ffff-ffff-ffff-ffffffffffff/providers/Microsoft.HorizonDb/locations/eastus2/parameterGroups/default-postgresql-17-provisioned
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
