### Example 1: List all scenario configurations for a scenario
```powershell
Get-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario
```

```output
Name    ResourceGroupName ProvisioningState
----    ----------------- -----------------
default contoso-rg        Succeeded
canary  contoso-rg        Succeeded
```

Lists every scenario configuration under the `contoso-scenario` scenario.

### Example 2: Get a single scenario configuration by name
```powershell
Get-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
```

```output
Name    ResourceGroupName ProvisioningState
----    ----------------- -----------------
default contoso-rg        Succeeded
```

Gets the `default` scenario configuration from the `contoso-scenario` scenario.
