### Example 1: List all task hubs for a scheduler
```powershell
Get-AzDurableTaskHub -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
```

```output
DashboardUrl                 : https://test-db.northcentralus.1.durabletask.io/taskhubs/testtaskhub
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler/taskHubs/testtaskhub
Name                         : testtaskhub
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Type                         : Microsoft.DurableTask/schedulers/taskHubs
```

Lists all task hubs for a specific Durable Task scheduler.

### Example 2: Get a specific task hub by name
```powershell
Get-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
```

```output
DashboardUrl                 : https://test-db.northcentralus.1.durabletask.io/taskhubs/testtaskhub
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler/taskHubs/testtaskhub
Name                         : testtaskhub
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Type                         : Microsoft.DurableTask/schedulers/taskHubs
```

Gets the details of a specific task hub by name.

### Example 3: Get a task hub using pipeline input
```powershell
$taskHub = Get-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
$taskHub | Get-AzDurableTaskHub
```

```output
DashboardUrl                 : https://test-db.northcentralus.1.durabletask.io/taskhubs/testtaskhub
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler/taskHubs/testtaskhub
Name                         : testtaskhub
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Type                         : Microsoft.DurableTask/schedulers/taskHubs
```

Gets a task hub using pipeline input (GetViaIdentity parameter set).

### Example 4: Get a task hub with scheduler input object
```powershell
$scheduler = Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
Get-AzDurableTaskHub -Name "testtaskhub" -SchedulerInputObject $scheduler
```

```output
DashboardUrl                 : https://test-db.northcentralus.1.durabletask.io/taskhubs/testtaskhub
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler/taskHubs/testtaskhub
Name                         : testtaskhub
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Type                         : Microsoft.DurableTask/schedulers/taskHubs
```

Gets a task hub using a scheduler input object (GetViaIdentityScheduler parameter set).
