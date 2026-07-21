### Example 1: Cancel a running scenario run
```powershell
Stop-AzChaosScenarioRun -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -RunId 22222222-2222-2222-2222-222222222222
```

```output
```

Cancels the in-progress scenario run identified by `RunId` and stops the injected faults.

### Example 2: Cancel a running scenario run by pipeline input
```powershell
Get-AzChaosScenarioRun -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -RunId 22222222-2222-2222-2222-222222222222 | Stop-AzChaosScenarioRun
```

```output
```

Gets the running scenario run and cancels it through the pipeline.
