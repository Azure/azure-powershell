### Example 1: Create a new task hub
```powershell
New-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
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

Creates a new task hub in a Durable Task scheduler.

### Example 2: Create a task hub with scheduler input object
```powershell
$scheduler = Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
New-AzDurableTaskHub -Name "testtaskhub" -SchedulerInputObject $scheduler
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

Creates a new task hub using a scheduler input object (CreateViaIdentitySchedulerExpanded parameter set).

### Example 3: Create a task hub from JSON file
```powershell
New-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler" -JsonFilePath "./taskhub.json"
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

Creates a new task hub using a JSON configuration file.

