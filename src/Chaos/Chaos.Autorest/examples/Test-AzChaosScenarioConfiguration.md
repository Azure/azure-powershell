### Example 1: Validate a scenario configuration
```powershell
Test-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
```

```output
```

Runs a pre-flight validation of the `default` scenario configuration. Validation reports errors without starting a run. Run this before `Invoke-AzChaosScenarioConfigurationExecution` when you use the direct API path.

### Example 2: Validate a scenario configuration and branch on the result
```powershell
if (Test-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default -PassThru) {
    Write-Host 'The scenario configuration is valid.'
}
```

```output
The scenario configuration is valid.
```

Uses `-PassThru` to return `$true` when the configuration is valid, so a script can decide whether to start a run with `Invoke-AzChaosScenarioConfigurationExecution`. Use `Start-AzChaosScenarioRun` instead when you want one cmdlet that validates and then executes in the required order.
