### Example 1: Stop all containers in a container group
```powershell
Stop-AzContainerGroup -Name test-cg -ResourceGroupName test-rg
```

This command stops all containers in a container group. Compute resources will be deallocated and billing will stop.

### Example 2: Stop all containers in a container group by piping
```powershell
Get-AzContainerGroup -Name test-cg -ResourceGroupName test-rg | Stop-AzContainerGroup
```

This command stops all containers in a container group by piping.

