### Example 1: Remove a task hub by name
```powershell
Remove-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
```

Removes a task hub from a Durable Task scheduler.

### Example 2: Remove a task hub using pipeline input
```powershell
$taskHub = Get-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
$taskHub | Remove-AzDurableTaskHub
```

Removes a task hub using pipeline input (DeleteViaIdentity parameter set).

### Example 3: Remove a task hub with scheduler input object
```powershell
$scheduler = Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
Remove-AzDurableTaskHub -Name "testtaskhub" -SchedulerInputObject $scheduler
```

Removes a task hub using a scheduler input object (DeleteViaIdentityScheduler parameter set).

### Example 4: Remove a task hub with PassThru parameter
```powershell
Remove-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler" -PassThru
```

```output
True
```

Removes a task hub and returns a boolean value indicating success.
