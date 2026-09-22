### Example 1: Execute a scenario configuration
```powershell
Invoke-AzChaosScenarioConfigurationExecution -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default
```

```output
```

Starts a scenario run from the `default` scenario configuration and waits for the run to reach a terminal state. This is the raw execute operation; call `Test-AzChaosScenarioConfiguration` first and read its stored result with `Get-AzChaosScenarioConfigurationValidation` if you need to inspect validation details. Prefer `Start-AzChaosScenarioRun` for the validate-then-execute workflow.

### Example 2: Execute a scenario configuration asynchronously
```powershell
Invoke-AzChaosScenarioConfigurationExecution -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default -NoWait
```

```output
```

Starts the run and returns immediately with `-NoWait`. Poll the run status with `Get-AzChaosScenarioRun`.
