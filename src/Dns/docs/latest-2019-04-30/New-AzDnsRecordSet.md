---
external help file:
Module Name: Az.Dns
online version: https://docs.microsoft.com/en-us/powershell/module/az.dns/new-azdnsrecordset
schema: 2.0.0
---

# New-AzDnsRecordSet

## SYNOPSIS
Creates or updates a record set within a DNS zone.

## SYNTAX

### CreateCname (Default)
```
New-AzDnsRecordSet -Name <String> -ResourceGroupName <String> -ZoneName <String> -CnameRecordName <String>
 [-SubscriptionId <String>] [-DoNotOverwrite] [-Etag <String>] [-Metadata <Hashtable>]
 [-TargetResourceId <String>] [-TimeToLive <Int64>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateA
```
New-AzDnsRecordSet -Name <String> -ResourceGroupName <String> -ZoneName <String> -ARecord <IARecord[]>
 [-SubscriptionId <String>] [-DoNotOverwrite] [-Etag <String>] [-Metadata <Hashtable>]
 [-TargetResourceId <String>] [-TimeToLive <Int64>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateAaaa
```
New-AzDnsRecordSet -Name <String> -ResourceGroupName <String> -ZoneName <String> -AaaaRecord <IAaaaRecord[]>
 [-SubscriptionId <String>] [-DoNotOverwrite] [-Etag <String>] [-Metadata <Hashtable>]
 [-TargetResourceId <String>] [-TimeToLive <Int64>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateCaa
```
New-AzDnsRecordSet -Name <String> -ResourceGroupName <String> -ZoneName <String> -CaaRecord <ICaaRecord[]>
 [-SubscriptionId <String>] [-DoNotOverwrite] [-Etag <String>] [-Metadata <Hashtable>]
 [-TargetResourceId <String>] [-TimeToLive <Int64>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateMX
```
New-AzDnsRecordSet -Name <String> -ResourceGroupName <String> -ZoneName <String> -MXRecord <IMxRecord[]>
 [-SubscriptionId <String>] [-DoNotOverwrite] [-Etag <String>] [-Metadata <Hashtable>]
 [-TargetResourceId <String>] [-TimeToLive <Int64>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateNS
```
New-AzDnsRecordSet -Name <String> -ResourceGroupName <String> -ZoneName <String> -NSRecord <INsRecord[]>
 [-SubscriptionId <String>] [-DoNotOverwrite] [-Etag <String>] [-Metadata <Hashtable>]
 [-TargetResourceId <String>] [-TimeToLive <Int64>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreatePtr
```
New-AzDnsRecordSet -Name <String> -ResourceGroupName <String> -ZoneName <String> -PtrRecord <IPtrRecord[]>
 [-SubscriptionId <String>] [-DoNotOverwrite] [-Etag <String>] [-Metadata <Hashtable>]
 [-TargetResourceId <String>] [-TimeToLive <Int64>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateSrv
```
New-AzDnsRecordSet -Name <String> -ResourceGroupName <String> -ZoneName <String> -SrvRecord <ISrvRecord[]>
 [-SubscriptionId <String>] [-DoNotOverwrite] [-Etag <String>] [-Metadata <Hashtable>]
 [-TargetResourceId <String>] [-TimeToLive <Int64>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateTxt
```
New-AzDnsRecordSet -Name <String> -ResourceGroupName <String> -ZoneName <String> -TxtRecord <ITxtRecord[]>
 [-SubscriptionId <String>] [-DoNotOverwrite] [-Etag <String>] [-Metadata <Hashtable>]
 [-TargetResourceId <String>] [-TimeToLive <Int64>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
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
Parameter Sets: CreateAaaa
Aliases:

Required: True
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
Parameter Sets: CreateA
Aliases:

Required: True
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
Parameter Sets: CreateCaa
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CnameRecordName
The canonical name for this CNAME record.

```yaml
Type: System.String
Parameter Sets: CreateCname
Aliases:

Required: True
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

### -DoNotOverwrite
Does not overwrite the record set if it already exists.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MXRecord
The list of MX records in the record set.
To construct, see NOTES section for MXRECORD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.IMxRecord[]
Parameter Sets: CreateMX
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the record set, relative to the name of the zone.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: RelativeRecordSetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NSRecord
The list of NS records in the record set.
To construct, see NOTES section for NSRECORD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.INsRecord[]
Parameter Sets: CreateNS
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PtrRecord
The list of PTR records in the record set.
To construct, see NOTES section for PTRRECORD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.IPtrRecord[]
Parameter Sets: CreatePtr
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

### -SrvRecord
The list of SRV records in the record set.
To construct, see NOTES section for SRVRECORD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.ISrvRecord[]
Parameter Sets: CreateSrv
Aliases:

Required: True
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
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetResourceId
Resource Id.

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

### -TimeToLive
The TTL (time-to-live) of the records in the record set.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases: Ttl

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TxtRecord
The list of TXT records in the record set.
To construct, see NOTES section for TXTRECORD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20150504Preview.ITxtRecord[]
Parameter Sets: CreateTxt
Aliases:

Required: True
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

