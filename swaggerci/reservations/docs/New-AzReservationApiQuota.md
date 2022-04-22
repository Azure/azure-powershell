---
external help file:
Module Name: Az.ReservationApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.reservationapi/new-azreservationapiquota
schema: 2.0.0
---

# New-AzReservationApiQuota

## SYNOPSIS
Create or update the quota (service limits) of a resource to the requested value.\n Steps:\n\r  1.
Make the Get request to get the quota information for specific resource.\n\r  2.
To increase the quota, update the limit field in the response from Get request to new value.\n\r  3.
Submit the JSON to the quota request API to update the quota.\r\n  The Create quota request may be constructed as follows.
The PUT operation can be used to update the quota.

## SYNTAX

```
New-AzReservationApiQuota -Location <String> -ProviderId <String> -ResourceName <String>
 [-SubscriptionId <String>] [-AnyProperty <IAny>] [-Limit <Int32>] [-NameValue <String>]
 [-ResourceType <ResourceType>] [-Unit <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update the quota (service limits) of a resource to the requested value.\n Steps:\n\r  1.
Make the Get request to get the quota information for specific resource.\n\r  2.
To increase the quota, update the limit field in the response from Get request to new value.\n\r  3.
Submit the JSON to the quota request API to update the quota.\r\n  The Create quota request may be constructed as follows.
The PUT operation can be used to update the quota.

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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.Api20201025.ICurrentQuotaLimitBase

## NOTES

ALIASES

## RELATED LINKS

