### Example 1: Create an exchange connection object
```powershell
New-AzPeeringExchangeConnectionObject -BgpSessionMaxPrefixesAdvertisedV4 20000 -BgpSessionMaxPrefixesAdvertisedV6 0 -BgpSessionMd5AuthenticationKey $md5Key -BgpSessionMicrosoftSessionIPv4Address 1.1.1.1 -BgpSessionPeerSessionIPv4Address 1.1.1.0 -BgpSessionPrefixV4 1.1.1.1/31 -PeeringDbFacilityId 82 -ConnectionIdentifier c111111111111
```

```output
ConnectionIdentifier ConnectionState ErrorMessage PeeringDbFacilityId ... [more fields]
-------------------- --------------- ------------ ------------------- ... -------------
c111111111111                                     82
```

Create a exchange connection object in memory

