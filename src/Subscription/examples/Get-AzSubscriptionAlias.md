### Example 1: List Alias Subscription.
```powershell
Get-AzSubscriptionAlias
```

```output
Name               DisplayName       SubscriptionId                       ProvisioningState
----               -----------       --------------                       -----------------
test-subscription  TEST_Subscription XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
test-subscription2 TEST_Subscription XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
```

List Alias Subscription.

### Example 2: Get Alias Subscription.
```powershell
Get-AzSubscriptionAlias -Name test-subscription
```

```output
Name              DisplayName       SubscriptionId                       ProvisioningState
----              -----------       --------------                       -----------------
test-subscription TEST_Subscription XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
```

Get Alias Subscription.