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

Uses the server-side `-WhatIfMode` switch to send `{ "whatIf": true }` to the service. The service evaluates the request and returns the role assignments it would create, without changing permissions.

### Example 3: Preview the PowerShell call without sending a request
```powershell
Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default -WhatIf
```

```output
What if: Performing the operation "Repair" on target "contoso-scenario/default".
```

Uses the common PowerShell `-WhatIf` switch. PowerShell stops the cmdlet before it sends an HTTP request, so the service does not evaluate the configuration and does not return a list of role assignments. Use `-WhatIfMode` when you need the service-side dry run result.
