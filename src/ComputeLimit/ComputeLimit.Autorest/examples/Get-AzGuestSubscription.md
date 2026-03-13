### Example 1: List all guest subscriptions for a shared limit
```powershell
Get-AzGuestSubscription -Location "eastus"
```

```output
Name                                 Location ProvisioningState
----                                 -------- -----------------
00000000-0000-0000-0000-000000000001 eastus   Succeeded
```

Lists all guest subscriptions consuming shared compute limits in the specified location.

### Example 2: Get a specific guest subscription
```powershell
Get-AzGuestSubscription -Location "eastus" -Id "00000000-0000-0000-0000-000000000001"
```

```output
Name                                 Location ProvisioningState
----                                 -------- -----------------
00000000-0000-0000-0000-000000000001 eastus   Succeeded
```

Gets the properties of a specific guest subscription by ID.