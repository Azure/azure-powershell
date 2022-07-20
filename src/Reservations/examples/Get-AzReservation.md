### Example 1: Get the list of reservation orders in the current tenant
```powershell
Get-AzReservation
```

```output
Location   ReservationOrderId/ReservationId                                          Sku                           State     BenefitStartTime ExpiryDate            LastUpdatedDateTime SkuDescription
--------   --------------------------------                                          ---                           -----     ---------------- ----------            ------------------- --------------
centralus  a87c1742-0080-5b4d-b953-8531ad46fdc8/cad6fef7-ae86-4d47-91d0-67c897934bfe Standard_B1s                  Succeeded                  6/1/2024 12:00:00 AM
westeurope c5cf5c26-1920-4895-bf34-098ed1c69b92/6540137e-5a4f-4a14-bd17-3f2ea72b1ff4 premium_ssd_managed_disks_p30 Succeeded                  6/1/2022 12:00:00 AM
centralus  bd82bff8-4d29-9375-8194-ce0709fc1691/f2c3a058-b469-4529-88fa-1bae251c4a47 Standard_B1s                  Cancelled                  6/1/2024 12:00:00 AM
```

Get the list of reservation orders in the current tenant. By design, some propeties do not have data due to the api response(e.g. LastUpdatedDateTime and SkuDescription). In this case please get the single reservation with command in example 2 to get the missing data.

Some data might be trucated due to the width of powershell view, appending this to the end of the command to show the truncated data: | ft -Wrap

### Example 2: Get the reservation details given ReservationOrderId and ReservationId
```powershell
Get-AzReservation -ReservationOrderId a87c1742-0080-5b4d-b953-8531ad46fdc8 -ReservationId cad6fef7-ae86-4d47-91d0-67c897934bfe
```

```output
Location  ReservationOrderId/ReservationId                                          Sku          State     BenefitStartTime    ExpiryDate           LastUpdatedDateTime SkuDescription
--------  --------------------------------                                          ---          -----     ----------------    ----------           ------------------- --------------
centralus a87c1742-0080-5b4d-b953-8531ad46fdc8/cad6fef7-ae86-4d47-91d0-67c897934bfe Standard_B1s Succeeded 6/1/2021 5:01:58 PM 6/1/2024 12:00:00 AM 6/1/2021 5:02:09 PM Reserved VM Instance, Standard_B1s, US Central, 3 Years
```

Get the details of a single reservation. Some data might be trucated due to the width of powershell view, appending this to the end of the command to show the truncated data: | ft -Wrap

