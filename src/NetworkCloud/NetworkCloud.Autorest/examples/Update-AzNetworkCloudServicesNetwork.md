### Example 1: Update cloud services network
```powershell
$tags = @{
    Tag1 = 'tag1'
    Tag2  = 'tag2'
}

Update-AzNetworkCloudServicesNetwork -ResourceGroupName resourceGroupName -CloudServicesNetworkName cloudNetworkServicesName -Tag $tags
```

This command updates tags associated with the cloud services network.

### Example 2: Update egress endpoint for cloud services network
```powershell
$endpointEgressList = @{}
Update-AzNetworkCloudServicesNetwork -ResourceGroupName resourceGroupName -CloudServicesNetworkName cloudNetworkServicesName -AdditionalEgressEndpoint $endpointEgressList -EnableDefaultEgressEndpoint false
```

This command updates the egress endpoint for the cloud services network.
