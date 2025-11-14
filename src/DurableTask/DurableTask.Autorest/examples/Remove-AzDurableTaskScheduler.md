### Example 1: Remove a scheduler by name
```powershell
Remove-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi"
```

Removes a Durable Task scheduler by name and resource group.

### Example 2: Remove a scheduler using pipeline input
```powershell
$scheduler = Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
$scheduler | Remove-AzDurableTaskScheduler
```

Removes a Durable Task scheduler using pipeline input (DeleteViaIdentity parameter set).

### Example 3: Remove a scheduler with PassThru parameter
```powershell
Remove-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -PassThru
```

```output
True
```

Removes a scheduler and returns a boolean value indicating success.
