### Example 1: List all Chaos Studio workspaces in a resource group
```powershell
Get-AzChaosWorkspace -ResourceGroupName contoso-rg
```

```output
Name               Location ResourceGroupName
----               -------- -----------------
contoso-workspace  eastus   contoso-rg
payments-workspace eastus   contoso-rg
```

Lists every `Microsoft.Chaos/workspaces` resource in the `contoso-rg` resource group.

### Example 2: Get a single Chaos Studio workspace by name
```powershell
Get-AzChaosWorkspace -ResourceGroupName contoso-rg -Name contoso-workspace
```

```output
Name              Location ResourceGroupName ProvisioningState
----              -------- ----------------- -----------------
contoso-workspace eastus   contoso-rg        Succeeded
```

Gets the `contoso-workspace` workspace in the `contoso-rg` resource group.
