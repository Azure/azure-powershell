### Example 1: Delete a Container App Job.
```powershell
Remove-AzContainerAppJob -ResourceGroupName azps_test_group_app -Name azps-app-job
```

Delete a Container App Job.

### Example 2: Delete a Container App Job.
```powershell
$job = Get-AzContainerAppJob -ResourceGroupName azps_test_group_app -Name azps-app-job
Remove-AzContainerAppJob -InputObject $job
```

Delete a Container App Job.