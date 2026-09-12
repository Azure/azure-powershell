### Example 1: Read the latest permission fix result after a dry run
```powershell
Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default -WhatIfMode
Get-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default
```

```output
State           ScenarioConfigurationName Summary
-----           ------------------------- -------
WhatIfCompleted default                   2 role assignments would be created.
```

Reads the latest permission-fix record produced by `Repair-AzChaosScenarioConfigurationResourcePermission -WhatIfMode`. Use this to inspect the service-side dry-run result later; the record includes a `state`, a `summary`, and per-assignment `roleAssignments` statuses.

### Example 2: Read the latest permission fix result after applying permissions
```powershell
Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default
Get-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default
```

```output
State     ScenarioConfigurationName Summary
-----     ------------------------- -------
Completed default                   Required role assignments are present.
```

Reads the stored permission-fix result after the repair operation runs. Use this cmdlet when you need to re-check the terminal permission result without creating new role assignments or running another dry run.
