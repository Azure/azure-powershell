### Example 1: Create a new direct peering object
```powershell
$connection1 = New-AzPeeringDirectConnectionObject -BandwidthInMbps 10000 -BgpSessionMaxPrefixesAdvertisedV4 20000 ...
$directConnections = ,$connection1
New-AzPeering -Name TestPeering -ResourceGroupName DemoRG -Kind Direct -Location "South Central US" -DirectConnection $directConnections -DirectPeeringType Cdn -DirectPeerAsnId $peerAsnId -PeeringLocation Dallas -Sku Premium_Direct_Free
```

```output
Name        SkuName             Kind   PeeringLocation ProvisioningState Location
----        -------             ----   --------------- ----------------- --------
TestPeering Premium_Direct_Free Direct Dallas          PendingApproval   South Central US
```

Create a new direct peering object

