---
external help file:
Module Name: Az.Consumption
online version: https://learn.microsoft.com/powershell/module/az.consumption/get-azconsumptionreservationdetail
schema: 2.0.0
---

# Get-AzConsumptionReservationDetail

## SYNOPSIS
Lists the reservations details for provided date range.
Note: ARM has a payload size limit of 12MB, so currently callers get 400 when the response size exceeds the ARM limit.
If the data size is too large, customers may also get 504 as the API timed out preparing the data.
In such cases, API call should be made with smaller date ranges or a call to Generate Reservation Details Report API should be made as it is asynchronous and will not run into response size time outs.

## SYNTAX

### List (Default)
```
Get-AzConsumptionReservationDetail -ReservationOrderId <String> -Filter <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzConsumptionReservationDetail -ReservationId <String> -ReservationOrderId <String> -Filter <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the reservations details for provided date range.
Note: ARM has a payload size limit of 12MB, so currently callers get 400 when the response size exceeds the ARM limit.
If the data size is too large, customers may also get 504 as the API timed out preparing the data.
In such cases, API call should be made with smaller date ranges or a call to Generate Reservation Details Report API should be made as it is asynchronous and will not run into response size time outs.

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

### -Filter
Filter reservation details by date range.
The properties/UsageDate for start date and end date.
The filter supports 'le' and 'ge'

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

### -ReservationId
Id of the reservation

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservationOrderId
Order Id of the reservation

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.Api20230301.IReservationDetail

## NOTES

ALIASES

## RELATED LINKS

