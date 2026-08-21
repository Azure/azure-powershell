### Example 1: Get a virtual enclave by name
```powershell
Get-AzMissionVirtualEnclave -Name 'contoso-enclave' -ResourceGroupName 'mission-rg'
```

```output
Name             Location ResourceGroupName ProvisioningState
----             -------- ----------------- -----------------
contoso-enclave  eastus   mission-rg        Succeeded
```

Gets the virtual enclave named `contoso-enclave` in the `mission-rg` resource group.

### Example 2: List all virtual enclaves in a resource group
```powershell
Get-AzMissionVirtualEnclave -ResourceGroupName 'mission-rg'
```

```output
Name             Location ResourceGroupName ProvisioningState
----             -------- ----------------- -----------------
contoso-enclave  eastus   mission-rg        Succeeded
```

Lists every virtual enclave in the `mission-rg` resource group.
