### Example 1: Delete a configuration profile assignment by name
```powershell
Remove-AzAutomanageConfigProfileHciAssignment -ResourceGroupName automangerg -ClusterName aglinuxcluster
```

```output
```

This command deletes a configuration profile assignment by name.

### Example 2: Delete a configuration profile assignment by pipeline
```powershell
Get-AzAutomanageConfigProfileHciAssignment -ResourceGroupName automangerg -ClusterName aglinuxcluster | Remove-AzAutomanageConfigProfileHciAssignment
```

```output
```

This command deletes a configuration profile assignment by pipeline.