---
external help file:
Module Name: Az.Reservations
online version: https://learn.microsoft.com/powershell/module/az.reservations/invoke-azreservationcalculateexchange
schema: 2.0.0
---

# Invoke-AzReservationCalculateExchange

## SYNOPSIS
Calculates price for exchanging `Reservations` if there are no policy errors.\n

## SYNTAX

### PostExpanded (Default)
```
Invoke-AzReservationCalculateExchange [-ReservationsToExchange <IReservationToReturn[]>]
 [-ReservationsToPurchase <IPurchaseRequest[]>] [-SavingsPlansToPurchase <ISavingsPlanPurchaseRequest[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Post
```
Invoke-AzReservationCalculateExchange -Body <ICalculateExchangeRequest> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Calculates price for exchanging `Reservations` if there are no policy errors.\n

## EXAMPLES

### Example 1: Calculate reservations exchange
```powershell
$reservationToReturn1 = @{
    Quantity = 1
    ReservationId = "/providers/microsoft.capacity/reservationOrders/85a61229-7b4b-4565-8dee-632280b27370/reservations/4b0a0a3f-83db-429f-9ef3-015b6935f300"
}
$reservationToReturn2 = @{
    Quantity = 1
    ReservationId = "/providers/microsoft.capacity/reservationOrders/9f9d7d79-907e-4405-8764-d54a75f3d887/reservations/4c2008fe-b8cc-4291-b98a-d29792b73b9f"
}
$reservationsToReturn = @($reservationToReturn1, $reservationToReturn2)
$reservationToPurchase1Properties = @{
    AppliedScopeType = "Shared"
    BillingPlan = "Upfront"
    BillingScopeId = "/subscriptions/3f0487fd-27ca-4f9c-8a23-000770724b1b"
    DisplayName = "PSExchange"
    Term = "P3Y"
    Quantity = 1
    ReservedResourceType = "VirtualMachines"
}
$reservationToPurchase2Properties = @{
    AppliedScopeType = "Shared"
    BillingPlan = "Upfront"
    BillingScopeId = "/subscriptions/3f0487fd-27ca-4f9c-8a23-000770724b1b"
    DisplayName = "PSExchange2"
    Quantity = 2
    ReservedResourceType = "VirtualMachines"
    Term = "P3Y"
}
$reservationToPurchase1 = @{
    Location = "westeurope"
    Sku = "Standard_B20ms"
    Properties = $reservationToPurchase1Properties
}
$reservationToPurchase2 = @{
    Location = "westeurope"
    Sku = "Standard_B8ms"
    Properties = $reservationToPurchase2Properties
}
$reservationsToPurchase = @($reservationToPurchase1, $reservationToPurchase2)

Invoke-AzReservationCalculateExchange -ReservationsToExchange $reservationsToReturn -ReservationsToPurchase $reservationsToPurchase
```

```output
SessionId                            Status   
---------                            ------   
8982593c-679e-4d4e-b971-c48b6d824cba Succeeded
```

Calculate reservations exchange.
The SessionId in the response is a required input parameter for cmdlet Invoke-AzReservationExchange

## PARAMETERS

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

### -Body
Calculate exchange request
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.ICalculateExchangeRequest
Parameter Sets: Post
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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

### -ReservationsToExchange
List of reservations that are being returned in this exchange.
To construct, see NOTES section for RESERVATIONSTOEXCHANGE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IReservationToReturn[]
Parameter Sets: PostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservationsToPurchase
List of reservations that are being purchased in this exchange.
To construct, see NOTES section for RESERVATIONSTOPURCHASE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IPurchaseRequest[]
Parameter Sets: PostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SavingsPlansToPurchase
List of savings plans that are being purchased in this exchange.
To construct, see NOTES section for SAVINGSPLANSTOPURCHASE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.ISavingsPlanPurchaseRequest[]
Parameter Sets: PostExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.ICalculateExchangeRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.ICalculateExchangeOperationResultResponse

## NOTES

## RELATED LINKS

