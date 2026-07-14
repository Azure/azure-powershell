### Example 1: Get a workload by name
```powershell
Get-AzMissionWorkload -Name 'contoso-workload' -ResourceGroupName 'mission-rg' -VirtualEnclaveName 'contoso-enclave'
```

```output
Name              Location ResourceGroupName ProvisioningState
----              -------- ----------------- -----------------
contoso-workload  eastus   mission-rg        Succeeded
```

Gets the workload named `contoso-workload` in the `contoso-enclave` virtual enclave.

### Example 2: List all workloads in a virtual enclave
```powershell
Get-AzMissionWorkload -ResourceGroupName 'mission-rg' -VirtualEnclaveName 'contoso-enclave'
```

```output
Name              Location ResourceGroupName ProvisioningState
----              -------- ----------------- -----------------
contoso-workload  eastus   mission-rg        Succeeded
```

Lists every workload in the `contoso-enclave` virtual enclave.
