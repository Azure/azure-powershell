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

Calculate reservations exchange. The SessionId in the response is a required input parameter for cmdlet Invoke-AzReservationExchange
