### Example 1: Update a container group 
```powershell
$container = Update-AzContainerGroup -Name test-cg -ResourceGroupName test-rg -Tag @{"k"="v"}
$container.Tag | Format-List
```

```output
Keys                 : {k}
Values               : {v}
AdditionalProperties : {[k, v]}
Count                : 1
```

This command updates a container group.

### Example 2: Update a container group using piping
```powershell
$container = Get-AzContainerGroup -Name test-cg -ResourceGroupName test-rg | Update-AzContainerGroup -Tag @{"k"="v"}
$container.Tag | Format-List
```

```output
Keys                 : {k}
Values               : {v}
AdditionalProperties : {[k, v]}
Count                : 1
```

This command updates a container group using pipeing.

