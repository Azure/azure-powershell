---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Dns.dll-Help.xml
Module Name: Az.Dns
ms.assetid: D1A2326C-CD41-45A6-B37A-FC6176193B01
online version: https://learn.microsoft.com/powershell/module/az.dns/remove-azdnsrecordconfig
schema: 2.0.0
---

# Remove-AzDnsRecordConfig

## SYNOPSIS
Removes a DNS record from a local record set object.

## SYNTAX

### A
```
Remove-AzDnsRecordConfig -RecordSet <DnsRecordSet> -Ipv4Address <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AAAA
```
Remove-AzDnsRecordConfig -RecordSet <DnsRecordSet> -Ipv6Address <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### NS
```
Remove-AzDnsRecordConfig -RecordSet <DnsRecordSet> -Nsdname <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### MX
```
Remove-AzDnsRecordConfig -RecordSet <DnsRecordSet> -Exchange <String> -Preference <UInt16>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### PTR
```
Remove-AzDnsRecordConfig -RecordSet <DnsRecordSet> -Ptrdname <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### TXT
```
Remove-AzDnsRecordConfig -RecordSet <DnsRecordSet> -Value <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### SRV
```
Remove-AzDnsRecordConfig -RecordSet <DnsRecordSet> -Priority <UInt16> -Target <String> -Port <UInt16>
 -Weight <UInt16> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### CNAME
```
Remove-AzDnsRecordConfig -RecordSet <DnsRecordSet> -Cname <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### Caa
```
Remove-AzDnsRecordConfig -RecordSet <DnsRecordSet> -CaaFlags <Byte> -CaaTag <String> -CaaValue <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DS
```
Remove-AzDnsRecordConfig -RecordSet <DnsRecordSet> -KeyTag <Int32> -Algorithm <Int32> -DigestType <Int32>
 -Digest <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### TLSA
```
Remove-AzDnsRecordConfig -RecordSet <DnsRecordSet> -Usage <Int32> -Selector <Int32> -MatchingType <Int32>
 -CertificateAssociationData <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzDnsRecordConfig** cmdlet removes a Domain Name System (DNS) record from a record set.
The **RecordSet** object is an offline object, and changes to it do not change the DNS responses until after you run the Set-AzDnsRecordSet cmdlet to persist the change to the Microsoft Azure DNS service.
To remove a record, all the fields for that record type must match exactly.
You cannot add or remove SOA records.
SOA records are automatically created when a DNS zone is created and automatically deleted when the DNS zone is deleted.
You can pass the **RecordSet** object to this cmdlet as a parameter or by using the pipeline operator.

## EXAMPLES

### Example 1: Remove an A record from a record set
```powershell
$RecordSet = Get-AzDnsRecordSet -Name "www" -RecordType A -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com"
Remove-AzDnsRecordConfig -RecordSet $RecordSet -Ipv4Address 1.2.3.4
Set-AzDnsRecordSet -RecordSet $RecordSet

# The above sequence can also be piped:

Get-AzDnsRecordSet -Name "www" -RecordType A -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com" | Remove-AzDnsRecordConfig -Ipv4Address 1.2.3.4 | Set-AzDnsRecordSet
```

This example removes an A record from an existing record set.
If this is the only record in the record set, the result will be an empty record set.
To remove a record set entirely, see Remove-AzDnsRecordSet.

### Example 2: Remove an AAAA record from a record set
```powershell
$RecordSet = Get-AzDnsRecordSet -Name "www" -RecordType AAAA -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com"
Remove-AzDnsRecordConfig -RecordSet $RecordSet -Ipv6Address 2001:DB80:4009:1803::1005
Set-AzDnsRecordSet -RecordSet $RecordSet

# The above sequence can also be piped:

Get-AzDnsRecordSet -Name "www" -RecordType AAAA -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com" | Remove-AzDnsRecordConfig -Ipv6Address 2001:DB80:4009:1803::1005 | Set-AzDnsRecordSet
```

This example removes an AAAA record from an existing record set.
If this is the only record in the record set, the result will be an empty record set.
To remove a record set entirely, see Remove-AzDnsRecordSet.

### Example 3: Remove a CNAME record from a record set
```powershell
$RecordSet = Get-AzDnsRecordSet -Name "www" -RecordType CNAME -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com"
Remove-AzDnsRecordConfig -RecordSet $RecordSet -Cname contoso.com
Set-AzDnsRecordSet -RecordSet $RecordSet

