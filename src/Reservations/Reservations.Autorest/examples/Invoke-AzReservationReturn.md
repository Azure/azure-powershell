### Example 1: Return a reservation using the session ID obtained from calculateRefund command.
```powershell
$orderId = "50000000-aaaa-bbbb-cccc-100000000003"
$fullyQualifiedId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
$fullyQualifiedOrderId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003"

Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -ReservationToReturnQuantity 1 -ReservationToReturnReservationId $fullyQualifiedId  -Id $fullyQualifiedOrderId -Scope "Reservation"
```

```output
ReservationOrderId                   DisplayName            Term State     Quantity Reservations
------------------                   -----------            ---- -----     -------- ------------
179ef21b-90ec-4fe4-9423-f794b856dfee VM_RI_08-20-2021_15-47 P3Y  Succeeded 1        {{…
```
Proceed reservations return with session ID obtained from Invoke-AzReservationCalculateRefund.
