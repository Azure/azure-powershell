### Example 1: List available reservation scope
```powershell
Get-AzReservationAvailableScope -ReservationId 2ef560a7-f469-4b62-87b7-5312d588ce2a  -ReservationOrderId 2b9b9372-24e1-4a07-a354-2078fe347cf9 -Scope "/subscriptions/3f0487ff-27ca-4b9c-2a23-000770724b1b"
```

```output
Scope                                               Valid
-----                                               -----
/subscriptions/3f0487fd-27ca-4f9c-8a23-000770724b1b True
```
List available reservation scope