# The above sequence can also be piped:

Get-AzDnsRecordSet -Name "www" -RecordType CNAME -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com" | Remove-AzDnsRecordConfig -Cname contoso.com | Set-AzDnsRecordSet
```

This example removes a CNAME record from an existing record set.
Because a CNAME record set can contain at most one record, the result is an empty record set.

### Example 4: Remove an MX record from a record set
```powershell
$RecordSet = Get-AzDnsRecordSet -Name "@" -RecordType MX -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com"
Remove-AzDnsRecordConfig -Exchange mail.microsoft.com -Preference 5 -RecordSet $RecordSet
Set-AzDnsRecordSet -RecordSet $RecordSet

# The above sequence can also be piped:

Get-AzDnsRecordSet -Name "@" -RecordType MX -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com" | Remove-AzDnsRecordConfig -Exchange mail.microsoft.com -Preference 5 | Set-AzDnsRecordSet
```

This example removes an MX record from an existing record set.
The record name "@" indicates a record set at the zone apex.
If this is the only record in the record set, the result is an empty record set.
To remove a record set entirely, see Remove-AzDnsRecordSet.

### Example 5: Remove an NS record from a record set
```powershell
$RecordSet = Get-AzDnsRecordSet -Name "abc" -RecordType NS -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com"
Remove-AzDnsRecordConfig -Nsdname ns1.myzone.com -RecordSet $RecordSet
Set-AzDnsRecordSet -RecordSet $RecordSet

# The above sequence can also be piped:

Get-AzDnsRecordSet -Name "abc" -RecordType NS -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com" | Remove-AzDnsRecordConfig -Nsdname "ns1.myzone.com" | Set-AzDnsRecordSet
```

This example removes an NS record from an existing record set.
If this is the only record in the record set, the result is an empty record set.
To remove a record set entirely, see Remove-AzDnsRecordSet.

### Example 6: Remove a PTR record from a record set
```powershell
$RecordSet = Get-AzDnsRecordSet -Name "4" -RecordType PTR -ResourceGroupName "MyResourceGroup" -ZoneName 3.2.1.in-addr.arpa
Remove-AzDnsRecordConfig -Ptrdname www.contoso.com -RecordSet $RecordSet
Set-AzDnsRecordSet -RecordSet $RecordSet

# The above sequence can also be piped:

Get-AzDnsRecordSet -Name "4" -RecordType PTR -ResourceGroupName "MyResourceGroup" -ZoneName "3.2.1.in-addr.arpa" | Remove-AzDnsRecordConfig -Ptrdname www.contoso.com | Set-AzDnsRecordSet
```

This example removes a PTR record from an existing record set.
If this is the only record in the record set, the result is an empty record set.
To remove a record set entirely, see Remove-AzDnsRecordSet.

### Example 7: Remove an SRV record from a record set
```powershell
$RecordSet = Get-AzDnsRecordSet -Name "_sip._tcp" -RecordType SRV -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com"
Remove-AzDnsRecordConfig -RecordSet $RecordSet -Priority 0 -Weight 5 -Port 8080 -Target target.example.com
Set-AzDnsRecordSet -RecordSet $RecordSet

# The above sequence can also be piped:

Get-AzDnsRecordSet -Name "_sip._tcp" -RecordType SRV -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com" | Remove-AzDnsRecordConfig -Priority 0 -Weight 5 -Port 8080 -Target target.example.com  | Set-AzDnsRecordSet
```

This example removes an SRV record from an existing record set.
If this is the only record in the record set, the result is an empty record set.
To remove a record set entirely, see Remove-AzDnsRecordSet.

### Example 8: Remove a TXT record from a record set
```powershell
$RecordSet = Get-AzDnsRecordSet -Name "text" -RecordType TXT -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com"
Remove-AzDnsRecordConfig -RecordSet $RecordSet -Value "This is a TXT Record"
Set-AzDnsRecordSet -RecordSet $RecordSet

# The above sequence can also be piped:

Get-AzDnsRecordSet -Name "text" -RecordType TXT -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com" | Remove-AzDnsRecordConfig -Value "This is a TXT Record"  | Set-AzDnsRecordSet
```

This example removes a TXT record from an existing record set.
If this is the only record in the record set, the result is an empty record set.
To remove a record set entirely, see Remove-AzDnsRecordSet.

### Example 9: Remove a DS record from a record set
```powershell
$RecordSet = Get-AzDnsRecordSet -Name "www" -RecordType DS -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com"
Remove-AzDnsRecordConfig -KeyTag 12345 -Algorithm 3 -DigestType 1 -Digest "49FD46E6C4B45C55D4AC"
Set-AzDnsRecordSet -RecordSet $RecordSet

