### Example 1: Delete a scenario configuration
```powershell
Remove-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
```

```output
```

Deletes the `default` scenario configuration from the `contoso-scenario` scenario.

### Example 2: Delete a scenario configuration by pipeline input
```powershell
Get-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default | Remove-AzChaosScenarioConfiguration
```

```output
```

Gets the `default` scenario configuration and deletes it through the pipeline.
