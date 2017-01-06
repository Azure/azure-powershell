---
external help file: Microsoft.Azure.Commands.Dns.dll-Help.xml
ms.assetid: 45DF71E0-77E1-4D20-AD09-2C06680F659F
online version:
schema: 2.0.0
---

# New-AzureRmDnsRecordSet

## SYNOPSIS
Creates a DNS record set.

## SYNTAX

### Fields
```
New-AzureRmDnsRecordSet -Name <String> -ZoneName <String> -ResourceGroupName <String> -Ttl <UInt32>
 -RecordType <RecordType> [-Metadata <Hashtable>] [-DnsRecords <DnsRecordBase[]>] [-Overwrite] [-Force]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Object
```
New-AzureRmDnsRecordSet -Name <String> -Zone <DnsZone> -Ttl <UInt32> -RecordType <RecordType>
 [-Metadata <Hashtable>] [-DnsRecords <DnsRecordBase[]>] [-Overwrite] [-Force] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmDnsRecordSet** cmdlet creates a new Domain Name System (DNS) record set with the specified name and type in the specified zone.
A **RecordSet** object is a set of DNS records with the same name and type.
Note that the name is relative to the zone and not the fully qualified name.

The *DnsRecords* parameter specifies the records in the record set.
This parameter takes an array of DNS records, constructed using New-AzureRmDnsRecordConfig.

You can use the pipeline operator to pass a **DnsZone** object to this cmdlet, or you can pass a **DnsZone** object as the *Zone* parameter, or alternatively you can specify the zone by name.

You can use the *Confirm* parameter and $ConfirmPreference Windows PowerShell variable to control whether the cmdlet prompts you for confirmation.

If a matching **RecordSet** already exists (same name and record type), you must specify the *Overwrite* parameter, otherwise the cmdlet will not create a new **RecordSet** .

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

### Example 9: Create a RecordSet at the zone apex
```
PS C:\> $Records = @()
PS C:\> $Records += New-AzureRmDnsRecordConfig -Ipv4Address 1.2.3.4
PS C:\> $RecordSet = New-AzureRmDnsRecordSet -Name "@" -RecordType A -ResourceGroupName "MyResourceGroup" -TTL 3600 -ZoneName "myzone.com" -DnsRecords $Records
```

This command creates a **RecordSet** at the apex (or root) of the zone myzone.com.
To do this, the record set name is specified as "@" (including the double-quotes).

You cannot create CNAME records at the apex of a zone.
This is a constraint of the DNS standards; it is not a limitation of Azure DNS.

To create a **RecordSet** using only one line of pn_PowerShell_short, or to create a record set with multiple records, see Example 1.

### Example 10: Create a wildcard Record Set
```
PS C:\> $Records = @()
PS C:\> $Records += New-AzureRmDnsRecordConfig -Ipv4Address 1.2.3.4
PS C:\> $RecordSet = New-AzureRmDnsRecordSet -Name "*" -RecordType A -ResourceGroupName "MyResourceGroup" -TTL 3600 -ZoneName "myzone.com" -DnsRecords $Records
```

This command creates a **RecordSet** named * in the zone myzone.com.
This is a wildcard record set.

To create a **RecordSet** using only one line of pn_PowerShell_short, or to create a record set with multiple records, see Example 1.

### Example 11: Create an empty record set
```
PS C:\>$RecordSet = New-AzureRmDnsRecordSet -Name "www" -RecordType A -ResourceGroupName "MyResourceGroup" -TTL 3600 -ZoneName "myzone.com" -DnsRecords @()
```

This command creates a **RecordSet** named www in the zone myzone.com.
The record set is of type A and has a TTL of 1 hour (3600 seconds).
This is an empty record set, which acts as a placeholder to which you can later add records.

### Example 12: Create a record set and suppress all confirmation
```
PS C:\>$RecordSet = New-AzureRmDnsRecordSet -Name "www" -RecordType A -ResourceGroupName "MyResourceGroup" -TTL 3600 -ZoneName "myzone.com" -DnsRecords (New-AzureRmDnsRecordConfig -Ipv4Address 1.2.3.4) -Confirm:$False -Overwrite
```

This command creates a **RecordSet**.
The *Overwrite* parameter ensures that this record set overwrites any pre-existing record set with the same name and type (existing records in that record set are lost).
The *Confirm* parameter with a value of $False suppresses the confirmation prompt.

## PARAMETERS

### -DnsRecords
Specifies the array of DNS records to include in the record set.
You can use the New-AzureRmDnsRecordConfig cmdlet to create DNS record objects.
See the examples for more information.

```yaml
Type: DnsRecordBase[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Force
This parameter is deprecated for this cmdlet.
It will be removed in a future release.

To control whether this cmdlet prompts you for comfirmation, use the *Confirm* parameter.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
Specifies an array of metadata to associate with the RecordSet.
Metadata is specified using name-value pairs that are represented as hash tables, for example @(@{"Name"="dept"; "Value"="shopping"}, @{"Name"="env"; "Value"="production"}).

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the **RecordSet** to create.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Overwrite
Indicates that this cmdlet overwrites the specified **RecordSet** if it already exists.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecordType
Specifies the type of DNS record to create.

Valid values are:

- A
- AAAA
- CNAME
- MX
- NS
- PTR
- SRV
- TXT

SOA records are created automatically when the zone is created and cannot be created manually.

```yaml
Type: RecordType
Parameter Sets: (All)
Aliases:
Accepted values: A, AAAA, CNAME, MX, NS, PTR, SOA, SRV, TXT

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the resource group that contains the DNS zone.
You must also specify the *ZoneName* parameter to specify the zone name.

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

### -Ttl
Specifies the Time to Live (TTL) for the DNS RecordSet.

```yaml
Type: UInt32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Zone
Specifies the DnsZone in which to create the **RecordSet**.
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
Specifies the name of the zone in which to create the **RecordSet**.
You must also specify the resource group containing the zone using the *ResourceGroupName* parameter.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Dns.DnsZone
You can pipe a DnsZone object to this cmdlet.

## OUTPUTS

### Microsoft.Azure.Commands.Dns.DnsRecordSet
This cmdlet returns a **RecordSet** object.

## NOTES
You can use the *Confirm* parameter to control whether this cmdlet prompts you for confirmation.
By default, the cmdlet prompts you for confirmation if the $ConfirmPreference Windows PowerShell variable has a value of Medium or lower.

If you specify *Confirm* or *Confirm:$True*, this cmdlet prompts you for confirmation before it runs.
If you specify *Confirm:$False*, the cmdlet does not prompt you for confirmation.

## RELATED LINKS

[Add-AzureRmDnsRecordConfig](./Add-AzureRmDnsRecordConfig.md)

[Get-AzureRmDnsRecordSet](./Get-AzureRmDnsRecordSet.md)

[New-AzureRmDnsRecordConfig](./New-AzureRmDnsRecordConfig.md)

[Remove-AzureRmDnsRecordSet](./Remove-AzureRmDnsRecordSet.md)

[Set-AzureRmDnsRecordSet](./Set-AzureRmDnsRecordSet.md)
