### Example 1: Remove a container group
```powershell
PS C:\> Remove-AzContainerGroup -Name test-cg -ResourceGroupName test-rg

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This command removes the specified container group.

### Example 2: Removes a container group by piping
```powershell
PS C:\> Get-AzContainerGroup -Name test-cg -ResourceGroupName bez-rg | Remove-AzContainerGroup

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This command removes a container group by piping.