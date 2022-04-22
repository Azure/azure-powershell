---
external help file:
Module Name: Az.Consumption
online version: https://docs.microsoft.com/en-us/powershell/module/az.consumption/get-azconsumptionreservationsummary
schema: 2.0.0
---

# Get-AzConsumptionReservationSummary

## SYNOPSIS
Lists the reservations summaries for daily or monthly grain.

## SYNTAX

### List (Default)
```
Get-AzConsumptionReservationSummary -ReservationOrderId <String> -Grain <Datagrain> [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzConsumptionReservationSummary -ReservationId <String> -ReservationOrderId <String> -Grain <Datagrain>
 [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the reservations summaries for daily or monthly grain.

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
Required only for daily grain.
The properties/UsageDate for start date and end date.
The filter supports 'le' and 'ge'

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

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.Api20211001.IReservationSummary

## NOTES

ALIASES

## RELATED LINKS

