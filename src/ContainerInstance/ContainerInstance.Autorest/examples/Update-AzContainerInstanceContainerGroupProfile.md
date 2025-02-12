### Example 1: Update a container group profile 
```powershell
$container = Update-AzContainerInstanceContainerGroupProfile -Name test-cgp -ResourceGroupName test-rg -Tag @{"k"="v"}
$container.Tag | Format-List
```

```output
Keys                 : {k}
Values               : {v}
AdditionalProperties : {[k, v]}
Count                : 1
```

This command updates a container group profile.

### Example 2: Update a container group profile using piping
```powershell
$container = Get-AzContainerInstanceContainerGroupProfile -Name test-cgp -ResourceGroupName test-rg | Update-AzContainerInstanceContainerGroupProfile -Tag @{"k"="v"}
$container.Tag | Format-List
```

```output
Keys                 : {k}
Values               : {v}
AdditionalProperties : {[k, v]}
Count                : 1
```

This command updates a container group profile using pipeing.