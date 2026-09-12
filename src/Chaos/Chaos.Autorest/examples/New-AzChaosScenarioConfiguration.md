### Example 1: Create a scenario configuration
```powershell
$scenarioId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Chaos/workspaces/contoso-workspace/scenarios/contoso-scenario'
New-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default -ScenarioId $scenarioId
```

```output
Name    ResourceGroupName ProvisioningState
----    ----------------- -----------------
default contoso-rg        Succeeded
```

Creates the `default` scenario configuration for the `contoso-scenario` scenario using the workspace scopes. Pass `-ScenarioId` so the configuration explicitly references the scenario resource it configures.

### Example 2: Create a scenario configuration with resource filters and exclusions
```powershell
$scenarioId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Chaos/workspaces/contoso-workspace/scenarios/contoso-scenario'
New-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name canary -ScenarioId $scenarioId `
    -FilterLocation 'eastus' -FilterZone '1' -ExclusionType 'Microsoft.Compute/virtualMachines'
```

```output
Name   ResourceGroupName ProvisioningState
----   ----------------- -----------------
canary contoso-rg        Succeeded
```

Creates a scenario configuration that only targets resources in `eastus` zone `1`, and excludes virtual machines from the blast radius. Use filters and exclusions when the workspace scope is broader than the resources this configuration should affect.
