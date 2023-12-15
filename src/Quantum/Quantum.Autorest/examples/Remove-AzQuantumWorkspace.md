### Example 1: Deletes a Workspace resource.
```powershell
Remove-AzQuantumWorkspace -ResourceGroupName azps_test_group_quantum -Name azps-qw
```

Deletes a Workspace resource.

### Example 2: Deletes a Workspace resource.
```powershell
Get-AzQuantumWorkspace -ResourceGroupName azps_test_group_quantum -Name azps-qw | Remove-AzQuantumWorkspace
```

Deletes a Workspace resource.