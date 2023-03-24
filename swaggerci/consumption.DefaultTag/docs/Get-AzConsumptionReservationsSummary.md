---
external help file:
Module Name: Az.Consumption
online version: https://learn.microsoft.com/powershell/module/az.consumption/get-azconsumptionreservationssummary
schema: 2.0.0
---

# Get-AzConsumptionReservationsSummary

## SYNOPSIS
Lists the reservations summaries for the defined scope daily or monthly grain.
Note: ARM has a payload size limit of 12MB, so currently callers get 400 when the response size exceeds the ARM limit.
In such cases, API call should be made with smaller date ranges.

## SYNTAX

```
Get-AzConsumptionReservationsSummary -ResourceScope <String> -Grain <Datagrain> [-EndDate <String>]
 [-Filter <String>] [-ReservationId <String>] [-ReservationOrderId <String>] [-StartDate <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the reservations summaries for the defined scope daily or monthly grain.
Note: ARM has a payload size limit of 12MB, so currently callers get 400 when the response size exceeds the ARM limit.
In such cases, API call should be made with smaller date ranges.

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
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -EndDate
End date.
Only applicable when querying with billing profile

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

### -Filter
Required only for daily grain.
The properties/UsageDate for start date and end date.
The filter supports 'le' and 'ge'.
Not applicable when querying with billing profile

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

### -Grain
Can be daily or monthly

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Consumption.Support.Datagrain
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservationId
Reservation Id GUID.
Only valid if reservationOrderId is also provided.
Filter to a specific reservation

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

### -ReservationOrderId
Reservation Order Id GUID.
Required if reservationId is provided.
Filter to a specific reservation order

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

### -ResourceScope
The scope associated with reservations summaries operations.
This includes '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for BillingAccount scope (legacy), and '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for BillingProfile scope (modern).

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

### -StartDate
Start date.
Only applicable when querying with billing profile

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.Api20230301.IReservationSummary

## NOTES

ALIASES

## RELATED LINKS

