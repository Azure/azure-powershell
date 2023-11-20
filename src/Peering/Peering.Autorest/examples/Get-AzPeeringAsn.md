### Example 1: List PeerAsns
```powershell
Get-AzPeeringAsn
```

```output
Name            PeerName PropertiesPeerAsn ValidationState PeerContactDetail
----            -------- ----------------- --------------- -----------------
ContosoEdgeTest Contoso  65000             Approved        {{…}}

```

List all the peer asns under subscription

### Example 2: Get Specific PeerAsn
```powershell
Get-AzPeeringAsn -Name ContosoEdgeTest
```

```output
Name            PeerName PropertiesPeerAsn ValidationState PeerContactDetail
----            -------- ----------------- --------------- -----------------
ContosoEdgeTest Contoso  65000             Approved        {{…}}
```

Get peer asn by name