### Example 1: Accept subscription ownership status.
```powershell
Get-AzSubscriptionAcceptOwnershipStatus -SubscriptionId XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
```

```output
AcceptOwnershipState BillingOwner      ProvisioningState SubscriptionId                       SubscriptionTenantId
-------------------- ------------      ----------------- --------------                       --------------------
Completed            xxxxxxxx@xxxx.com Pending           XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
```

Accept subscription ownership status.