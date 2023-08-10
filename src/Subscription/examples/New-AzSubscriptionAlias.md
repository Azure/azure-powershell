### Example 1: Create Alias Subscription.
```powershell
New-AzSubscriptionAlias -AliasName test-subscription -SubscriptionId XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
```

```output
AliasName         DisplayName SubscriptionId                       ProvisioningState
---------         ----------- --------------                       -----------------
test-subscription createSub   XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
```

Create Alias Subscription.

### Example 2: Create Alias Subscription.
```powershell
New-AzSubscriptionAlias -AliasName test-subscription -DisplayName "createSub" -BillingScope "providers/Microsoft.Billing/BillingAccounts/{BillingAccountName}/enrollmentAccounts/{BillingProfilesName}" -Workload 'Production' 
```

```output
AliasName         DisplayName SubscriptionId                       ProvisioningState
---------         ----------- --------------                       -----------------
test-subscription createSub   XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
```

Create Alias Subscription.