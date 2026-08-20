### Example 1: Replace an enclave connection definition (PUT)
```powershell
Set-AzMissionEnclaveConnection -Name 'contoso-connection' -ResourceGroupName 'mission-rg' -Location 'eastus' -CommunityResourceId '/subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/communities/contoso-community' -DestinationEndpointId '/subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/communities/contoso-community/communityEndpoints/contoso-endpoint' -SourceCidr '10.0.2.0/24'
```

```output
Name               Location ResourceGroupName ProvisioningState
----               -------- ----------------- -----------------
contoso-connection eastus   mission-rg        Succeeded
```

Replaces the full definition of the `contoso-connection` enclave connection, changing its source CIDR to `10.0.2.0/24`.
