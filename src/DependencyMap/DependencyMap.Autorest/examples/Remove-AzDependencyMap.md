### Example 1: Remove a dependency map.
```powershell
Remove-AzDependencyMap -ResourceGroupName dmTestGroup -Name testMap
```

This command removes dependency map from a resource group.

### Example 2: Remove a dependency map by object.
```powershell
Get-AzDependencyMap -ResourceGroupName dmTestGroup -Name testMap | Remove-AzDependencyMap
```

This command removes dependency map from a resource group.
