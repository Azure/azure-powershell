### Example 1: Execute a scenario configuration
```powershell
Invoke-AzChaosScenarioConfigurationExecution -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default
```

```output
```

Starts a scenario run from the `default` scenario configuration and waits for the run to reach a terminal state. This is the raw execute operation. Call `Test-AzChaosScenarioConfiguration` first when you use this direct API path. Prefer `Start-AzChaosScenarioRun` for normal scripts because it performs the validate-then-execute sequence in the required order.

### Example 2: Execute a scenario configuration asynchronously
```powershell
Invoke-AzChaosScenarioConfigurationExecution -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default -NoWait
```

```output
```

Starts the run and returns immediately with `-NoWait`. Use this only after `Test-AzChaosScenarioConfiguration` succeeds. Poll the run status with `Get-AzChaosScenarioRun`, or use `Start-AzChaosScenarioRun -NoWait` when you want the wrapper that validates first.
