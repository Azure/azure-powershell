### Example 1: Update registered asn
```powershell
Update-AzPeeringRegisteredAsn -Name TestAsn -PeeringName MapsIxRs -ResourceGroupName MAPSDemo -Asn 65001
```

```output
Name    Asn   PeeringServicePrefixKey              ProvisioningState
----    ---   -----------------------              -----------------
TestAsn 65001 11111111-2222-3333-4444-123456789101 Succeeded
```

Update a new registered asn for a peering
