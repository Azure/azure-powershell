---
external help file:
Module Name: Az.Dns
online version: https://docs.microsoft.com/en-us/powershell/module/az.dns/set-azdnsrecordset
schema: 2.0.0
---

# Set-AzDnsRecordSet

## SYNOPSIS
Creates or updates a record set within a DNS zone.

## SYNTAX

### Update (Default)
```
Set-AzDnsRecordSet -RecordType <RecordType> -RelativeRecordSetName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -ZoneName <String> [-IfMatch <String>] [-IfNoneMatch <String>]
 [-Parameter <IRecordSet>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzDnsRecordSet -RecordType <RecordType> -RelativeRecordSetName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -ZoneName <String> [-IfMatch <String>] [-IfNoneMatch <String>]
 [-ARecord <IARecord[]>] [-AaaaRecord <IAaaaRecord[]>] [-CaaRecord <ICaaRecord[]>]
 [-CnameRecordCname <String>] [-Etag <String>] [-Metadata <Hashtable>] [-MxRecord <IMxRecord[]>]
 [-NsRecord <INsRecord[]>] [-PtrRecord <IPtrRecord[]>] [-SoaRecordEmail <String>]
 [-SoaRecordExpireTime <Int64>] [-SoaRecordHost <String>] [-SoaRecordMinimumTtl <Int64>]
 [-SoaRecordRefreshTime <Int64>] [-SoaRecordRetryTime <Int64>] [-SoaRecordSerialNumber <Int64>]
 [-SrvRecord <ISrvRecord[]>] [-TargetResourceId <String>] [-TimeToLive <Int64>] [-TxtRecord <ITxtRecord[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a record set within a DNS zone.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AaaaRecord
The list of AAAA records in the record set.
To construct, see NOTES section for AAAARECORD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.IAaaaRecord[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ARecord
The list of A records in the record set.
To construct, see NOTES section for ARECORD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.IARecord[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CaaRecord
The list of CAA records in the record set.
To construct, see NOTES section for CAARECORD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.ICaaRecord[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CnameRecordCname
The canonical name for this CNAME record.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Etag
The etag of the record set.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IfMatch
The etag of the record set.
Omit this value to always overwrite the current record set.
Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IfNoneMatch
Set to '*' to allow a new record set to be created, but to prevent updating an existing record set.
Other values will be ignored.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Metadata
The metadata attached to the record set.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MxRecord
The list of MX records in the record set.
To construct, see NOTES section for MXRECORD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.IMxRecord[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NsRecord
The list of NS records in the record set.
To construct, see NOTES section for NSRECORD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.INsRecord[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Describes a DNS record set (a collection of DNS records with the same name and type).
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IRecordSet
Parameter Sets: Update
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PtrRecord
The list of PTR records in the record set.
To construct, see NOTES section for PTRRECORD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.IPtrRecord[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RecordType
The type of DNS record in this record set.
Record sets of type SOA can be updated but not created (they are created when the DNS zone is created).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Support.RecordType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RelativeRecordSetName
The name of the record set, relative to the name of the zone.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SoaRecordEmail
The email contact for this SOA record.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SoaRecordExpireTime
The expire time for this SOA record.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SoaRecordHost
The domain name of the authoritative name server for this SOA record.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SoaRecordMinimumTtl
The minimum value for this SOA record.
By convention this is used to determine the negative caching duration.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SoaRecordRefreshTime
The refresh value for this SOA record.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SoaRecordRetryTime
The retry time for this SOA record.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SoaRecordSerialNumber
The serial number for this SOA record.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SrvRecord
The list of SRV records in the record set.
To construct, see NOTES section for SRVRECORD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.ISrvRecord[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetResourceId
Resource Id.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TimeToLive
The TTL (time-to-live) of the records in the record set.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases: Ttl

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TxtRecord
The list of TXT records in the record set.
To construct, see NOTES section for TXTRECORD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.ITxtRecord[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ZoneName
The name of the DNS zone (without a terminating dot).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IRecordSet

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IRecordSet

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### AAAARECORD <IAaaaRecord[]>: The list of AAAA records in the record set.
  - `[Ipv6Address <String>]`: The IPv6 address of this AAAA record.

#### ARECORD <IARecord[]>: The list of A records in the record set.
  - `[Ipv4Address <String>]`: The IPv4 address of this A record.

#### CAARECORD <ICaaRecord[]>: The list of CAA records in the record set.
  - `[Flag <Int32?>]`: The flags for this CAA record as an integer between 0 and 255.
  - `[Tag <String>]`: The tag for this CAA record.
  - `[Value <String>]`: The value for this CAA record.

#### MXRECORD <IMxRecord[]>: The list of MX records in the record set.
  - `[Exchange <String>]`: The domain name of the mail host for this MX record.
  - `[Preference <Int32?>]`: The preference value for this MX record.

#### NSRECORD <INsRecord[]>: The list of NS records in the record set.
  - `[Nsdname <String>]`: The name server name for this NS record.

#### PARAMETER <IRecordSet>: Describes a DNS record set (a collection of DNS records with the same name and type).
  - `[ARecord <IARecord[]>]`: The list of A records in the record set.
    - `[Ipv4Address <String>]`: The IPv4 address of this A record.
  - `[AaaaRecord <IAaaaRecord[]>]`: The list of AAAA records in the record set.
    - `[Ipv6Address <String>]`: The IPv6 address of this AAAA record.
  - `[CaaRecord <ICaaRecord[]>]`: The list of CAA records in the record set.
    - `[Flag <Int32?>]`: The flags for this CAA record as an integer between 0 and 255.
    - `[Tag <String>]`: The tag for this CAA record.
    - `[Value <String>]`: The value for this CAA record.
  - `[CnameRecordCname <String>]`: The canonical name for this CNAME record.
  - `[Etag <String>]`: The etag of the record set.
  - `[Metadata <IRecordSetPropertiesMetadata>]`: The metadata attached to the record set.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[MxRecord <IMxRecord[]>]`: The list of MX records in the record set.
    - `[Exchange <String>]`: The domain name of the mail host for this MX record.
    - `[Preference <Int32?>]`: The preference value for this MX record.
  - `[NsRecord <INsRecord[]>]`: The list of NS records in the record set.
    - `[Nsdname <String>]`: The name server name for this NS record.
  - `[PtrRecord <IPtrRecord[]>]`: The list of PTR records in the record set.
    - `[Ptrdname <String>]`: The PTR target domain name for this PTR record.
  - `[SoaRecordEmail <String>]`: The email contact for this SOA record.
  - `[SoaRecordExpireTime <Int64?>]`: The expire time for this SOA record.
  - `[SoaRecordHost <String>]`: The domain name of the authoritative name server for this SOA record.
  - `[SoaRecordMinimumTtl <Int64?>]`: The minimum value for this SOA record. By convention this is used to determine the negative caching duration.
  - `[SoaRecordRefreshTime <Int64?>]`: The refresh value for this SOA record.
  - `[SoaRecordRetryTime <Int64?>]`: The retry time for this SOA record.
  - `[SoaRecordSerialNumber <Int64?>]`: The serial number for this SOA record.
  - `[SrvRecord <ISrvRecord[]>]`: The list of SRV records in the record set.
    - `[Port <Int32?>]`: The port value for this SRV record.
    - `[Priority <Int32?>]`: The priority value for this SRV record.
    - `[Target <String>]`: The target domain name for this SRV record.
    - `[Weight <Int32?>]`: The weight value for this SRV record.
  - `[TargetResourceId <String>]`: Resource Id.
  - `[Ttl <Int64?>]`: The TTL (time-to-live) of the records in the record set.
  - `[TxtRecord <ITxtRecord[]>]`: The list of TXT records in the record set.
    - `[Value <String[]>]`: The text value of this TXT record.

#### PTRRECORD <IPtrRecord[]>: The list of PTR records in the record set.
  - `[Ptrdname <String>]`: The PTR target domain name for this PTR record.

#### SRVRECORD <ISrvRecord[]>: The list of SRV records in the record set.
  - `[Port <Int32?>]`: The port value for this SRV record.
  - `[Priority <Int32?>]`: The priority value for this SRV record.
  - `[Target <String>]`: The target domain name for this SRV record.
  - `[Weight <Int32?>]`: The weight value for this SRV record.

#### TXTRECORD <ITxtRecord[]>: The list of TXT records in the record set.
  - `[Value <String[]>]`: The text value of this TXT record.

## RELATED LINKS

