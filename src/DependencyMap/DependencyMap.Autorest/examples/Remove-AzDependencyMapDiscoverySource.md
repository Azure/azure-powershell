### Example 1: Remove a discovery source.
```powershell
Remove-AzDependencyMapDiscoverySource -ResourceGroupName dmTestGroup -MapName testMap -SourceName dmSource
```

This command removes a discovery source from a resource group.

### Example 2: Remove a discovery source by object.
```powershell
Get-AzDependencyMapDiscoverySource -ResourceGroupName dmTestGroup -MapName testMap -SourceName dmSource | Remove-AzDependencyMapDiscoverySource
```

This command removes a discovery source from a resource group.

### Example 3: Remove a discovery source by parent object.
```powershell
Get-AzDependencyMap -ResourceGroupName dmTestGroup -Name testMap | Remove-AzDependencyMapDiscoverySource -SourceName dmSource
```

This command removes a discovery source from a resource group.