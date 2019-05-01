---
external help file: Az.Dns-help.xml
Module Name: Az.Dns
online version: https://docs.microsoft.com/en-us/powershell/module/az.dns/update-azdnsrecordset
schema: 2.0.0
---

# Update-AzDnsRecordSet

## SYNOPSIS
Updates a record set within a DNS zone.

## SYNTAX

### UpdateSubscriptionIdViaHost (Default)
```
Update-AzDnsRecordSet -RecordType <RecordType> -RelativeRecordSetName <String> -ResourceGroupName <String>
 -ZoneName <String> [-Parameter <IRecordSet>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzDnsRecordSet -RecordType <RecordType> -RelativeRecordSetName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -ZoneName <String> [-ARecord <IARecord[]>] [-AaaaRecord <IAaaaRecord[]>]
 [-CaaRecord <ICaaRecord[]>] [-CnameRecordCname <String>] [-Etag <String>]
 [-Metadata <IRecordSetPropertiesMetadata>] [-MxRecord <IMxRecord[]>] [-NsRecord <INsRecord[]>]
 [-PtrRecord <IPtrRecord[]>] [-SoaRecordEmail <String>] [-SoaRecordExpireTime <Int64>]
 [-SoaRecordHost <String>] [-SoaRecordMinimumTtl <Int64>] [-SoaRecordRefreshTime <Int64>]
 [-SoaRecordRetryTime <Int64>] [-SoaRecordSerialNumber <Int64>] [-SrvRecord <ISrvRecord[]>]
 [-TargetResourceId <String>] [-Ttl <Int64>] [-TxtRecord <ITxtRecord[]>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Update
```
Update-AzDnsRecordSet -RecordType <RecordType> -RelativeRecordSetName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -ZoneName <String> [-Parameter <IRecordSet>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateSubscriptionIdViaHostExpanded
```
Update-AzDnsRecordSet -RecordType <RecordType> -RelativeRecordSetName <String> -ResourceGroupName <String>
 -ZoneName <String> [-ARecord <IARecord[]>] [-AaaaRecord <IAaaaRecord[]>] [-CaaRecord <ICaaRecord[]>]
 [-CnameRecordCname <String>] [-Etag <String>] [-Metadata <IRecordSetPropertiesMetadata>]
 [-MxRecord <IMxRecord[]>] [-NsRecord <INsRecord[]>] [-PtrRecord <IPtrRecord[]>] [-SoaRecordEmail <String>]
 [-SoaRecordExpireTime <Int64>] [-SoaRecordHost <String>] [-SoaRecordMinimumTtl <Int64>]
 [-SoaRecordRefreshTime <Int64>] [-SoaRecordRetryTime <Int64>] [-SoaRecordSerialNumber <Int64>]
 [-SrvRecord <ISrvRecord[]>] [-TargetResourceId <String>] [-Ttl <Int64>] [-TxtRecord <ITxtRecord[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates a record set within a DNS zone.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AaaaRecord
The list of AAAA records in the record set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.IAaaaRecord[]
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ARecord
The list of A records in the record set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.IARecord[]
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CaaRecord
The list of CAA records in the record set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.ICaaRecord[]
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CnameRecordCname
The canonical name for this CNAME record.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -Etag
The etag of the record set.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
The metadata attached to the record set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20160401.IRecordSetPropertiesMetadata
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MxRecord
The list of MX records in the record set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.IMxRecord[]
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NsRecord
The list of NS records in the record set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.INsRecord[]
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Describes a DNS record set (a collection of DNS records with the same name and type).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IRecordSet
Parameter Sets: UpdateSubscriptionIdViaHost, Update
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PtrRecord
The list of PTR records in the record set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.IPtrRecord[]
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecordType
The type of DNS record in this record set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Support.RecordType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -SoaRecordEmail
The email contact for this SOA record.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoaRecordExpireTime
The expire time for this SOA record.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoaRecordHost
The domain name of the authoritative name server for this SOA record.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoaRecordMinimumTtl
The minimum value for this SOA record.
By convention this is used to determine the negative caching duration.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoaRecordRefreshTime
The refresh value for this SOA record.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoaRecordRetryTime
The retry time for this SOA record.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoaRecordSerialNumber
The serial number for this SOA record.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SrvRecord
The list of SRV records in the record set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.ISrvRecord[]
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceId
Resource Id.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ttl
The TTL (time-to-live) of the records in the record set.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -TxtRecord
The list of TXT records in the record set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.ITxtRecord[]
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IRecordSet
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.dns/update-azdnsrecordset](https://docs.microsoft.com/en-us/powershell/module/az.dns/update-azdnsrecordset)

