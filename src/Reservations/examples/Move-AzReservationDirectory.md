### Example 1: Move reservation order from one tenant to another
```powershell
Move-AzReservationDirectory -ReservationOrderId "7c31a9e8-8490-4002-88cd-3a16b71362a9" -DestinationTenantId "f65fbe9a-14b0-44c6-8c0d-2ef2c4543040"
```

```output
Reservation                 : {{
                                "id": "e2ce59da-9753-47f6-8576-2a2fab559409",
                                "name": "VM_RI_05-26-2022_16-53",
                                "isSucceeded": true
                              }, {
                                "id": "9a852181-9cec-43a4-852e-8cfd0bec11aa",
                                "name": "VM_RI_05-26-2022_16-53",
                                "isSucceeded": true
                              }, {
                                "id": "6dc205d9-8049-4179-9d60-29eb1d0082b3",
                                "name": "VM_RI_05-26-2022_16-53",
                                "isSucceeded": true
                              }}
ReservationOrderError       : 
ReservationOrderId          : 7c31a9e8-8490-4002-88cd-3a16b71362a9
ReservationOrderIsSucceeded : True
ReservationOrderName        : VM_RI_05-26-2022_16-53
```

Move reservation order from one tenant to another
