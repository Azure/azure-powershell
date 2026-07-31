### Example 1: Validate a scenario configuration
```powershell
Test-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
```

```output
```

Runs a pre-flight validation of the `default` scenario configuration. Validation reports errors without starting a run and stores a terminal validation record that you can read later with `Get-AzChaosScenarioConfigurationValidation`.

### Example 2: Validate a scenario configuration and branch on the result
```powershell
if (Test-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default -PassThru) {
    Write-Host 'The scenario configuration is valid.'
}
```

```output
The scenario configuration is valid.
```

Uses `-PassThru` to return `$true` when the configuration is valid, so a script can decide whether to start a run. To inspect a previous validation result after the command finishes, call `Get-AzChaosScenarioConfigurationValidation`.
