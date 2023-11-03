### Example 1: Create a reservation order alias.
```powershell
New-AzBillingBenefitsReservationOrderAlias -Name "PSRITest1" -AppliedScopeType "Shared" -BillingPlan "P1M" -BillingScopeId "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47" -SkuName "Standard_B1ls" -Location "westus" -Quantity 1 -ReservedResourceType 'VirtualMachines' -Term "P1Y" -DisplayName "PSRITest1"
```

```output
Name      DisplayName SkuName       Location Term BillingPlan ReservedResourceType ReservationOrderId   ProvisioningState BillingScopeId                                      AppliedScopeType                 
----      ----------- -------       -------- ---- ----------- -------------------- ------------------   ----------------- --------------                                      --------
PSRITest1 PSRITest1   Standard_B1ls westus   P1Y  P1M         VirtualMachines      /providers/Micro...  Created           /subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47 Shared  
```

Create a reservation order alias.