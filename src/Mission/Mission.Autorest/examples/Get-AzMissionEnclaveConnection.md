### Example 1: List all enclave connections in a resource group
```powershell
Get-AzMissionEnclaveConnection -ResourceGroupName 'mission-rg'
```

```output
Name               Location ResourceGroupName ProvisioningState
----               -------- ----------------- -----------------
contoso-connection eastus   mission-rg        Succeeded
```

Lists every enclave connection in the `mission-rg` resource group.

### Example 2: Get a single enclave connection by name
```powershell
Get-AzMissionEnclaveConnection -Name 'contoso-connection' -ResourceGroupName 'mission-rg'
```

```output
Name               Location ResourceGroupName ProvisioningState
----               -------- ----------------- -----------------
contoso-connection eastus   mission-rg        Succeeded
```

Retrieves the `contoso-connection` enclave connection, including its source and destination endpoints.
