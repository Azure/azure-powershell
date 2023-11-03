### Example 1: Delete a configuration profile assignment by name
```powershell
Remove-AzAutomanageConfigProfileHcrpAssignment -ResourceGroupName automangerg -MachineName aglinuxmachine
```

```output
```

This command deletes a configuration profile assignment by name.

### Example 2: Delete a configuration profile assignment by pipeline
```powershell
Get-AzAutomanageConfigProfileHcrpAssignment -ResourceGroupName automangerg -MachineName aglinuxmachine | Remove-AzAutomanageConfigProfileHcrpAssignment
```

```output
```

This command deletes a configuration profile assignment by pipeline.

