### Example 1: List Alias Subscription.
```powershell
Get-AzSubscriptionAlias
```

```output
AliasName          SubscriptionId                       ProvisioningState
---------          --------------                       -----------------
test-subscription  XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
test-subscription2 XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
```

List Alias Subscription.

### Example 2: Get Alias Subscription.
```powershell
Get-AzSubscriptionAlias -AliasName test-subscription
```

```output
AliasName         SubscriptionId                       ProvisioningState
---------         --------------                       -----------------
test-subscription XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
```

Get Alias Subscription.