### Example 1: Proceed reservations exchange with session ID obtained from Invoke-AzReservationCalculateExchange
```powershell
Invoke-AzReservationExchange -SessionId 8982593c-679e-4d4e-b971-c48b6d824cba
```

```output
SessionId                            Status   
---------                            ------   
8982593c-679e-4d4e-b971-c48b6d824cba Succeeded
```

Proceed reservations exchange with session ID obtained from Invoke-AzReservationCalculateExchange. This is a long running POST operation which can take around 10ish mins.
