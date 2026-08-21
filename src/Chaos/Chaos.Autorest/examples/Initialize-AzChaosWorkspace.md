### Example 1: Stand up a ready-to-use workspace end to end
```powershell
Initialize-AzChaosWorkspace -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -Location eastus -Scope '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg'
```

```output
Name             ResourceGroupName RecommendationStatus
----             ----------------- --------------------
zone-down        contoso-rg        Recommended
disk-io-pressure contoso-rg        Recommended
```

Runs the five first-day setup steps: ensure the resource group exists, create the workspace with a system-assigned identity, grant that identity the `Reader` role on the scope, evaluate scenarios, and report the discovered scenarios plus suggested next commands.

### Example 2: Stand up a workspace over multiple scopes without granting permissions
```powershell
$scopes = @(
    '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg',
    '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/payments-rg'
)
Initialize-AzChaosWorkspace -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -Location eastus -Scope $scopes -SkipPermission -SkipEvaluationWait
```

```output
Name             ResourceGroupName RecommendationStatus
----             ----------------- --------------------
zone-down        contoso-rg        Recommended
```

Sets up the workspace over two scopes, opts out of the RBAC grant with `-SkipPermission` (grant the `Reader` role yourself later), and runs a single evaluation attempt with `-SkipEvaluationWait` instead of waiting out Azure Resource Graph propagation.
