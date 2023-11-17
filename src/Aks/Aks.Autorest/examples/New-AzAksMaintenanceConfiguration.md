### Example 1: Creates or updates a maintenance configuration in the specified managed cluster
```powershell
$TimeSpan = New-AzAksTimeSpanObject -Start (Get-Date -Year 2023 -Month 3 -Day 1) -End (Get-Date -Year 2023 -Month 3 -Day 2)
$TimeInWeek = New-AzAksTimeInWeekObject -Day 'Sunday' -HourSlot 1,2
$MaintenanceConfig = New-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster -ConfigName 'aks_maintenance_config' -TimeInWeek $TimeInWeek -NotAllowedTime $TimeSpan
```

```output
Name
----
aks_maintenance_config
```

Create a maintenance configuration "aks_maintenance_config" in a managed cluster "myCluster" with a time in week and a not allowed time span.


