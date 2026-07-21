### Example 1: Create a scenario configuration
```powershell
New-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
```

```output
Name    ResourceGroupName ProvisioningState
----    ----------------- -----------------
default contoso-rg        Succeeded
```

Creates the `default` scenario configuration for the `contoso-scenario` scenario using the workspace scopes.

### Example 2: Create a scenario configuration with resource filters and exclusions
```powershell
New-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name canary `
    -FilterLocation 'eastus' -FilterZone '1' -ExclusionType 'Microsoft.Compute/virtualMachines'
```

```output
Name   ResourceGroupName ProvisioningState
----   ----------------- -----------------
canary contoso-rg        Succeeded
```

Creates a scenario configuration that only targets resources in `eastus` zone `1`, and excludes virtual machines from the blast radius.
