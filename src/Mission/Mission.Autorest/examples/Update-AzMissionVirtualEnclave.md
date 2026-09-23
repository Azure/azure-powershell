### Example 1: Patch a virtual enclave's tags
```powershell
Update-AzMissionVirtualEnclave -Name 'contoso-enclave' -ResourceGroupName 'mission-rg' -Tag @{ environment = 'production' }
```

```output
Name             Location ResourceGroupName ProvisioningState
----             -------- ----------------- -----------------
contoso-enclave  eastus   mission-rg        Succeeded
```

Updates only the tags on the existing `contoso-enclave` virtual enclave, leaving all other properties unchanged (PATCH semantics).
