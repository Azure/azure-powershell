### Example 1: Create Alias Subscription.
```powershell
New-AzSubscriptionAlias -AliasName test-subscription -SubscriptionId XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
```

```output
AliasName         SubscriptionId                       ProvisioningState
---------         --------------                       -----------------
test-subscription XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
```

Create Alias Subscription.

### Example 2: Create Alias Subscription.
```powershell
New-AzSubscriptionAlias -AliasName test-subscription -SubscriptionName "createSub" -BillingScope "/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoiceSections/{invoiceSectionName}" -Workload 'Production' 
```

```output
AliasName         SubscriptionId                       ProvisioningState
---------         --------------                       -----------------
test-subscription XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
```

Create Alias Subscription.