---
external help file:
Module Name: Az.ReservationApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.reservationapi/update-azreservationapiquota
schema: 2.0.0
---

# Update-AzReservationApiQuota

## SYNOPSIS
Update the quota (service limits) of this resource to the requested value.\n\r  • To get the quota information for specific resource, send a GET request.\n\r  • To increase the quota, update the limit field from the GET response to a new value.\n\r  • To update the quota value, submit the JSON response to the quota request API to update the quota.\r\n  • To update the quota.
use the PATCH operation.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzReservationApiQuota -Location <String> -ProviderId <String> -ResourceName <String>
 [-SubscriptionId <String>] [-AnyProperty <IAny>] [-Limit <Int32>] [-NameValue <String>]
 [-ResourceType <ResourceType>] [-Unit <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzReservationApiQuota -InputObject <IReservationApiIdentity> [-AnyProperty <IAny>] [-Limit <Int32>]
 [-NameValue <String>] [-ResourceType <ResourceType>] [-Unit <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the quota (service limits) of this resource to the requested value.\n\r  • To get the quota information for specific resource, send a GET request.\n\r  • To increase the quota, update the limit field from the GET response to a new value.\n\r  • To update the quota value, submit the JSON response to the quota request API to update the quota.\r\n  • To update the quota.
use the PATCH operation.

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

### -AnyProperty
Additional properties for the specified resource provider.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.IAny
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.IReservationApiIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Limit
Quota properties.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Azure region.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NameValue
Resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderId
Azure resource provider ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The resource name for a resource provider, such as SKU name for Microsoft.Compute, Sku or TotalLowPriorityCores for Microsoft.MachineLearningServices

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
The name of the resource type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Support.ResourceType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Unit
The limit units, such as **count** and **bytes**.
Use the unit field provided in the response of the GET quota operation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.IReservationApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.Api20201025.ICurrentQuotaLimitBase

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IReservationApiIdentity>: Identity Parameter
  - `[Id <String>]`: Quota Request ID.
  - `[Id1 <String>]`: Resource identity path
  - `[Location <String>]`: Azure region.
  - `[ProviderId <String>]`: Azure resource provider ID.
  - `[ReservationId <String>]`: Id of the Reservation Item
  - `[ReservationOrderId <String>]`: Order Id of the reservation
  - `[ResourceName <String>]`: The resource name for a resource provider, such as SKU name for Microsoft.Compute, Sku or TotalLowPriorityCores for Microsoft.MachineLearningServices
  - `[SubscriptionId <String>]`: Id of the subscription

## RELATED LINKS

