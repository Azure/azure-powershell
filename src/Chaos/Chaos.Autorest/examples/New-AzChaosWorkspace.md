### Example 1: Create a workspace with a system-assigned identity
```powershell
New-AzChaosWorkspace -ResourceGroupName contoso-rg -Name contoso-workspace -Location eastus -Scope '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg' -EnableSystemAssignedIdentity
```

```output
Name              Location ResourceGroupName ProvisioningState
----              -------- ----------------- -----------------
contoso-workspace eastus   contoso-rg        Succeeded
```

Creates the `contoso-workspace` workspace with a system-assigned managed identity and a single resource-group scope. Always supply an identity: if the service accepts a workspace create request without one, it can fail asynchronously with `IdentityUrl cannot be null or empty` instead of returning a clean validation error. Use `Initialize-AzChaosWorkspace` when you want the setup path that creates the workspace with a system-assigned identity for you.

### Example 2: Create a workspace with multiple scopes and tags
```powershell
$scopes = @(
    '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg',
    '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/payments-rg'
)
New-AzChaosWorkspace -ResourceGroupName contoso-rg -Name contoso-workspace -Location eastus -Scope $scopes -EnableSystemAssignedIdentity -Tag @{ team = 'resilience'; env = 'prod' }
```

```output
Name              Location ResourceGroupName ProvisioningState
----              -------- ----------------- -----------------
contoso-workspace eastus   contoso-rg        Succeeded
```

Creates a workspace whose child scenarios can target resources in two resource groups, applies resource tags, and enables the required system-assigned managed identity.
