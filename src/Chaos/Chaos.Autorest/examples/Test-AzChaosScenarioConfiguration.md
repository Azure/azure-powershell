### Example 1: Validate a scenario configuration
```powershell
Test-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
```

```output
```

Runs a pre-flight validation of the `default` scenario configuration. Validation reports errors without starting a run and stores a terminal validation record that you can read later with `Get-AzChaosScenarioConfigurationValidation`.

### Example 2: Validate a scenario configuration and branch on the result
```powershell
$validation = Test-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
if ($validation.Status -eq 'Succeeded') {
    Write-Host 'The scenario configuration is valid.'
} else {
    Write-Host "Validation returned '$($validation.Status)'."
    $validation.ErrorPermission | Format-List ResourceId, MissingPermission, RecommendedRole
}
```

```output
Validation returned 'RequiresAttention'.

ResourceId        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm
MissingPermission : {Microsoft.Compute/virtualMachines/powerOff/action, Microsoft.Compute/virtualMachines/start/action}
RecommendedRole   : {9980e02c-c2be-4d73-94e8-173b1dc7cf3c}
```

Branches on the returned validation record. The command returns a validation object, not a boolean, so test `Status` explicitly &mdash; testing the object itself is always true and would treat a failed validation as a success. A terminal status of `Succeeded` means the configuration is ready to run; `RequiresAttention` means the errors on `ErrorPermission` and `ErrorResource` must be resolved first. To re-read this record later, call `Get-AzChaosScenarioConfigurationValidation`.
