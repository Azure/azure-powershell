### Example 1: Merge two reservations into one single reservation
```powershell
$arr=@("72bc398d-b201-4a2e-a1fa-60fb48a85b23", "34f2474f-b4d7-41ec-a96d-d4bb7c2f85b6")
Merge-AzReservation -ReservationOrderId "79ebddac-4030-4296-ab93-1ad90f032058" -ReservationId $arr
```

```output
Location   ReservationOrderId/ReservationId                                            Sku           State     BenefitStartTime    ExpiryDate           LastUpdatedDateTime SkuDescription
--------   --------------------------------                                            ---           -----     ----------------    ----------           ------------------- --------------
westeurope 79ebddac-4030-4296-ab93-1ad90f032058/72bc398d-b201-4a2e-a1fa-60fb48a85b23/5 Standard_B1ls Cancelled 7/5/2022 1:24:21 AM 7/5/2025 12:00:00 AM 7/8/2022 1:09:29 AM Reserved VM Instan…
westeurope 79ebddac-4030-4296-ab93-1ad90f032058/34f2474f-b4d7-41ec-a96d-d4bb7c2f85b6/4 Standard_B1ls Cancelled 7/5/2022 1:24:21 AM 7/5/2025 12:00:00 AM 7/8/2022 1:09:29 AM Reserved VM Instan…
westeurope 79ebddac-4030-4296-ab93-1ad90f032058/5a91b7d0-9276-4bc9-adae-2a3f5c2ee076/2 Standard_B1ls Succeeded 7/5/2022 1:24:21 AM 7/5/2025 12:00:00 AM 7/8/2022 1:09:29 AM Reserved VM Instan…
```

Merge two reservations into one single reservation. The two reservations must have the same reservation order id. ReservationId can be either GUID form or fully qulified reservation id form "providers/Microsoft.Capacity/reservationOrders/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/reservations/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
