### Example 1: Update a site with additional virtual networks
```powershell
Update-AzPrivateTrafficManagerSite -Name "site-eastus" -TopologyMapName "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo" -VirtualNetworkId @("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-ptm-demo/providers/Microsoft.Network/virtualNetworks/vnet-eastus", "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-ptm-demo/providers/Microsoft.Network/virtualNetworks/vnet-eastus2")
```

```output
Name         ProvisioningState
----         -----------------
site-eastus  Succeeded
```

This command updates the site to include an additional virtual network.

### Example 2: Update a site using a JSON file
```powershell
Update-AzPrivateTrafficManagerSite -Name "site-eastus" -TopologyMapName "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo" -JsonFilePath "./updated-site.json"
```

```output
Name         ProvisioningState
----         -----------------
site-eastus  Succeeded
```

This command updates the site configuration from a JSON file.

