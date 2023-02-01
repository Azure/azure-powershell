### Example 1: Create a direct connection object
```powershell
New-AzPeeringDirectConnectionObject -BandwidthInMbps 10000 -BgpSessionMaxPrefixesAdvertisedV4 20000 -BgpSessionMaxPrefixesAdvertisedV6 0 -BgpSessionMd5AuthenticationKey $md5Key -BgpSessionMicrosoftSessionIPv4Address 1.1.1.1 -BgpSessionPeerSessionIPv4Address 1.1.1.0 -BgpSessionPrefixV4 1.1.1.1/31 -PeeringDbFacilityId 82 -SessionAddressProvider Peer -ConnectionIdentifier c111111111111
```

```output
BandwidthInMbps ConnectionIdentifier ConnectionState ErrorMessage MicrosoftTrackingId PeeringDbFacilityId ProvisionedBandwidthInMbps ... [more fields]
--------------- -------------------- --------------- ------------ ------------------- ------------------- -------------------------- ... -------------
10000           c111111111111        PendingApproval                                  82

```

Creates an in-memory direct connection object

