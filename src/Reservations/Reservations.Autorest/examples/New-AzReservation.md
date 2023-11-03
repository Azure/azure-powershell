### Example 1: Create a new reservation
```powershell
New-AzReservation -AppliedScopeType 'Shared' -BillingPlan 'Upfront' -billingScopeId '/subscriptions/b0f278e1-1f18-4378-84d7-b44dfa708665' -DisplayName 'TestVm2222' -Location 'westus' -Quantity 1 -ReservedResourceType 'VirtualMachines' -Sku 'Standard_b1ls' -Term 'P1Y' -ReservationOrderId '846655fa-d9e7-4fb8-9512-3ab7367352f1'
```

```output
ReservationOrderId                   DisplayName Term State     Quantity
------------------                   ----------- ---- -----     --------
846655fa-d9e7-4fb8-9512-3ab7367352f1 TestVm2222  P1Y  Succeeded 1
```

Proceed reservations purchase with reservation order ID obtained from Get-AzReservationQuote. This is a long running POST operation which can take around 10ish mins.
