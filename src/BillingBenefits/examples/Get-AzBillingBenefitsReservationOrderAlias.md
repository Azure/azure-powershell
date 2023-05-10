### Example 1: Get a reservation order alias.
```powershell
Get-AzBillingBenefitsReservationOrderAlias -Name "PSRITest2"
```

```output
Name      DisplayName SkuName       Location Term BillingPlan ReservedResourceType ReservationOrderId
----      ----------- -------       -------- ---- ----------- -------------------- ------------------
PSRITest2 PSRITest2   Standard_B1ls westus   P1Y  P1M         VirtualMachines      /providers/Microsoft.Capacity/reservationOrders/8d5aacd0-f098-4202-8d4d-1e7cb8a3ac…
```

Get a reservation order alias.

### Example 2: Get a reservation order alias via identity.
```powershell
$identity = @{
                        ReservationOrderAliasName = "PSRITest2"
}

$response = Get-AzBillingBenefitsReservationOrderAlias -InputObject $identity
```

```output
Name      DisplayName SkuName       Location Term BillingPlan ReservedResourceType ReservationOrderId
----      ----------- -------       -------- ---- ----------- -------------------- ------------------
PSRITest2 PSRITest2   Standard_B1ls westus   P1Y  P1M         VirtualMachines      /providers/Microsoft.Capacity/reservationOrders/8d5aacd0-f098-4202-8d4d-1e7cb8a3ac…
```

Get a reservation order alias via identity.
