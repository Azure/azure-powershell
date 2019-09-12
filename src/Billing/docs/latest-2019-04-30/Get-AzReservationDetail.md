---
external help file:
Module Name: Az.Billing
online version: https://docs.microsoft.com/en-us/powershell/module/az.billing/get-azreservationdetail
schema: 2.0.0
---

# Get-AzReservationDetail

## SYNOPSIS
Lists the reservations details for provided date range.

## SYNTAX

### ListExpandedFilter (Default)
```
Get-AzReservationDetail -ReservationOrderId <String> -EndDate <DateTime> -StartDate <DateTime>
 [-ReservationId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzReservationDetail -ReservationOrderId <String> -Filter <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzReservationDetail -ReservationId <String> -ReservationOrderId <String> -Filter <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the reservations details for provided date range.

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

### -EndDate
The end date (YYYY-MM-DD) in UTC of the reservation detail.

```yaml
Type: System.DateTime
Parameter Sets: ListExpandedFilter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Filter
Filter reservation details by date range.
The properties/UsageDate for start date and end date.
The filter supports 'le' and 'ge'

```yaml
Type: System.String
Parameter Sets: List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ReservationId
Id of the reservation

```yaml
Type: System.String
Parameter Sets: List1, ListExpandedFilter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -StartDate
The start date (YYYY-MM-DD) in UTC of the reservation detail.

```yaml
Type: System.DateTime
Parameter Sets: ListExpandedFilter
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181001.IReservationDetail

## ALIASES

### Get-AzConsumptionReservationDetail

## NOTES

## RELATED LINKS

