### Example 1: List all registered asns for peering
```powershell
Get-AzPeeringRegisteredAsn -PeeringName MapsIxRs -ResourceGroupName MAPSDemo
```

```output
Name          Asn   PeeringServicePrefixKey              ProvisioningState
----          ---   -----------------------              -----------------
fgfg          6500  767c9f30-7388-49ef-ba8e-e2d16d1c08e4 Succeeded
homedepottest 65000 32259ee0-ea01-495e-8279-06c24ef7aae0 Succeeded
JonOrmondTest 62540 e3f552c5-909e-434b-8fab-93e524a1aeed Succeeded
```

Lists all registered asn's for a peering

### Example 2: Get specific registered asn for peering
```powershell
Get-AzPeeringRegisteredAsn -PeeringName MapsIxRs -ResourceGroupName MAPSDemo -Name fgfg
```

```output
Name Asn  PeeringServicePrefixKey              ProvisioningState
---- ---  -----------------------              -----------------
fgfg 6500 767c9f30-7388-49ef-ba8e-e2d16d1c08e4 Succeeded
```

Gets a specific registered asn for a peering by name

