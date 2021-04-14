### Example 1: Restart all containers in a container group
```powershell
PS C:\> Restart-AzContainerGroup -Name test-cg -ResourceGroupName test-rg
```

This command restarts all containers in a container group.

### Example 2: Restart all containers in a container group by piping
```powershell
PS C:\> Get-AzContainerGroup -Name test-cg -ResourceGroupName test-rg | Restart-AzContainerGroup
```

This command restarts all containers in a container group by piping.

