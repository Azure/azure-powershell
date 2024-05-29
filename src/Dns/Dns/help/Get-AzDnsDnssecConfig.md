---
external help file: Az.Dns-help.xml
Module Name: Az.Dns
online version: https://learn.microsoft.com/powershell/module/az.dns/get-azdnsdnssecconfig
schema: 2.0.0
---

# Get-AzDnsDnssecConfig

## SYNOPSIS
Gets the DNSSEC configuration.

## SYNTAX

### Get (Default)
```
Get-AzDnsDnssecConfig -ResourceGroupName <String> [-SubscriptionId <String[]>] -ZoneName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDnsDnssecConfig -ResourceGroupName <String> [-SubscriptionId <String[]>] -ZoneName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDnsDnssecConfig -InputObject <IDnsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the DNSSEC configuration.

## EXAMPLES

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

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.IDnsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -ZoneName
The name of the DNS zone (without a terminating dot).

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.IDnsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20230701Preview.IDnssecConfig

## NOTES

## RELATED LINKS
