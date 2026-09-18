### Example 1: List all runs for a scenario
```powershell
Get-AzChaosScenarioRun -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario
```

```output
RunId                                Status    ProvisioningState
-----                                ------    -----------------
11111111-1111-1111-1111-111111111111 Succeeded Succeeded
22222222-2222-2222-2222-222222222222 Running   Succeeded
```

Lists every scenario run recorded for the `contoso-scenario` scenario.

### Example 2: Get a single scenario run by run id
```powershell
Get-AzChaosScenarioRun -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -RunId 11111111-1111-1111-1111-111111111111
```

```output
RunId                                Status    ProvisioningState
-----                                ------    -----------------
11111111-1111-1111-1111-111111111111 Succeeded Succeeded
```

Gets a single scenario run by its run id. This is also the polling target for a run started by `Invoke-AzChaosScenarioConfigurationExecution`.
