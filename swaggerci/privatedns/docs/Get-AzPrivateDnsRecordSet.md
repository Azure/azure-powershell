---
external help file:
Module Name: Az.PrivateDns
online version: https://docs.microsoft.com/en-us/powershell/module/az.privatedns/get-azprivatednsrecordset
schema: 2.0.0
---

# Get-AzPrivateDnsRecordSet

## SYNOPSIS
Gets a record set.

## SYNTAX

### List1 (Default)
```
Get-AzPrivateDnsRecordSet -PrivateZoneName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Recordsetnamesuffix <String>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPrivateDnsRecordSet -PrivateZoneName <String> -RecordType <RecordType> -RelativeRecordSetName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPrivateDnsRecordSet -InputObject <IPrivateDnsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzPrivateDnsRecordSet -PrivateZoneName <String> -RecordType <RecordType> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Recordsetnamesuffix <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a record set.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PrivateDns.Models.IPrivateDnsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateZoneName
The name of the Private DNS zone (without a terminating dot).

```yaml
Type: System.String
Parameter Sets: Get, List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Recordsetnamesuffix
The suffix label of the record set name to be used to filter the record set enumeration.
If this parameter is specified, the returned enumeration will only contain records that end with ".\<recordsetnamesuffix\>".

```yaml
Type: System.String
Parameter Sets: List, List1
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
Type: Microsoft.Azure.PowerShell.Cmdlets.PrivateDns.Support.RecordType
Parameter Sets: Get, List
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
Parameter Sets: Get
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
Parameter Sets: Get, List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The maximum number of record sets to return.
If not specified, returns up to 100 record sets.

```yaml
Type: System.Int32
Parameter Sets: List, List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PrivateDns.Models.IPrivateDnsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PrivateDns.Models.Api20200601.IRecordSet

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IPrivateDnsIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[PrivateZoneName <String>]`: The name of the Private DNS zone (without a terminating dot).
  - `[RecordType <RecordType?>]`: The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the Private DNS zone is created).
  - `[RelativeRecordSetName <String>]`: The name of the record set, relative to the name of the zone.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[VirtualNetworkLinkName <String>]`: The name of the virtual network link.

## RELATED LINKS

