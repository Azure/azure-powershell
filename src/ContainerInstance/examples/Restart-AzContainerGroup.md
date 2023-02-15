### Example 1: Restart all containers in a container group
```powershell
Restart-AzContainerGroup -Name test-cg -ResourceGroupName test-rg
```

This command restarts all containers in a container group.

### Example 2: Restart all containers in a container group by piping
```powershell
Get-AzContainerGroup -Name test-cg -ResourceGroupName test-rg | Restart-AzContainerGroup
```

This command restarts all containers in a container group by piping.

