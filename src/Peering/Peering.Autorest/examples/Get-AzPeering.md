### Example 1: List all peerings
```powershell
 Get-AzPeering
```

```output
Name           SkuName             Kind     PeeringLocation ProvisioningState Location
----           -------             ----     --------------- ----------------- --------
DemoComp1      Premium_Direct_Free Direct   Dallas          Succeeded         South Central US
DemoPeering    Premium_Direct_Free Direct   Dallas          Succeeded         South Central US
TestEdgeZone   Premium_Direct_Free Direct   Atlanta         Succeeded         East US 2
MapsIxRs       Premium_Direct_Free Direct   Ashburn         Succeeded         East US
DemoMapsConfig Premium_Direct_Free Direct   Seattle         Succeeded         West US 2
testexchange   Basic_Exchange_Free Exchange Amsterdam       Succeeded         West Europe
TestPeer1      Basic_Direct_Free   Direct   Amsterdam       Succeeded         West Europe
test1          Basic_Direct_Free   Direct   Athens          Succeeded         France Central
```

List all peerings in subscription

### Example 2: Get specific peering by name and resource group
```powershell
Get-AzPeering -Name DemoPeering -ResourceGroupName DemoRG
```

```output
Name        SkuName             Kind   PeeringLocation ProvisioningState Location
----        -------             ----   --------------- ----------------- --------
DemoPeering Premium_Direct_Free Direct Dallas          Succeeded         South Central US
```

Get a specific peering by resource group and name

