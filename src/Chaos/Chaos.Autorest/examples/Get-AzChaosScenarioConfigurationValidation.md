### Example 1: Read the latest validation result after testing a scenario configuration
```powershell
Test-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
Get-AzChaosScenarioConfigurationValidation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default
```

```output
Status    ScenarioConfigurationName
------    -------------------------
Succeeded default
```

Reads the latest terminal validation record produced by `Test-AzChaosScenarioConfiguration`. Use this when validation already ran and you need to inspect the stored result again before executing the configuration.

### Example 2: Read validation details that require attention
```powershell
Get-AzChaosScenarioConfigurationValidation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName canary
```

```output
Status            ScenarioConfigurationName
------            -------------------------
RequiresAttention canary
```

Reads the stored validation result for the `canary` configuration. A result can report `RequiresAttention` and include permission entries with a target `resourceId`, `missingPermissions`, and `recommendedRoles`; run `Repair-AzChaosScenarioConfigurationResourcePermission` before starting the scenario if permissions are missing.
