### Example 1: List all community endpoints in a community
```powershell
Get-AzMissionCommunityEndpoint -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg'
```

```output
Name             Location ResourceGroupName ProvisioningState
----             -------- ----------------- -----------------
contoso-endpoint eastus   mission-rg        Succeeded
```

Lists every community endpoint defined under the `contoso-community` community in the `mission-rg` resource group.

### Example 2: Get a single community endpoint by name
```powershell
Get-AzMissionCommunityEndpoint -Name 'contoso-endpoint' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg'
```

```output
Name             Location ResourceGroupName ProvisioningState UpdateMode
----             -------- ----------------- ----------------- ----------
contoso-endpoint eastus   mission-rg        Succeeded         Automatic
```

Retrieves the `contoso-endpoint` community endpoint, including its rule collection and update mode.
