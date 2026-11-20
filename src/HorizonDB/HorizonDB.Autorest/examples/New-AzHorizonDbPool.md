### Example 1: Create a provisioned pool
```powershell
$body = @{
    properties = @{
        computeModel = @{
            type = 'Provisioned'
            computeProcessor = 'AMD'
            computeGeneration = 3
            vCores = 2
        }
        scheduledMaintenance = @{
            maintenanceManagementType = 'System'
        }
        nodeCount = 1
        highAvailability = @{
            mode = 'Disabled'
        }
    }
} | ConvertTo-Json -Depth 5

New-AzHorizonDbPool -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'example-pool-01' -JsonString $body | Format-List -Property Name, ComputeModelVCore, NodeCount, HighAvailabilityMode, State, ProvisioningState, ParameterGroupApplyMethod, ParameterGroupSyncStatus
```

```output
Name                      : example-pool-01
ComputeModelVCore         : 2
NodeCount                 : 1
HighAvailabilityMode      : Disabled
State                     : Ready
ProvisioningState         : Succeeded
ParameterGroupApplyMethod : Immediate
ParameterGroupSyncStatus  : InSync
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
