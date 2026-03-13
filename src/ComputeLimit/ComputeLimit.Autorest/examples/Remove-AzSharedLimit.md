### Example 1: Remove a shared limit
```powershell
Remove-AzSharedLimit -Location "eastus" -Name "mySharedLimit"
```

Disables sharing of a compute limit by the host subscription with its guest subscriptions.

### Example 2: Remove a shared limit with confirmation bypass
```powershell
Remove-AzSharedLimit -Location "eastus" -Name "mySharedLimit" -PassThru -Confirm:$false
```

```output
True
```

Removes the shared limit and returns True when PassThru is specified.