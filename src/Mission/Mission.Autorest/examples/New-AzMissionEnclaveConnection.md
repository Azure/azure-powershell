### Example 1: Create an enclave connection
```powershell
New-AzMissionEnclaveConnection -Name 'contoso-connection' -ResourceGroupName 'mission-rg' -Location 'eastus' -CommunityResourceId '/subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/communities/contoso-community' -DestinationEndpointId '/subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/communities/contoso-community/communityEndpoints/contoso-endpoint' -SourceCidr '10.0.1.0/24'
```

```output
Name               Location ResourceGroupName ProvisioningState
----               -------- ----------------- -----------------
contoso-connection eastus   mission-rg        Succeeded
```

Creates an enclave connection named `contoso-connection` that links the `10.0.1.0/24` source range to the `contoso-endpoint` community endpoint of `contoso-community`.
