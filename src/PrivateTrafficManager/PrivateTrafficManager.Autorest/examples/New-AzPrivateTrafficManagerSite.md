### Example 1: Create a site with virtual networks and probing gateways
```powershell
New-AzPrivateTrafficManagerSite -Name "site-eastus" -TopologyMapName "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo" -VirtualNetworkId @("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-ptm-demo/providers/Microsoft.Network/virtualNetworks/vnet-eastus") -ProbingGatewayId @("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-ptm-demo/providers/Microsoft.Network/probingGateways/pg-eastus")
```

```output
Name         ProvisioningState
----         -----------------
site-eastus  Succeeded
```

This command creates a new site within a topology map, associating it with a virtual network and a probing gateway.

### Example 2: Create a site using a JSON file
```powershell
New-AzPrivateTrafficManagerSite -Name "site-westus" -TopologyMapName "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo" -JsonFilePath "./site-config.json"
```

```output
Name         ProvisioningState
----         -----------------
site-westus  Succeeded
```

This command creates a site from a JSON configuration file.

