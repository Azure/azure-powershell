### Example 1: Delete a workspace.
```powershell
 Remove-AzMonitorWorkspace -Name azps-monitor-workspace -ResourceGroupName azps_test_group
```

Delete a workspace.

### Example 2: Delete a workspace.
```powershell
Get-AzMonitorWorkspace -Name azps-monitor-workspace -ResourceGroupName azps_test_group | Remove-AzMonitorWorkspace
```

Delete a workspace.