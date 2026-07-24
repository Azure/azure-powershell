### Example 1: Start a scenario run with pre-flight validation
```powershell
Start-AzChaosScenarioRun -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
```

```output
True
```

Validates the `default` scenario configuration and, only if validation succeeds, starts the scenario run. This mirrors the Azure Portal, where validation precedes the Run action. For a catalog scenario the cmdlet fails with a friendly error if the workspace has not been evaluated yet.

### Example 2: Start a scenario run without validation and return immediately
```powershell
Start-AzChaosScenarioRun -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default -SkipValidation -NoWait
```

```output
True
```

Bypasses the pre-flight validation with `-SkipValidation` and returns before the run completes with `-NoWait`. Poll the run status with `Get-AzChaosScenarioRun`.
