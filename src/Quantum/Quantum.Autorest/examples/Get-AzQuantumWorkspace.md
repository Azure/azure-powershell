### Example 1: List the Workspace resource associated by the SubId.
```powershell
Get-AzQuantumWorkspace
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   azps-qw azps_test_group_quantum
```

List the Workspace resource associated by the SubId.

### Example 2: List the Workspace resource associated by the ResourceGroupName.
```powershell
Get-AzQuantumWorkspace -ResourceGroupName azps_test_group_quantum
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   azps-qw azps_test_group_quantum
```

List the Workspace resource associated by the ResourceGroupName.

### Example 3: Get the Workspace resource associated by the name.
```powershell
Get-AzQuantumWorkspace -ResourceGroupName azps_test_group_quantum -Name azps-qw
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   azps-qw azps_test_group_quantum
```

Get the Workspace resource associated by the name.