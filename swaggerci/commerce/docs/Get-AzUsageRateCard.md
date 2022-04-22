---
external help file:
Module Name: Az.Usage
online version: https://docs.microsoft.com/en-us/powershell/module/az.usage/get-azusageratecard
schema: 2.0.0
---

# Get-AzUsageRateCard

## SYNOPSIS
Enables you to query for the resource/meter metadata and related prices used in a given subscription by Offer ID, Currency, Locale and Region.
The metadata associated with the billing meters, including but not limited to service names, types, resources, units of measure, and regions, is subject to change at any time and without notice.
If you intend to use this billing data in an automated fashion, please use the billing meter GUID to uniquely identify each billable item.
If the billing meter GUID is scheduled to change due to a new billing model, you will be notified in advance of the change.

## SYNTAX

### Get (Default)
```
Get-AzUsageRateCard -Filter <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzUsageRateCard -InputObject <IUsageIdentity> -Filter <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Enables you to query for the resource/meter metadata and related prices used in a given subscription by Offer ID, Currency, Locale and Region.
The metadata associated with the billing meters, including but not limited to service names, types, resources, units of measure, and regions, is subject to change at any time and without notice.
If you intend to use this billing data in an automated fashion, please use the billing meter GUID to uniquely identify each billable item.
If the billing meter GUID is scheduled to change due to a new billing model, you will be notified in advance of the change.

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

### -Filter
The filter to apply on the operation.
It ONLY supports the 'eq' and 'and' logical operators at this time.
All the 4 query parameters 'OfferDurableId', 'Currency', 'Locale', 'Region' are required to be a part of the $filter.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Usage.Models.IUsageIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
It uniquely identifies Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Usage.Models.IUsageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Usage.Models.Api20150601Preview.IResourceRateCardInfo

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IUsageIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[SubscriptionId <String>]`: It uniquely identifies Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

