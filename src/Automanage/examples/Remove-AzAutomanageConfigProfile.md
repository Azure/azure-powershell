### Example 1: Delete a configuration profile by name
```powershell
Remove-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name confpro-pwsh01
```

```output
```

This command delete a configuration profile by name.

### Example 2: Delete a configuration profile by pipeline
```powershell
Get-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name confpro-pwsh01 | Remove-AzAutomanageConfigProfile
```

```output
```

This command delete a configuration profile by pipeline.