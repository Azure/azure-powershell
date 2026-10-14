### Example 1: Check whether an address space is available in a community
```powershell
$communityId = '/subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/communities/contoso-community'
Test-AzMissionCommunityAddressSpaceAvailability -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg' -CommunityResourceId $communityId -EnclaveVirtualNetworkName 'enclave-vnet' -EnclaveVirtualNetworkCustomCidrRange '10.0.2.0/24' -EnclaveVirtualNetworkSize 'small'
```

```output
Value
-----
 True
```

Checks whether the `10.0.2.0/24` CIDR range is available for a new `enclave-vnet` virtual network under the `contoso-community` community. A `Value` of `True` means the address space can be allocated without conflict.
