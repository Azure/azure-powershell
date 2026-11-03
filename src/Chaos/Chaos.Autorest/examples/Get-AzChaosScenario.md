### Example 1: List all scenarios in a workspace
```powershell
Get-AzChaosScenario -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace
```

```output
Name             ResourceGroupName ProvisioningState
----             ----------------- -----------------
contoso-scenario contoso-rg        Succeeded
zone-down        contoso-rg        Succeeded
```

Lists every scenario under the `contoso-workspace` workspace.

### Example 2: Get a single scenario by name
```powershell
Get-AzChaosScenario -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -Name contoso-scenario
```

```output
Name             ResourceGroupName ProvisioningState
----             ----------------- -----------------
contoso-scenario contoso-rg        Succeeded
```

Gets the `contoso-scenario` scenario from the `contoso-workspace` workspace.
