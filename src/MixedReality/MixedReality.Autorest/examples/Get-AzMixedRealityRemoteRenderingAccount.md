### Example 1: List Remote Rendering Account by Subscription.
```powershell
Get-AzMixedRealityRemoteRenderingAccount
```

```output
Location Name                     ResourceGroupName
-------- ----                     -----------------
eastus   azpstestrenderingaccount azps_test_group
```

List Remote Rendering Account by Subscription.

### Example 2: List Remote Rendering Account by Resource Group.
```powershell
Get-AzMixedRealityRemoteRenderingAccount -ResourceGroupName azps_test_group
```

```output
Location Name                     ResourceGroupName
-------- ----                     -----------------
eastus   azpstestrenderingaccount azps_test_group
```

List Remote Rendering Account by Resource Group.

### Example 3: Get a Remote Rendering Account.
```powershell
Get-AzMixedRealityRemoteRenderingAccount -ResourceGroupName azps_test_group -Name azpstestrenderingaccount
```

```output
Location Name                     ResourceGroupName
-------- ----                     -----------------
eastus   azpstestrenderingaccount azps_test_group
```

Get a Remote Rendering Account.