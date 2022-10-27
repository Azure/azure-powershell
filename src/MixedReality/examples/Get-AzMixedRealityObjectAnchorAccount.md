### Example 1: List Object Anchors Accounts by Subscription.
```powershell
Get-AzMixedRealityObjectAnchorAccount
```

```output
Location Name                          ResourceGroupName
-------- ----                          -----------------
eastus2  azpstestanchorsaccount-object azps_test_group
```

List Object Anchors Accounts by Subscription.

### Example 2: List Object Anchors Accounts by Resource Group.
```powershell
Get-AzMixedRealityObjectAnchorAccount -ResourceGroupName azps_test_group
```

```output
Location Name                          ResourceGroupName
-------- ----                          -----------------
eastus2  azpstestanchorsaccount-object azps_test_group
```

List Object Anchors Accounts by Resource Group.