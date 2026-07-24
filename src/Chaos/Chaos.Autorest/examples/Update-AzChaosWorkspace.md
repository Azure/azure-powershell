### Example 1: Update the scopes of a workspace
```powershell
Update-AzChaosWorkspace -ResourceGroupName contoso-rg -Name contoso-workspace -Scope '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg','/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/payments-rg'
```

```output
Name              Location ResourceGroupName ProvisioningState
----              -------- ----------------- -----------------
contoso-workspace eastus   contoso-rg        Succeeded
```

Replaces the resource scopes that the `contoso-workspace` workspace discovers and evaluates.

### Example 2: Update the tags on a workspace
```powershell
Update-AzChaosWorkspace -ResourceGroupName contoso-rg -Name contoso-workspace -Tag @{ env = 'prod'; owner = 'resilience-team' }
```

```output
Name              Location ResourceGroupName ProvisioningState
----              -------- ----------------- -----------------
contoso-workspace eastus   contoso-rg        Succeeded
```

Updates the resource tags on the `contoso-workspace` workspace without changing any other property.
