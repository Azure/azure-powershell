---
external help file: Microsoft.Azure.Commands.Dns.dll-Help.xml
ms.assetid: AD97BCAF-69BA-4C16-8B57-AB243D796B71
online version: 
schema: 2.0.0
---

# New-AzureRmDnsRecordConfig

## SYNOPSIS
Creates a new DNS record local object.

## SYNTAX

### A
```
New-AzureRmDnsRecordConfig -Ipv4Address <String> [<CommonParameters>]
```

### Aaaa
```
New-AzureRmDnsRecordConfig -Ipv6Address <String> [<CommonParameters>]
```

### Ns
```
New-AzureRmDnsRecordConfig -Nsdname <String> [<CommonParameters>]
```

### Mx
```
New-AzureRmDnsRecordConfig -Exchange <String> -Preference <UInt16> [<CommonParameters>]
```

### Ptr
```
New-AzureRmDnsRecordConfig -Ptrdname <String> [<CommonParameters>]
```

### Txt
```
New-AzureRmDnsRecordConfig -Value <String> [<CommonParameters>]
```

### Srv
```
New-AzureRmDnsRecordConfig -Priority <UInt16> -Target <String> -Port <UInt16> -Weight <UInt16>
 [<CommonParameters>]
```

### CName
```
New-AzureRmDnsRecordConfig -Cname <String> [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmDnsRecordConfig** cmdlet creates a local **DnsRecord** object.
An array of these objects is passed to the New-AzureRmDnsRecordSet cmdlet using the *DnsRecords* parameter to specify the records to create in the record set.

## EXAMPLES

### Example 1: Create a RecordSet of type A
```
PS C:\> $Records = @()
PS C:\> $Records += New-AzureRmDnsRecordConfig -IPv4Address 1.2.3.4
PS C:\> $RecordSet = New-AzureRmDnsRecordSet -Name "www" -RecordType A -ResourceGroupName "MyResourceGroup" -TTL 3600 -ZoneName "myzone.com" -DnsRecords $Records

# When creating a RecordSet containing a single record, the above sequence can also be condensed into a single line:

PS C:\> $RecordSet = New-AzureRmDnsRecordSet -Name "www" -RecordType A -ResourceGroupName "MyResourceGroup" -TTL 3600 -ZoneName "myzone.com" -DnsRecords (New-AzureRmDnsRecordConfig -IPv4Address 1.2.3.4)

# To create a record set containing multiple records, use New-AzureRmDnsRecordConfig to add each record to the $Records array,
# then call New-AzureRmDnsRecordSet, as follows:

