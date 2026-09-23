### Example 1: Update a community with a full replace (PUT)
```powershell
Set-AzMissionCommunity -Name 'contoso-community' -ResourceGroupName 'mission-rg' -Location 'eastus' -AddressSpace '10.0.0.0/16' -FirewallSku 'Standard' -Tag @{ environment = 'production' }
```

```output
Name              Location ResourceGroupName ProvisioningState
----              -------- ----------------- -----------------
contoso-community eastus   mission-rg        Succeeded
```

Replaces the full definition of the `contoso-community` community, setting its address space, firewall SKU, and tags. Any properties not supplied are reset to their defaults.
