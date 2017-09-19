---
external help file: Microsoft.Azure.Commands.Dns.dll-Help.xml
ms.assetid: 40179CF3-7896-4C45-BC18-4CB653B245B6
online version: 
schema: 2.0.0
---

# Get-AzureRmDnsRecordSet

## SYNOPSIS
Gets a DNS record set.

## SYNTAX

### Fields
```
Get-AzureRmDnsRecordSet [-Name <String>] -ZoneName <String> -ResourceGroupName <String>
 [-RecordType <RecordType>] [<CommonParameters>]
```

### Object
```
Get-AzureRmDnsRecordSet [-Name <String>] -Zone <DnsZone> [-RecordType <RecordType>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmDnsRecordSet** cmdlet gets the Domain Name System (DNS) record set with the specified name and type, in the specified zone.

If you do not specify the *Name* or *RecordType* parameters, this cmdlet returns all record sets of the specified type in the zone.
If you specify the *RecordType* parameter but not the *Name* parameter, this cmdlet returns all record sets of the specified record type.

You can use the pipeline operator to pass a **DnsZone** object to this cmdlet, or you can pass a **DnsZone** object as the *Zone* parameter, or alternatively you can specify the zone and resource group by name.

## EXAMPLES

### Example 1: Get record sets with a specified name and type
```
PS C:\>$RecordSet = Get-AzureRmDnsRecordSet -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com" -Name "www" -RecordType A
```

This command gets the record set of record type A named www in the specified resource group and zone, and then stores it in the $RecordSet variable.
Because the *Name* and *RecordType* parameters are specified, only one **RecordSet** object is returned.

### Example 2: Get record sets of a specified type
```
PS C:\>$RecordSets = Get-AzureRmDnsRecordSet -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com" -RecordType A
```

This command gets an array of all record sets of record type A in the zone named myzone.com in the resource group named MyResourceGroup, and then stores them in the $RecordSets variable.

### Example 3: Get all record sets in a zone
```
PS C:\>$RecordSets = Get-AzureRmDnsRecordSet -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com"
```

This command gets an array of all record sets in the zone named myzone.com in the resource group named MyResourceGroup, and then stores them in the $RecordSets variable.

### Example 4: Get all record sets in a zone, using a DnsZone object
```
PS C:\> $Zone = Get-AzureRmDnsZone -Name "myzone.com" -ResourceGroupName "MyResourceGroup"
PS C:\> $RecordSets = Get-AzureRmDnsRecordSet -Zone $Zone
```

This example is equivalent to Example 3 above.
This time, the zone is specified using a zone object.

## PARAMETERS

### -Name
Specifies the name of the **RecordSet** to get.
If you do not specify the *Name* parameter, all record sets of the specified type are returned.

```yaml
Type: String
Parameter Sets: Fields
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: Object
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RecordType
Specifies the type of DNS record that this cmdlet gets.

Valid values are: 

- A
- AAAA
- CNAME
- MX
- NS
- PTR
- SOA
- SRV
- TXT

If you do not specify the *RecordType* parameter, you must also omit the *Name* parameter. 
This cmdlet then returns all record sets in the zone (of all names and types).

```yaml
Type: RecordType
Parameter Sets: (All)
Aliases: 
Accepted values: A, AAAA, CNAME, MX, NS, PTR, SOA, SRV, TXT

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the resource group that contains the DNS zone.
The zone name must also be specified, using the *ZoneName* parameter.

Alternatively, you can specify the zone and resource group by passing in a **DnsZone** object using the *Zone* parameter.

```yaml
Type: String
Parameter Sets: Fields
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Zone
Specifies the DNS zone that contains the record set that this cmdlet gets.
Alternatively, you can specify the zone using the *ZoneName* and *ResourceGroupName* parameters.

```yaml
Type: DnsZone
Parameter Sets: Object
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ZoneName
Specifies the name of the DNS zone that contains the record set to get.
The resource group containing the zone must also be specified, using the *ResourceGroupName* parameter.

Alternatively, you can specify the zone and resource group by passing in a DNS Zone object using the *Zone* parameter.

```yaml
Type: String
Parameter Sets: Fields
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Dns.DnsZone
You can pipe a **DnsZone** object to this cmdlet.
The **DnsZone** object represents the zone in which to look for the **RecordSet** object.

## OUTPUTS

### Microsoft.Azure.Commands.Dns.DnsRecordSet
This cmdlet returns one or more objects that represents the record sets that are found.
There will be at most one **RecordSet** returned if the *Name* and *RecordType* parameters are specified, otherwise multiple **RecordSet** objects are returned as an array.

## NOTES

## RELATED LINKS

[New-AzureRmDnsRecordSet](./New-AzureRmDnsRecordSet.md)

[Remove-AzureRmDnsRecordSet](./Remove-AzureRmDnsRecordSet.md)

[Set-AzureRmDnsRecordSet](./Set-AzureRmDnsRecordSet.md)


