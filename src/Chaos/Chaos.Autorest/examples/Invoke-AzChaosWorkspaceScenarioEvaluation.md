### Example 1: Evaluate a workspace end to end
```powershell
Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace
```

```output
True
```

Discovers the in-scope resources for the `contoso-workspace` workspace and evaluates which catalog scenarios apply to them, refreshing each per-scenario recommendation status. Run this before you start a catalog scenario.

### Example 2: Evaluate a workspace and return immediately
```powershell
Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -NoWait
```

```output
True
```

Starts the discover-plus-evaluate workflow and returns before it completes with `-NoWait`. Query the scenarios with `Get-AzChaosScenario` to read the refreshed recommendation status.
