### Example 1: Create a new direct peering object
```powershell
$peerAsnId = "/subscriptions/{subId}/providers/Microsoft.Peering/peerAsns/ContosoEdgeTest"
$directConnections = New-AzPeeringDirectConnectionObject -BandwidthInMbps 10000 -BgpSessionMaxPrefixesAdvertisedV4 20000

New-AzPeering -Name TestPeeringPs -ResourceGroupName DemoRG -Kind Direct -Location "South Central US" -DirectConnection $directConnections -DirectPeeringType Cdn -DirectPeerAsnId $peerAsnId -PeeringLocation Dallas -Sku Premium_Direct_Unlimited
```

```output
Name        SkuName                  Kind   PeeringLocation ProvisioningState Location
----        -------                  ----   --------------- ----------------- --------
TestPeering Premium_Direct_Unlimited Direct Dallas          Succeeded         South Central US
```

Create a new direct peering object

