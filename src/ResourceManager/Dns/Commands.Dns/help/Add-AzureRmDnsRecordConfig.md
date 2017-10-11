---
external help file: Microsoft.Azure.Commands.Dns.dll-Help.xml
ms.assetid: CD119EBE-E1A4-4E9D-B3BA-FDAF89BF0DDB
online version: 
schema: 2.0.0
---

# Add-AzureRmDnsRecordConfig

## SYNOPSIS
Adds a DNS record to a local record set object.

## SYNTAX

### A
```
Add-AzureRmDnsRecordConfig -RecordSet <DnsRecordSet> -Ipv4Address <String> [<CommonParameters>]
```

### AAAA
```
Add-AzureRmDnsRecordConfig -RecordSet <DnsRecordSet> -Ipv6Address <String> [<CommonParameters>]
```

### NS
```
Add-AzureRmDnsRecordConfig -RecordSet <DnsRecordSet> -Nsdname <String> [<CommonParameters>]
```

### MX
```
Add-AzureRmDnsRecordConfig -RecordSet <DnsRecordSet> -Exchange <String> -Preference <UInt16>
 [<CommonParameters>]
```

### PTR
```
Add-AzureRmDnsRecordConfig -RecordSet <DnsRecordSet> -Ptrdname <String> [<CommonParameters>]
```

### TXT
```
Add-AzureRmDnsRecordConfig -RecordSet <DnsRecordSet> -Value <String> [<CommonParameters>]
```

### SRV
```
Add-AzureRmDnsRecordConfig -RecordSet <DnsRecordSet> -Priority <UInt16> -Target <String> -Port <UInt16>
 -Weight <UInt16> [<CommonParameters>]
```

### CNAME
```
Add-AzureRmDnsRecordConfig -RecordSet <DnsRecordSet> -Cname <String> [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmDnsRecordConfig** cmdlet adds a Domain Name System (DNS) record to a **RecordSet** object.
The **RecordSet** object is an offline object, and changes to it do not change the DNS responses until after you run the Set-AzureRmDnsRecordSet cmdlet to persist the change to the Microsoft Azure DNS service.

SOA records are created when a DNS zone is created, and are removed when the DNS zone is deleted.
You cannot add or remove SOA records, but you can edit them.

You can pass the **RecordSet** object to this cmdlet as a parameter or by using the pipeline operator.

## EXAMPLES

### Example 1: Add an A record to a record set
```
PS C:\> $RecordSet = Get-AzureRmDnsRecordSet -Name www -RecordType A -ResouceGroupName MyResourceGroup -ZoneName myzone.com
PS C:\> Add-AzureRmDnsRecordConfig -RecordSet $RecordSet -Ipv4Address 1.2.3.4
PS C:\> Set-AzureRmDnsRecordSet -RecordSet $RecordSet

# You can also pipe the above sequence:

PS C:\> Get-AzureRmDnsRecordSet -Name www -RecordType A -ResouceGroupName MyResourceGroup -ZoneName myzone.com | Add-AzureRmDnsRecordConfig -Ipv4Address 1.2.3.4 | Set-AzureRmDnsRecordSet
```

This example adds an A record to an existing record set.

### Example 2: Add an AAAA record to a record set
```
PS C:\> $RecordSet = Get-AzureRmDnsRecordSet -Name www -RecordType AAAA -ResouceGroupName MyResourceGroup -ZoneName myzone.com
PS C:\> Add-AzureRmDnsRecordConfig -RecordSet $RecordSet -Ipv6Address 2001:DB80:4009:1803::1005
PS C:\> Set-AzureRmDnsRecordSet -RecordSet $RecordSet

# You can also pipe the above sequence:

PS C:\> Get-AzureRmDnsRecordSet -Name www -RecordType AAAA -ResouceGroupName MyResourceGroup -ZoneName myzone.com | Add-AzureRmDnsRecordConfig -Ipv6Address 2001:DB80:4009:1803::1005 | Set-AzureRmDnsRecordSet
```

This example adds an AAAA record to an existing record set.

### Example 3: Add a CNAME record to a record set
```
PS C:\>$RecordSet = Get-AzureRmDnsRecordSet -Name www -RecordType CNAME -ResouceGroupName MyResourceGroup -ZoneName myzone.com
PS C:\> Add-AzureRmDnsRecordConfig -RecordSet $RecordSet -Cname contoso.com
PS C:\> Set-AzureRmDnsRecordSet -RecordSet $RecordSet

# You can also pipe the above sequence:

PS C:\> Get-AzureRmDnsRecordSet -Name www -RecordType CNAME -ResouceGroupName MyResourceGroup -ZoneName myzone.com | Add-AzureRmDnsRecordConfig -Cname contoso.com | Set-AzureRmDnsRecordSet
```

This example adds a CNAME record to an existing record set.
Because a CNAME record set can contain at most one record, it must initially be an empty record set, or existing records must be removed using Remove-AzureRmDnsRecordConfig.

### Example 4: Add an MX record to a record set
```
PS C:\> $RecordSet = Get-AzureRmDnsRecordSet -Name "@" -RecordType MX -ResouceGroupName MyResourceGroup -ZoneName myzone.com
PS C:\> Add-AzureRmDnsRecordConfig -Exchange mail.microsoft.com -Preference 5 -RecordSet $RecordSet
PS C:\> Set-AzureRmDnsRecordSet -RecordSet $RecordSet

