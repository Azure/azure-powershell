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

### Example 1: Accept subscription ownership status.
```powershell
$subIdArray = @("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX","YYYYYYYY-YYYY-YYYY-YYYY-YYYYYYYYYYYY")
Get-AzSubscriptionAcceptOwnershipStatus -SubscriptionId $subIdArray
```

```output
AcceptOwnershipState BillingOwner      ProvisioningState SubscriptionId                       SubscriptionTenantId
-------------------- ------------      ----------------- --------------                       --------------------
Completed            xxxxxxxx@xxxx.com Pending           XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
Completed            yyyyyyyy@yyyy.com Pending           YYYYYYYY-YYYY-YYYY-YYYY-YYYYYYYYYYYY YYYYYYYY-YYYY-YYYY-YYYY-YYYYYYYYYYYY
```

Accept subscription ownership status.