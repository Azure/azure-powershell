### Example 1: Start all containers in a container group
```powershell
PS C:\> start-AzContainerGroup -Name test-cg -ResourceGroupName test-rg
```

This command starts all containers in a container group.

### Example 2: Start all containers in a container group by piping
```powershell
PS C:\> Get-AzContainerGroup -Name test-cg -ResourceGroupName test-rg | Start-AzContainerGroup

```

This command starts all containers in a container group by piping.

