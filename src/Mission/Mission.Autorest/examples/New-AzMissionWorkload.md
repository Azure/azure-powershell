### Example 1: Create a workload in a virtual enclave
```powershell
New-AzMissionWorkload -Name 'contoso-workload' -ResourceGroupName 'mission-rg' -VirtualEnclaveName 'contoso-enclave' -Location 'eastus' -ResourceGroupCollection @('/subscriptions/<subscriptionId>/resourceGroups/workload-rg')
```

```output
Name              Location ResourceGroupName ProvisioningState
----              -------- ----------------- -----------------
contoso-workload  eastus   mission-rg        Succeeded
```

Creates a workload named `contoso-workload` inside the `contoso-enclave` virtual enclave, governing the `workload-rg` resource group.
