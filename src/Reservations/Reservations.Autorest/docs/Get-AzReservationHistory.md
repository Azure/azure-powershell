---
external help file:
Module Name: Az.Reservations
online version: https://learn.microsoft.com/powershell/module/az.reservations/get-azreservationhistory
schema: 2.0.0
---

# Get-AzReservationHistory

## SYNOPSIS
List of all the revisions for the `Reservation`.

## SYNTAX

```
Get-AzReservationHistory -ReservationId <String> -ReservationOrderId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
List of all the revisions for the `Reservation`.

## EXAMPLES

### Example 1: Get the revision of a reservation
```powershell
Get-AzReservationHistory -ReservationId 2ef560a7-f469-4b62-87b7-5312d588ce2a -ReservationOrderId 2b9b9372-24e1-4a07-a354-2078fe347cf9
```

```output
Location ReservationOrderId/ReservationId                                            Sku           State             BenefitStartTime      ExpiryDate            LastUpdatedDateTime   SkuDescription
-------- --------------------------------                                            ---           -----             ----------------      ----------            -------------------   --------------
westus   2b9b9372-24e1-4a07-a354-2078fe347cf9/2ef560a7-f469-4b62-87b7-5312d588ce2a/9 Standard_B1ls Succeeded         6/24/2022 10:06:39 PM 6/24/2023 12:00:00 AM 6/24/2022 10:06:43 PM Reserved VM Instance, Standard_B1ls, US West,… 
westus   2b9b9372-24e1-4a07-a354-2078fe347cf9/2ef560a7-f469-4b62-87b7-5312d588ce2a/8 Standard_B1ls Succeeded         6/24/2022 10:06:39 PM 6/24/2023 12:00:00 AM 6/24/2022 10:06:43 PM Reserved VM Instance, Standard_B1ls, US West,… 
westus   2b9b9372-24e1-4a07-a354-2078fe347cf9/2ef560a7-f469-4b62-87b7-5312d588ce2a/7 Standard_B1ls ConfirmedBilling                                              6/24/2022 10:06:17 PM Reserved VM Instance, Standard_B1ls, US West,…
westus   2b9b9372-24e1-4a07-a354-2078fe347cf9/2ef560a7-f469-4b62-87b7-5312d588ce2a/6 Standard_B1ls PendingBilling                                                6/24/2022 10:04:04 PM Reserved VM Instance, Standard_B1ls, US West,… 
westus   2b9b9372-24e1-4a07-a354-2078fe347cf9/2ef560a7-f469-4b62-87b7-5312d588ce2a/5 Standard_B1ls ConfirmedCapacity                                             6/24/2022 10:03:44 PM Reserved VM Instance, Standard_B1ls, US West,… 
westus   2b9b9372-24e1-4a07-a354-2078fe347cf9/2ef560a7-f469-4b62-87b7-5312d588ce2a/4 Standard_B1ls PendingCapacity                                               6/24/2022 10:03:34 PM Reserved VM Instance, Standard_B1ls, US West,… 
westus   2b9b9372-24e1-4a07-a354-2078fe347cf9/2ef560a7-f469-4b62-87b7-5312d588ce2a/3 Standard_B1ls Creating                                                      6/24/2022 10:03:17 PM Reserved VM Instance, Standard_B1ls, US West,… 
westus   2b9b9372-24e1-4a07-a354-2078fe347cf9/2ef560a7-f469-4b62-87b7-5312d588ce2a/2 Standard_B1ls Creating                                                      6/24/2022 10:03:04 PM Reserved VM Instance, Standard_B1ls, US West,… 
westus   2b9b9372-24e1-4a07-a354-2078fe347cf9/2ef560a7-f469-4b62-87b7-5312d588ce2a/1 Standard_B1ls Creating                                                      6/24/2022 10:02:52 PM Reserved VM Instance, Standard_B1ls, US West,… 
```

Get the revision of a reservation.
Some data might be trucated due to the width of powershell view, appending this to the end of the command to show the truncated data: | ft -Wrap

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

### -ReservationId
Id of the reservation item

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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IReservationResponse

## NOTES

ALIASES

## RELATED LINKS

