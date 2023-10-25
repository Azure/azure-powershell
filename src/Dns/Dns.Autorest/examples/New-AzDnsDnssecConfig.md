### Example 1: Enable DNSSEC on a DNS zone
```powershell
New-AzDnsDnssecConfig -ResourceGroupName dnssecrg -ZoneName contoso.com
```

```output
Etag                         : 7fbca8a9-849e-48cc-a006-7843bd1e4b7f
Id                           : /subscriptions/a984ce58-225e-44d2-bc79-20a834ce85ae/resourceGroups/dnssecrg/providers/Microsoft.Network/dnszones/contoso.com/dnssecConfigs/default
Name                         : default
ProvisioningState            : Succeeded
SigningKey                   : {z3prNmiHWMBN48xIN3E+gGwOZPXTXWSLcrhPHHvqzOwCBD2KmY0MIOzeVBdzQs3tbjXLrbxLUGuVm6eMQJ6hSQ==, J3Lq9gmCt+JtpOYFt0VfIzYkS8RaB6WTMY3f7mZzmSSLlq3YjoAyXEtY8KRKGNQBhoKS3wwEQqpjD5ryO3HKzw==}
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Network/dnszones/dnssecConfigs
```

This command enables DNSSEC on an existing DNS zone.
