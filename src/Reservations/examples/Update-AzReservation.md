### Example 1: Update Reservation's properties
```powershell
Update-AzReservation -ReservationOrderId "30000000-aaaa-bbbb-cccc-200000000013" -ReservationId "10000000-aaaa-bbbb-cccc-200000000007" -Name "testName"
```

```output
Location   ReservationOrderId/ReservationId                                             Sku           State     BenefitStartTime     ExpiryDate            LastUpdatedDateTime  SkuDescription
--------   --------------------------------                                             ---           -----     ----------------     ----------            -------------------  --------------
westeurope 30000000-aaaa-bbbb-cccc-200000000013/10000000-aaaa-bbbb-cccc-200000000007/16 Standard_B4ms Succeeded 6/14/2022 9:41:17 PM 6/14/2025 12:00:00 AM 7/7/2022 11:37:58 PM Reserved VM In…
```

Update Reservation's properties including name, renew, appliedScopeType, appliedScope

### Example 2: Update Reservation's AppliedScopeType
```powershell
# Shared scope:
Update-AzReservation -ReservationOrderId "30000000-aaaa-bbbb-cccc-200000000013" -ReservationId "10000000-aaaa-bbbb-cccc-200000000007" -AppliedScopeType "Shared"

# Single scope:
Update-AzReservation -ReservationOrderId "30000000-aaaa-bbbb-cccc-200000000013" -ReservationId "10000000-aaaa-bbbb-cccc-200000000007" -AppliedScopeType "Single" -AppliedScope "/subscriptions/30000000-aaaa-bbbb-cccc-200000000018"

# Single scope with resource group:
Update-AzReservation -ReservationOrderId "30000000-aaaa-bbbb-cccc-200000000013" -ReservationId "10000000-aaaa-bbbb-cccc-200000000007" -AppliedScopeType "Single" -AppliedScope "/subscriptions/30000000-aaaa-bbbb-cccc-200000000018/resourcegroups/{your resource group name}"
```

```output
Similar to example 1
```

Update Reservation's applied scope type. For Shared scope, don't pass in any applied scope id. For Single scope, pass in applied scope id and for Single scope with resource group, also pass in resource group name in the applied scope id