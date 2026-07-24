### Example 1: Fix resource permissions for a scenario configuration
```powershell
Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default
```

```output
```

Grants the workspace identity the role assignments that the `default` scenario configuration needs on its target resources.

### Example 2: Preview the permission changes without applying them
```powershell
Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default -WhatIfMode
```

```output
```

Uses the server-side `-WhatIfMode` switch to report the role assignments the service would create, without changing any permissions. The `-WhatIfMode` switch is distinct from the common `-WhatIf` switch, which gates the HTTP call itself.
