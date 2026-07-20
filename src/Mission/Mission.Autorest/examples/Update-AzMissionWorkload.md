### Example 1: Patch a workload's tags
```powershell
Update-AzMissionWorkload -Name 'contoso-workload' -ResourceGroupName 'mission-rg' -VirtualEnclaveName 'contoso-enclave' -Tag @{ costCenter = 'platform' }
```

```output
Name              Location ResourceGroupName ProvisioningState
----              -------- ----------------- -----------------
contoso-workload  eastus   mission-rg        Succeeded
```

Updates only the tags on the existing `contoso-workload` workload, leaving the governed resource groups unchanged (PATCH semantics).
