### Example 1: Add a guest subscription to consume a shared limit
```powershell
Add-AzGuestSubscription -Location "eastus" -Id "00000000-0000-0000-0000-000000000001"
```

```output
Name                                 Location ProvisioningState
----                                 -------- -----------------
00000000-0000-0000-0000-000000000001 eastus   Succeeded
```

Adds a subscription as a guest to consume the compute limits shared by the host subscription.

### Example 2: Add a guest subscription in a different region with an explicit subscription
```powershell
Add-AzGuestSubscription -Location "westus2" -Id "00000000-0000-0000-0000-000000000002" -SubscriptionId "00000000-0000-0000-0000-000000000099"
```

```output
Name                                 Location ProvisioningState
----                                 -------- -----------------
00000000-0000-0000-0000-000000000002 westus2  Succeeded
```

Adds a guest subscription in the West US 2 region, explicitly specifying the host subscription ID.
