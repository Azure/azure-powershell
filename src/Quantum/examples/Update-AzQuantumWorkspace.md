### Example 1: Updates an existing workspace's tags.
```powershell
Update-AzQuantumWorkspace -ResourceGroupName azps_test_group_quantum -Name azps-qw -Tag @{"abc"="123"}
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   azps-qw azps_test_group_quantum
```

Updates an existing workspace's tags.

### Example 2: Updates an existing workspace's tags.
```powershell
Get-AzQuantumWorkspace -ResourceGroupName azps_test_group_quantum -Name azps-qw | Update-AzQuantumWorkspace -Tag @{"abc"="123"}
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   azps-qw azps_test_group_quantum
```

Updates an existing workspace's tags.