### Example 1: Remove a guest subscription
```powershell
Remove-AzGuestSubscription -Location "eastus" -Id "00000000-0000-0000-0000-000000000001"
```

Removes a subscription as a guest to stop consuming the compute limits shared by the host subscription.

### Example 2: Remove a guest subscription with PassThru
```powershell
Remove-AzGuestSubscription -Location "eastus" -Id "00000000-0000-0000-0000-000000000001" -PassThru -Confirm:$false
```

```output
True
```

Removes the guest subscription and returns True when PassThru is specified.