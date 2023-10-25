### Example 1: Get DNSSEC Config for a DNS zone
```powershell
Get-AzDnsDnssecConfig -ResourceGroupName dnssecrg -ZoneName contoso.com
```

```output
Etag                         : 2b10a5b5-545e-474c-a6c6-0319afceceeb
Id                           : /subscriptions/a984ce58-225e-44d2-bc79-20a834ce85ae/resourceGroups/dnssecrg/providers/Microsoft.Network/dnszones/contoso.com/dnssecConfigs/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : dnssecrg
SigningKey                   : {{
                                 "delegationSignerInfo": [ ],
                                 "flags": 256,
                                 "keyTag": 30691,
                                 "protocol": 3,
                                 "publicKey": "jVHBGRT2BKqodnvahpDwIURQO81iBBFdTQXyhs2drI/2KH+cGR4R46XgMXRR0jy7uGds6jiYc3WVkaiP2GnU+g==",
                                 "securityAlgorithmType": 13
                               }, {
                                 "delegationSignerInfo": [
                                   {
                                     "digestAlgorithmType": 2,
                                     "digestValue": "2B3958FECB82F082239E410E0051AB200AB003F526CDC8EFFAD2201284654C60",
                                     "record": "32924 13 2 2B3958FECB82F082239E410E0051AB200AB003F526CDC8EFFAD2201284654C60"
                                   }
                                 ],
                                 "flags": 257,
                                 "keyTag": 32924,
                                 "protocol": 3,
                                 "publicKey": "6i4wClDOy6+/MAI/ILCJ0nyHBQYJ0zSuiagOqEHUHl464dB24aXJBI3UCMS6mttLZnqkcptihkWkn2wHaYqYCg==",
                                 "securityAlgorithmType": 13
                               }}
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Network/dnszones/dnssecConfigs
```

This command gets the DNSSEC config for a DNS zone.
