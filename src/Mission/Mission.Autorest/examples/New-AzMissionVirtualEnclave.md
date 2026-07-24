### Example 1: Create a virtual enclave in a community
```powershell
$communityId = '/subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/communities/contoso-community'
New-AzMissionVirtualEnclave -Name 'contoso-enclave' -ResourceGroupName 'mission-rg' -Location 'eastus' -CommunityResourceId $communityId -EnclaveVirtualNetworkName 'enclave-vnet' -EnclaveVirtualNetworkCustomCidrRange '10.0.1.0/24'
```

```output
Name             Location ResourceGroupName ProvisioningState
----             -------- ----------------- -----------------
contoso-enclave  eastus   mission-rg        Succeeded
```

Creates a virtual enclave named `contoso-enclave` under the `contoso-community` community, backed by a `10.0.1.0/24` enclave virtual network.
