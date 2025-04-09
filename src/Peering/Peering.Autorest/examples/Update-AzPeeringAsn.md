### Example 1: Update a new peering asn
```powershell
$contactDetail = New-AzPeeringContactDetailObject -Email "abc@xyz.com" -Phone 1234567890 -Role "Noc"
$PeerContactList = ,$contactDetail
Update-AzPeeringAsn -Name PsTestAsn -PeerAsn 65001 -PeerContactDetail $PeerContactList -PeerName DemoPeering
```

```output
Name      PeerName    PropertiesPeerAsn ValidationState PeerContactDetail
----      --------    ----------------- --------------- -----------------
PsTestAsn DemoPeering 65001             Pending         {{…
```

Update a new peering asn with the specified properties