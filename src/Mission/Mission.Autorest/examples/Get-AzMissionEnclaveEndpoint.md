### Example 1: List all enclave endpoints in a virtual enclave
```powershell
Get-AzMissionEnclaveEndpoint -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg'
```

```output
Name                    Location ResourceGroupName ProvisioningState
----                    -------- ----------------- -----------------
contoso-enclave-endpoint eastus  mission-rg        Succeeded
```

Lists every enclave endpoint defined under the `contoso-enclave` virtual enclave in the `mission-rg` resource group.

### Example 2: Get a single enclave endpoint by name
```powershell
Get-AzMissionEnclaveEndpoint -Name 'contoso-enclave-endpoint' -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg'
```

```output
Name                     Location ResourceGroupName ProvisioningState UpdateMode
----                     -------- ----------------- ----------------- ----------
contoso-enclave-endpoint eastus   mission-rg        Succeeded         Automatic
```

Retrieves the `contoso-enclave-endpoint` enclave endpoint, including its rule collection and update mode.
