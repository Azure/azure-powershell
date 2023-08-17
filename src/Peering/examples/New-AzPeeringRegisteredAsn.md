### Example 1: Create registered asn
```powershell
New-AzPeeringRegisteredAsn -Name TestAsn -PeeringName MapsIxRs -ResourceGroupName MAPSDemo -Asn 65001
```

```output
Name    Asn   PeeringServicePrefixKey              ProvisioningState
----    ---   -----------------------              -----------------
TestAsn 65001 45a8db73-4b7c-4800-bb0f-d304a747d6f1 Succeeded
```

Create a new registered asn for a peering
