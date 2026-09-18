### Example 1: Creates or updates a maintenance configuration in the specified managed cluster
```powershell
$TimeSpan = New-AzAksTimeSpanObject -Start (Get-Date -Year 2023 -Month 3 -Day 1) -End (Get-Date -Year 2023 -Month 3 -Day 2)
$TimeInWeek = New-AzAksTimeInWeekObject -Day Sunday -HourSlot 1,2
New-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster -ConfigName 'aks_maintenance_config' -TimeInWeek $TimeInWeek -NotAllowedTime $TimeSpan
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/mygroup/providers/Microsoft.ContainerService/managedClusters/myCluster/maintenanceConfigurations/aks_mainten
                               ance_config
Name                         : aks_maintenance_config
NotAllowedTime               : {{
                                 "start": "2023-03-01T07:56:08.2725383Z",
                                 "end": "2023-03-02T07:56:08.2727034Z"
                               }}
ResourceGroupName            : mygroup
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TimeInWeek                   : {{
                                 "day": "Sunday",
                                 "hourSlots": [ 1, 2 ]
                               }}
Type                         :
```

Create a maintenance configuration "aks_maintenance_config" in a managed cluster "myCluster" with a time in week and a not allowed time span.