### Example 1: Get DNSSEC Config for a DNS zone
```powershell
Get-AzDnsDnssecConfig -ResourceGroupName dnssecrg -ZoneName contoso.com
```

```output
Etag                         : 7fbca8a9-849e-48cc-a006-7843bd1e4b7f
Id                           : /subscriptions/a984ce58-225e-44d2-bc79-20a834ce85ae/resourceGroups/dnssecrg/providers/Microsoft.Network/dnszones/contoso.com/dnssecConfigs/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : dnssecrg
SigningKey                   : {{
                                 "delegationSignerInfo": [ ],
                                 "flags": 256,
                                 "keyTag": 28873,
                                 "protocol": 3,
                                 "publicKey": "z3prNmiHWMBN48xIN3E+gGwOZPXTXWSLcrhPHHvqzOwCBD2KmY0MIOzeVBdzQs3tbjXLrbxLUGuVm6eMQJ6hSQ==",
                                 "securityAlgorithmType": 13
                               }, {
                                 "delegationSignerInfo": [
                                   {
                                     "digestAlgorithmType": 2,
                                     "digestValue": "7B0E556C884C2D70B469CC7EBEDF9BF62DE1D6A8F4DFBBB587ADDF1281B93069",
                                     "record": "38205 13 2 7B0E556C884C2D70B469CC7EBEDF9BF62DE1D6A8F4DFBBB587ADDF1281B93069"
                                   }
                                 ],
                                 "flags": 257,
                                 "keyTag": 38205,
                                 "protocol": 3,
                                 "publicKey": "J3Lq9gmCt+JtpOYFt0VfIzYkS8RaB6WTMY3f7mZzmSSLlq3YjoAyXEtY8KRKGNQBhoKS3wwEQqpjD5ryO3HKzw==",
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
