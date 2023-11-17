### Example 1: Updates a configuration profile
```powershell
Update-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name confpro-pwsh01 -Tag @{"Organization" = "Administration"}
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   confpro-pwsh01 automangerg
```

This command updates a configuration profile.

### Example 2: Updates a configuration pipeline.
```powershell
Get-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name confpro-pwsh01 | Update-AzAutomanageConfigProfile -Tag @{"Organization" = "Administration"}
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   confpro-pwsh01 automangerg
```

This command updates a configuration pipeline.