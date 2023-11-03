### Example 1: List Spatial Anchors Accounts by Subscription.
```powershell
Get-AzMixedRealitySpatialAnchorsAccount
```

```output
Location Name                   ResourceGroupName
-------- ----                   -----------------
eastus   azpstestanchorsaccount azps_test_group
```

List Spatial Anchors Accounts by Subscription.

### Example 2: List Spatial Anchors Accounts by Resource Group.
```powershell
Get-AzMixedRealitySpatialAnchorsAccount -ResourceGroupName azps_test_group
```

```output
Location Name                   ResourceGroupName
-------- ----                   -----------------
eastus   azpstestanchorsaccount azps_test_group
```

List Spatial Anchors Accounts by Resource Group.

### Example 3: Retrieve a Spatial Anchors Account.
```powershell
Get-AzMixedRealitySpatialAnchorsAccount -Name azpstestanchorsaccount -ResourceGroupName azps_test_group
```

```output
Location Name                   ResourceGroupName
-------- ----                   -----------------
eastus   azpstestanchorsaccount azps_test_group
```

Retrieve a Spatial Anchors Account.