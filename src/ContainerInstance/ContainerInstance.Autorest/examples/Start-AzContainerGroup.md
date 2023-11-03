### Example 1: Start all containers in a container group
```powershell
Start-AzContainerGroup -Name test-cg -ResourceGroupName test-rg
```

This command starts all containers in a container group.

### Example 2: Start all containers in a container group by piping
```powershell
Get-AzContainerGroup -Name test-cg -ResourceGroupName test-rg | Start-AzContainerGroup
```

This command starts all containers in a container group by piping.

