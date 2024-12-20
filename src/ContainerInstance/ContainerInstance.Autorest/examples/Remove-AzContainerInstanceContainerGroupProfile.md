### Example 1: Remove a container group profile
```powershell
Remove-AzContainerInstanceContainerGroupProfile -Name test-cgp -ResourceGroupName test-rg
```

```output
```

This command removes the specified container group profile.

### Example 2: Removes a container group profile by piping
```powershell
Get-AzContainerInstanceContainerGroupProfile -Name test-cgp -ResourceGroupName test-rg | Remove-AzContainerInstanceContainerGroupProfile
```

```output
```

This command removes a container group profile by piping.