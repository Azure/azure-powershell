### Example 1: Get list of applicable ReservationOrder Ids.
```powershell
Get-AzReservationOrderId -SubscriptionId '10000000-aaaa-bbbb-cccc-100000000005'
```

```output
Id                         : /subscriptions/10000000-aaaa-bbbb-cccc-100000000005/providers/microsoft.capacity/AppliedReservations/default
Name                       : default
ReservationOrderIdNextLink : 
ReservationOrderIdValue    : {/providers/Microsoft.Capacity/reservationorders/7c6192be-7543-40c3-93e1-3d7f0b15203f, 
                             /providers/Microsoft.Capacity/reservationorders/aa6c95fe-f25b-4f2e-864f-3860ef5d5bd0, 
                             /providers/Microsoft.Capacity/reservationorders/d9e3935c-288e-4ef5-81a0-55201c1a6a67, 
                             /providers/Microsoft.Capacity/reservationorders/b60911ea-d990-4795-818a-b7396abdb13b…}
ResourceGroupName          : 
Type                       : Microsoft.Capacity/AppliedReservations
```

Get Ids of applicable ReservationOrders that can be applied to this subscription. 
