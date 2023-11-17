### Example 1: List all maintenance configurations for a managed cluster
```powershell
Get-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster
```

```output
Name
----
aks_maintenance_config1
aks_maintenance_config2
```

List all maintenance configurations for a managed cluster "myCluster".

### Example 2: Get a maintenance configuration with its config name
```powershell
Get-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster -ConfigName 'aks_maintenance_config'
```

```output
Name
----
aks_maintenance_config1
```

Get a maintenance configuration with name "aks_maintenance_config" for a managed cluster "myCluster".

### Example 3: Get a maintenance configuration via identity
```powershell
$TimeSpan = New-AzAksTimeSpanObject -Start (Get-Date -Year 2023 -Month 3 -Day 1) -End (Get-Date -Year 2023 -Month 3 -Day 2)
$TimeInWeek = New-AzAksTimeInWeekObject -Day 'Sunday' -HourSlot 1,2
$MaintenanceConfig = New-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster -ConfigName 'aks_maintenance_config' -TimeInWeek $TimeInWeek -NotAllowedTime $TimeSpan
$MaintenanceConfig | Get-AzAksMaintenanceConfiguration
```

```output
Name
----
aks_maintenance_config
```

Get a maintenance configuration via identity for a managed cluster "myCluster".