# You can also pipe the above sequence:

PS C:\> Get-AzureRmDnsRecordSet -Name "@" -RecordType MX -ResouceGroupName MyResourceGroup -ZoneName myzone.com | Add-AzureRmDnsRecordConfig -Exchange mail.microsoft.com -Preference 5 | Set-AzureRmDnsRecordSet
```

This example adds an MX record to an existing record set.
The record name "@" indicates a record set at the zone apex.

### Example 5: Add an NS record to a record set
```
PS C:\>$RecordSet = Get-AzureRmDnsRecordSet -Name abc -RecordType NS -ResouceGroupName MyResourceGroup -ZoneName myzone.com
PS C:\> Add-AzureRmDnsRecordConfig -Nsdname ns1.myzone.com -RecordSet $RecordSet
PS C:\> Set-AzureRmDnsRecordSet -RecordSet $RecordSet

# You can also pipe the above sequence:

PS C:\> Get-AzureRmDnsRecordSet -Name abc -RecordType NS -ResouceGroupName MyResourceGroup -ZoneName myzone.com | Add-AzureRmDnsRecordConfig -Nsdname ns1.myzone.com | Set-AzureRmDnsRecordSet
```

This example adds an NS record to an existing record set.

### Example 6: Add a PTR record to a record set
```
PS C:\>$RecordSet = Get-AzureRmDnsRecordSet -Name 4 -RecordType PTR -ResouceGroupName MyResourceGroup -ZoneName 3.2.1.in-addr.arpa
PS C:\> Add-AzureRmDnsRecordConfig -Ptrdname www.contoso.com -RecordSet $RecordSet
PS C:\> Set-AzureRmDnsRecordSet -RecordSet $RecordSet

# The above sequence can also be piped:

PS C:\> Get-AzureRmDnsRecordSet -Name 4 -RecordType PTR -ResouceGroupName MyResourceGroup -ZoneName 3.2.1.in-addr.arpa | Add-AzureRmDnsRecordConfig -Ptrdname www.contoso.com | Set-AzureRmDnsRecordSet
```

This example adds a PTR record to an existing record set.

### Example 7: Add an SRV record to a record set
```
PS C:\>$RecordSet = Get-AzureRmDnsRecordSet -Name _sip._tcp -RecordType SRV -ResouceGroupName MyResourceGroup -ZoneName myzone.com
PS C:\> Add-AzureRmDnsRecordConfig -RecordSet $RecordSet -Priority 0 -Weight 5 -Port 8080 -Target target.example.com
PS C:\> Set-AzureRmDnsRecordSet -RecordSet $RecordSet

# The above sequence can also be piped:

PS C:\> Get-AzureRmDnsRecordSet -Name _sip._tcp -RecordType SRV -ResouceGroupName MyResourceGroup -ZoneName myzone.com | Add-AzureRmDnsRecordConfig -Priority 0 -Weight 5 -Port 8080 -Target target.example.com  | Set-AzureRmDnsRecordSet
```

This example adds an SRV record to an existing record set.

### Example 8: Add a TXT record to a record set
```
PS C:\>$RecordSet = Get-AzureRmDnsRecordSet -Name text -RecordType TXT -ResouceGroupName MyResourceGroup -ZoneName myzone.com
PS C:\> Add-AzureRmDnsRecordConfig -RecordSet $RecordSet -Value "This is a TXT Record"
PS C:\> Set-AzureRmDnsRecordSet -RecordSet $RecordSet

# The above sequence can also be piped:

PS C:\> Get-AzureRmDnsRecordSet -Name text -RecordType TXT -ResouceGroupName MyResourceGroup -ZoneName myzone.com | Add-AzureRmDnsRecordConfig -Value "This is a TXT Record" | Set-AzureRmDnsRecordSet
```

This example adds a TXT record to an existing record set.

## PARAMETERS

### -Cname
Specifies the domain name for a canonical name (CNAME) record.

```yaml
Type: String
Parameter Sets: CNAME
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
Parameter Sets: MX
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
Parameter Sets: AAAA
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
Parameter Sets: NS
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
Parameter Sets: SRV
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
Parameter Sets: MX
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
Parameter Sets: SRV
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
Parameter Sets: PTR
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RecordSet
Specifies the **RecordSet** object to edit.

```yaml
Type: DnsRecordSet
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Target
Specifies the target for an SRV record.

```yaml
Type: String
Parameter Sets: SRV
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
Parameter Sets: TXT
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
Parameter Sets: SRV
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

### Microsoft.Azure.Commands.Dns.DnsRecordSet
You can pipe a **RecordSet** object to this cmdlet.
This is an offline representation of the **RecordSet**, and changes to it do not change DNS responses until after you run the Set-AzureRmDnsRecordSet cmdlet.

## OUTPUTS

### Microsoft.Azure.Commands.Dns.DnsRecordSet
This cmdlet returns the modified **RecordSet** object.
In addition, the object passed in is modified directly.

## NOTES

## RELATED LINKS

[Get-AzureRmDnsRecordSet](./Get-AzureRmDnsRecordSet.md)

[Remove-AzureRmDnsRecordConfig](./Remove-AzureRmDnsRecordConfig.md)

[Set-AzureRmDnsRecordSet](./Set-AzureRmDnsRecordSet.md)
