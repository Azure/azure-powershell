### Example 1: Delete a scenario
```powershell
Remove-AzChaosScenario -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -Name contoso-scenario
```

```output
```

Deletes the `contoso-scenario` scenario and its scenario configurations from the `contoso-workspace` workspace.

### Example 2: Delete a scenario by pipeline input
```powershell
Get-AzChaosScenario -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -Name contoso-scenario | Remove-AzChaosScenario
```

```output
```

Gets the `contoso-scenario` scenario and deletes it through the pipeline.