# The above sequence can also be piped:

Get-AzDnsRecordSet -Name "www" -RecordType DS -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com" | Remove-AzDnsRecordConfig -KeyTag 12345 -Algorithm 3 -DigestType 1 -Digest "49FD46E6C4B45C55D4AC"  | Set-AzDnsRecordSet
```

This example removes a DS record from an existing record set.
If this is the only record in the record set, the result is an empty record set.
To remove a record set entirely, see Remove-AzDnsRecordSet.

### Example 10: Remove a TLSA record from a record set
```powershell
$RecordSet = Get-AzDnsRecordSet -Name "_443._tcp.www" -RecordType TLSA -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com"
Remove-AzDnsRecordConfig -Usage 3 -Selector 1 -MatchingType 1 -CertificateAssociationData "49FD46E6C4B45C55D4AC"
Set-AzDnsRecordSet -RecordSet $RecordSet

# The above sequence can also be piped:

Get-AzDnsRecordSet -Name "_443._tcp.www" -RecordType TLSA -ResourceGroupName "MyResourceGroup" -ZoneName "myzone.com" | Remove-AzDnsRecordConfig -Usage 3 -Selector 1 -MatchingType 1 -CertificateAssociationData "49FD46E6C4B45C55D4AC"  | Set-AzDnsRecordSet
```

This example removes a TLSA record from an existing record set.
If this is the only record in the record set, the result is an empty record set.
To remove a record set entirely, see Remove-AzDnsRecordSet.

## PARAMETERS

### -Algorithm
The algorithm field of the DS record to remove.

```yaml
Type: System.Int32
Parameter Sets: DS
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CaaFlags
The flags for the CAA record to add. Must be a number between 0 and 255.

```yaml
Type: System.Byte
Parameter Sets: Caa
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CaaTag
The tag field of the CAA record to add.

```yaml
Type: System.String
Parameter Sets: Caa
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CaaValue
The value field for the CAA record to add.

```yaml
Type: System.String
Parameter Sets: Caa
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CertificateAssociationData
The certificate association data field of the TLSA record to remove.

```yaml
Type: System.String
Parameter Sets: TLSA
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Cname
Specifies the domain name for a canonical name (CNAME) record.

```yaml
Type: System.String
Parameter Sets: CNAME
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Digest
The digest field of the DS record to remove.

```yaml
Type: System.String
Parameter Sets: DS
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DigestType
The digest type field of the DS record to remove.

```yaml
Type: System.Int32
Parameter Sets: DS
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
Type: System.String
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
Type: System.String
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
Type: System.String
Parameter Sets: AAAA
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -KeyTag
The key tag field of the DS record to remove.

```yaml
Type: System.Int32
Parameter Sets: DS
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MatchingType
The matching type field of the TLSA record to remove.

```yaml
Type: System.Int32
Parameter Sets: TLSA
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Nsdname
Specifies the name server for a name server (NS) record.

```yaml
Type: System.String
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
Type: System.UInt16
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
Type: System.UInt16
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
Type: System.UInt16
Parameter Sets: SRV
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Ptrdname
Specifies the target domain name of a pointer (PTR) record.

```yaml
Type: System.String
Parameter Sets: PTR
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RecordSet
Specifies the **RecordSet** object that contains the record to remove.

```yaml
Type: Microsoft.Azure.Commands.Dns.DnsRecordSet
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Selector
The selector field of the TLSA record to remove.

```yaml
Type: System.Int32
Parameter Sets: TLSA
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
Type: System.String
Parameter Sets: SRV
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Usage
The usage field of the TLSA record to remove.

```yaml
Type: System.Int32
Parameter Sets: TLSA
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
Type: System.String
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
Type: System.UInt16
Parameter Sets: SRV
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Dns.DnsRecordSet

### System.String

### System.UInt16

### System.Byte

## OUTPUTS

### Microsoft.Azure.Commands.Dns.DnsRecordSet

## NOTES

## RELATED LINKS

[Add-AzDnsRecordConfig](./Add-AzDnsRecordConfig.md)

[Get-AzDnsRecordSet](./Get-AzDnsRecordSet.md)

[Set-AzDnsRecordSet](./Set-AzDnsRecordSet.md)