PS C:\> $Records = @()
PS C:\> $Records += New-AzureRmDnsRecordConfig -IPv4Address 1.2.3.4
PS C:\> $Records += New-AzureRmDnsRecordConfig -IPv4Address 5.6.7.8
PS C:\> $RecordSet = New-AzureRmDnsRecordSet -Name "www" -RecordType A -ResourceGroupName "MyResourceGroup" -TTL 3600 -ZoneName "myzone.com" -DnsRecords $Records
```

This example creates a **RecordSet** named www in the zone myzone.com.
The record set is of type A and has a TTL of 1 hour (3600 seconds).
It contains a single DNS record.

### Example 2: Create a RecordSet of type AAAA
```
PS C:\> $Records = @()
PS C:\> $Records += New-AzureRmDnsRecordConfig -Ipv6Address 2001:db8::1
PS C:\> $RecordSet = New-AzureRmDnsRecordSet -Name "www" -RecordType AAAA -ResourceGroupName "MyResourceGroup" -TTL 3600 -ZoneName "myzone.com" -DnsRecords $Records
```

This example creates a **RecordSet** named www in the zone myzone.com.
The record set is of type AAAA and has a TTL of 1 hour (3600 seconds).
It contains a single DNS record.

To create a **RecordSet** using only one line of pn_PowerShell_short, or to create a record set with multiple records, see Example 1.

### Example 3: Create a RecordSet of type CNAME
```
PS C:\> $Records = @()
PS C:\> $Records += New-AzureRmDnsRecordConfig -Cname www.contoso.com
PS C:\> $RecordSet = New-AzureRmDnsRecordSet -Name "www" -RecordType CNAME -ResourceGroupName "MyResourceGroup" -TTL 3600 -ZoneName "myzone.com" -DnsRecords $Records
```

This example creates a **RecordSet** named www in the zone myzone.com.
The record set is of type CNAME and has a TTL of 1 hour (3600 seconds).
It contains a single DNS record.

To create a **RecordSet** using only one line of pn_PowerShell_short, or to create a record set with multiple records, see Example 1.

### Example 4: Create a RecordSet of type MX
```
PS C:\> $Records = @()
PS C:\> $Records += New-AzureRmDnsRecordConfig -Exchange "mail.microsoft.com" -Preference 5
PS C:\> $RecordSet = New-AzureRmDnsRecordSet -Name "www" -RecordType AAAA -ResourceGroupName "MyResourceGroup" -TTL 3600 -ZoneName "myzone.com" -DnsRecords $Records
```

This command creates a **RecordSet** named www in the zone myzone.com.
The record set is of type MX and has a TTL of 1 hour (3600 seconds).
It contains a single DNS record.

To create a **RecordSet** using only one line of pn_PowerShell_short, or to create a record set with multiple records, see Example 1.

### Example 5: Create a RecordSet of type NS
```
PS C:\> $Records = @()
PS C:\> $Records += New-AzureRmDnsRecordConfig -Nsdname ns1-01.azure-dns.com
PS C:\> $RecordSet = New-AzureRmDnsRecordSet -Name "ns1" -RecordType NS -ResourceGroupName "MyResourceGroup" -TTL 3600 -ZoneName "myzone.com" -DnsRecords $Records
```

This command creates a **RecordSet** named ns1 in the zone myzone.com.
The record set is of type NS and has a TTL of 1 hour (3600 seconds).
It contains a single DNS record.

To create a **RecordSet** using only one line of pn_PowerShell_short, or to create a record set with multiple records, see Example 1.

### Example 6: Create a RecordSet of type PTR
```
PS C:\> $Records = @()
PS C:\> $Records += New-AzureRmDnsRecordConfig -Ptrdname www.contoso.com
PS C:\> $RecordSet = New-AzureRmDnsRecordSet -Name "4" -RecordType PTR -ResourceGroupName "MyResourceGroup" -TTL 3600 -ZoneName "3.2.1.in-addr.arpa" -DnsRecords $Records
```

This command creates a **RecordSet** named 4 in the zone 3.2.1.in-addr.arpa.
The record set is of type PTR and has a TTL of 1 hour (3600 seconds).
It contains a single DNS record.

To create a **RecordSet** using only one line of pn_PowerShell_short, or to create a record set with multiple records, see Example 1.

### Example 7: Create a RecordSet of type SRV
```
PS C:\> $Records = @()
PS C:\> $Records += New-AzureRmDnsRecordConfig -Priority 0 -Weight 5 -Port 8080 -Target sipservice.contoso.com
PS C:\> $RecordSet = New-AzureRmDnsRecordSet -Name "_sip._tcp" -RecordType SRV -ResourceGroupName "MyResourceGroup" -TTL 3600 -ZoneName "myzone.com" -DnsRecords $Records
```

This command creates a **RecordSet** named _sip._tcp in the zone myzone.com.
The record set is of type SRV and has a TTL of 1 hour (3600 seconds).
It contains a single DNS record, pointing to the IP address 2001.2.3.4.

The service (sip) and the protocol (tcp) are specified as part of the record set name, not as part of the record data.

To create a **RecordSet** using only one line of pn_PowerShell_short, or to create a record set with multiple records, see Example 1.

### Example 8: Create a RecordSet of type TXT
```
PS C:\> $Records = @()
PS C:\> $Records += New-AzureRmDnsRecordConfig -Value "This is a TXT Record"
PS C:\> $RecordSet = New-AzureRmDnsRecordSet -Name "text" -RecordType TXT -ResourceGroupName "MyResourceGroup" -TTL 3600 -ZoneName "myzone.com" -DnsRecords $Records
```

This command creates a **RecordSet** named text in the zone myzone.com.
The record set is of type TXT and has a TTL of 1 hour (3600 seconds).
It contains a single DNS record.

To create a **RecordSet** using only one line of pn_PowerShell_short, or to create a record set with multiple records, see Example 1.

## PARAMETERS

### -Cname
Specifies the domain name for a canonical name (CNAME) record.

```yaml
Type: String
Parameter Sets: CName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Exchange
Specifies the mail exchange server name for a mail exchange (MX) record.

```yaml
Type: String
Parameter Sets: Mx
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Ipv4Address
Specifies an IPv4 address for an A record.

```yaml
Type: String
Parameter Sets: A
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Ipv6Address
Specifies an IPv6 address for an AAAA record.

```yaml
Type: String
Parameter Sets: Aaaa
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Nsdname
Specifies the name server name for a name server (NS) record.

```yaml
Type: String
Parameter Sets: Ns
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Port
Specifies the port for a service (SRV) record.

```yaml
Type: UInt16
Parameter Sets: Srv
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Preference
Specifies the preference for an MX record.

```yaml
Type: UInt16
Parameter Sets: Mx
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Priority
Specifies the priority for an SRV record.

```yaml
Type: UInt16
Parameter Sets: Srv
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Ptrdname
Specifies the target domain name of a pointer resource (PTR) record.

```yaml
Type: String
Parameter Sets: Ptr
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Target
Specifies the target for an SRV record.

```yaml
Type: String
Parameter Sets: Srv
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Value
Specifies the value for a TXT record.

```yaml
Type: String
Parameter Sets: Txt
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Weight
Specifies the weight for an SRV record.

```yaml
Type: UInt16
Parameter Sets: Srv
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

### None.

## OUTPUTS

### Microsoft.Azure.Commands.Dns.DnsRecordBase

## NOTES

## RELATED LINKS

[Add-AzureRmDnsRecordConfig](./Add-AzureRmDnsRecordConfig.md)

[New-AzureRmDnsRecordSet](./New-AzureRmDnsRecordSet.md)

[Remove-AzureRmDnsRecordConfig](./Remove-AzureRmDnsRecordConfig.md)
