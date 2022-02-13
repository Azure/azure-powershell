### Example 1: Update a container group 
```powershell
PS C:\> $container = Update-AzContainerGroup -Name test-cg -ResourceGroupName test-rg -Tag @{"k"="v"}
PS C:\> $container.Tag | fl

Keys                 : {k}
Values               : {v}
AdditionalProperties : {[k, v]}
Count                : 1
```

This command updates a container group.

### Example 2: Update a container group using piping
```powershell
PS C:\> $container = Get-AzContainerGroup -Name test-cg -ResourceGroupName test-rg | Update-AzContainerGroup -Tag @{"k"="v"}
PS C:\> $container.Tag | fl

Keys                 : {k}
Values               : {v}
AdditionalProperties : {[k, v]}
Count                : 1
```

This command updates a container group using pipeing.

