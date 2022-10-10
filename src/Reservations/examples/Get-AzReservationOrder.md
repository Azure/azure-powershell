### Example 1: Get the list of reservation orders in the current tenant
```powershell
Get-AzReservationOrder
```

```output
ReservationOrderId                   DisplayName                                          Term State     Quantity Reservations
------------------                   -----------                                          ---- -----     -------- ------------
179de21b-90ec-4fe4-9423-f804b856dfee VM_RI_08-20-2021_15-47                               P3Y  Succeeded 1        {{…
0de8d259-d48v-4db2-8fd9-ae4dd2bd2227 VM_RI_04-19-2021_13-48                               P3Y  Cancelled 4        {{…
02ffwsb1-4369-4m8s-b118-12efbfddd3fc VM_RI_04-19-2021_12-48                               P3Y  Succeeded 1        {{…
06629f91-b216-4d6f-80cd-fa91c8ba61b8 VM_RI_04-19-2021_19-48                               P3Y  Succeeded 1        {{…
```

Get the list of reservation orders in the current tenant. Some data might be trucated due to the width of powershell view, appending this to the end of the command to show the truncated data: | ft -Wrap

### Example 2: Get the reservation order in the current tenant, given reservation order Id
```powershell
Get-AzReservationOrder -ReservationOrderId 179de21b-90ec-4fe4-9423-f804b856dfee
```

```output
ReservationOrderId                   DisplayName            Term State     Quantity Reservations
------------------                   -----------            ---- -----     -------- ------------
179ef21b-90ec-4fe4-9423-f794b856dfee VM_RI_08-20-2021_15-47 P3Y  Succeeded 1        {{…
```

Get the reservation order in the current tenant, given reservation order Id. Some data might be trucated due to the width of powershell view, appending this to the end of the command to show the truncated data: | ft -Wrap

