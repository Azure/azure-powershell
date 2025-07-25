### Example 1: Gets legacy peering object
```powershell
Get-AzPeeringLegacy -Kind Direct -PeeringLocation Seattle
```

```output
Name           SkuName             Kind     PeeringLocation ProvisioningState Location
----           -------             ----     --------------- ----------------- --------
DemoComp1      Premium_Direct_Free Direct   Dallas          Succeeded         South Central US
DemoPeering    Premium_Direct_Free Direct   Dallas          Succeeded         South Central US
TestEdgeZone   Premium_Direct_Free Direct   Atlanta         Succeeded         East US 2
```

Gets legacy peering object

