### Example 1: Patch an enclave connection's tags
```powershell
Update-AzMissionEnclaveConnection -Name 'contoso-connection' -ResourceGroupName 'mission-rg' -Tag @{ environment = 'production' }
```

```output
Name               Location ResourceGroupName ProvisioningState
----               -------- ----------------- -----------------
contoso-connection eastus   mission-rg        Succeeded
```

Updates only the tags on the existing `contoso-connection` enclave connection, leaving its endpoints unchanged (PATCH semantics).
