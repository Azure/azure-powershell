### Example 1: Update Reservation's properties
```powershell
Update-AzReservation -ReservationOrderId "fe784288-6510-4b2b-8a56-3d4e38295a18" -ReservationId "271d8e0b-da88-44d8-b276-2620b8f1c7d1" -Name "testName"
```

```output
Location   ReservationOrderId/ReservationId                                             Sku           State     BenefitStartTime     ExpiryDate            LastUpdatedDateTime  SkuDescription
--------   --------------------------------                                             ---           -----     ----------------     ----------            -------------------  --------------
westeurope fe784288-6510-4b2b-8a56-3d4e38295a18/271d8e0b-da88-44d8-b276-2620b8f1c7d1/16 Standard_B4ms Succeeded 6/14/2022 9:41:17 PM 6/14/2025 12:00:00 AM 7/7/2022 11:37:58 PM Reserved VM In…
```

Update Reservation's properties including name, renew, appliedScopeType, appliedScope
