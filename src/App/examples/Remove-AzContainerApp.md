### Example 1: Delete a Container App.
```powershell
Remove-AzContainerApp -Name azps-containerapp-1 -ResourceGroupName azps_test_group_app
```

Delete a Container App.

### Example 2: Delete a Container App.
```powershell
$containerapp = Get-AzContainerApp -Name azps-containerapp-1 -ResourceGroupName azps_test_group_app
Remove-AzContainerApp -InputObject $containerapp
```

Delete a Container App.