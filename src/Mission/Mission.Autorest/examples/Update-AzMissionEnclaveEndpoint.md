### Example 1: Patch an enclave endpoint's tags
```powershell
Update-AzMissionEnclaveEndpoint -Name 'contoso-enclave-endpoint' -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg' -Tag @{ tier = 'edge' }
```

```output
Name                     Location ResourceGroupName ProvisioningState UpdateMode
----                     -------- ----------------- ----------------- ----------
contoso-enclave-endpoint eastus   mission-rg        Succeeded         Automatic
```

Updates only the tags on the existing `contoso-enclave-endpoint` enclave endpoint, leaving its rule collection intact (PATCH semantics).
