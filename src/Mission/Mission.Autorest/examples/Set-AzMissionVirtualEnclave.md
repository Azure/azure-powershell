### Example 1: Replace a virtual enclave definition (PUT)
```powershell
$communityId = '/subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/communities/contoso-community'
Set-AzMissionVirtualEnclave -Name 'contoso-enclave' -ResourceGroupName 'mission-rg' -Location 'eastus' -CommunityResourceId $communityId -BastionEnabled
```

```output
Name             Location ResourceGroupName ProvisioningState
----             -------- ----------------- -----------------
contoso-enclave  eastus   mission-rg        Succeeded
```

Replaces the full definition of the `contoso-enclave` virtual enclave, enabling Azure Bastion access. Any properties not supplied are reset to their defaults.
