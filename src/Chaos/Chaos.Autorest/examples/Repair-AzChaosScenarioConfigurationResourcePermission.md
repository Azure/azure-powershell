### Example 1: Fix resource permissions for a scenario configuration
```powershell
Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default
```

```output
```

Grants the workspace identity the role assignments that the `default` scenario configuration needs on its target resources. The service stores a terminal permission-fix record that you can read later with `Get-AzChaosScenarioConfigurationResourcePermission`.

### Example 2: Preview the permission changes without applying them
```powershell
Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default -WhatIfMode
```

```output
```

Uses the server-side `-WhatIfMode` switch to report the role assignments the service would create, without changing any permissions. The `-WhatIfMode` switch is distinct from the common `-WhatIf` switch, which gates the HTTP call itself. Read the stored dry-run result later with `Get-AzChaosScenarioConfigurationResourcePermission`.

### Example 3: Preview the PowerShell call without sending a request
```powershell
Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default -WhatIf
```

```output
What if: Performing the operation "Repair-AzChaosScenarioConfigurationResourcePermission" on target "default".
```

Uses the common PowerShell `-WhatIf` switch. This is client-side preview behavior: PowerShell stops the request before it is sent, so the service does not calculate role assignments and no permission-fix result is stored.
