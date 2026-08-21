### Example 1: Create a Mission community
```powershell
New-AzMissionCommunity -Name 'contoso-community' -ResourceGroupName 'mission-rg' -Location 'eastus' -AddressSpace '10.0.0.0/16'
```

```output
Name               Location ResourceGroupName ProvisioningState
----               -------- ----------------- -----------------
contoso-community  eastus   mission-rg        Succeeded
```

Creates a new Azure Virtual Enclaves community named `contoso-community` with the `10.0.0.0/16` address space. A community is the top-level `Microsoft.Mission` resource under which virtual enclaves and hubs are provisioned.
