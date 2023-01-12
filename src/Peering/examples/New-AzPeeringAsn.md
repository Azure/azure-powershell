### Example 1: Create a new peering asn
```powershell
New-AzPeeringAsn -Name PsTestAsn -PeerAsn 65001 -PeerContactDetail $PeerContactList -PeerName DemoPeering
```

```output
Name      PeerName    PropertiesPeerAsn ValidationState PeerContactDetail
----      --------    ----------------- --------------- -----------------
PsTestAsn DemoPeering 65001             Pending         {{…
```

Create a new peering asn with the specified properties

