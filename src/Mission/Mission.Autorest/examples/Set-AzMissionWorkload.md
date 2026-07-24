### Example 1: Replace a workload definition (PUT)
```powershell
Set-AzMissionWorkload -Name 'contoso-workload' -ResourceGroupName 'mission-rg' -VirtualEnclaveName 'contoso-enclave' -Location 'eastus' -ResourceGroupCollection @('/subscriptions/<subscriptionId>/resourceGroups/workload-rg')
```

```output
Name              Location ResourceGroupName ProvisioningState
----              -------- ----------------- -----------------
contoso-workload  eastus   mission-rg        Succeeded
```

Replaces the full definition of the `contoso-workload` workload, governing the `workload-rg` resource group. Any properties not supplied are reset to their defaults.
