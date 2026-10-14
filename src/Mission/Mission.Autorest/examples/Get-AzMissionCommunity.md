### Example 1: Get a Mission community by name
```powershell
Get-AzMissionCommunity -Name 'contoso-community' -ResourceGroupName 'mission-rg'
```

```output
Name               Location ResourceGroupName ProvisioningState
----               -------- ----------------- -----------------
contoso-community  eastus   mission-rg        Succeeded
```

Gets the community named `contoso-community` in the `mission-rg` resource group.

### Example 2: List all Mission communities in a resource group
```powershell
Get-AzMissionCommunity -ResourceGroupName 'mission-rg'
```

```output
Name               Location ResourceGroupName ProvisioningState
----               -------- ----------------- -----------------
contoso-community  eastus   mission-rg        Succeeded
```

Lists every community in the `mission-rg` resource group.
