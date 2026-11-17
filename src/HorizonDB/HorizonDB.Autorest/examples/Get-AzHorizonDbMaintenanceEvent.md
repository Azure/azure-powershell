### Example 1: List pool maintenance events
```powershell
Get-AzHorizonDbMaintenanceEvent -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PoolName 'example-pool-01' | Format-List -Property Name, MaintenanceType, Status, StartTimeUtc, EndTimeUtc
```

```output
Name            : ABCD-123
MaintenanceType : PlannedMaintenance
Status          : Planned
StartTimeUtc    : 08/12/2026 07:00:00
EndTimeUtc      : 08/12/2026 08:00:00

Name            : EFGH-456
MaintenanceType : PlannedMaintenance
Status          : Planned
StartTimeUtc    : 08/19/2026 07:00:00
EndTimeUtc      : 08/19/2026 08:00:00
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get a maintenance event
```powershell
Get-AzHorizonDbMaintenanceEvent -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PoolName 'example-pool-01' -Id 'ABCD-123' | Format-List -Property Name, MaintenanceType, Status, StartTimeUtc, EndTimeUtc
```

```output
Name            : ABCD-123
MaintenanceType : PlannedMaintenance
Status          : Planned
StartTimeUtc    : 08/12/2026 07:00:00
EndTimeUtc      : 08/12/2026 08:00:00
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 3: Filter maintenance events by status
```powershell
Get-AzHorizonDbMaintenanceEvent -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PoolName 'example-pool-01' -Filter "properties/status eq 'Planned' or properties/status eq 'InProgress'" | Format-List -Property Name, MaintenanceType, Status, StartTimeUtc, EndTimeUtc
```

```output
Name            : ABCD-123
MaintenanceType : PlannedMaintenance
Status          : Planned
StartTimeUtc    : 08/12/2026 07:00:00
EndTimeUtc      : 08/12/2026 08:00:00
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
