### Example 1: List Object Anchors Accounts by Subscription.
```powershell
Get-AzMixedRealityObjectAnchorsAccount
```

```output
Location Name                          ResourceGroupName
-------- ----                          -----------------
eastus2  azpstestanchorsaccount-object azps_test_group
```

List Object Anchors Accounts by Subscription.

### Example 2: List Object Anchors Accounts by Resource Group.
```powershell
Get-AzMixedRealityObjectAnchorsAccount -ResourceGroupName azps_test_group
```

```output
Location Name                          ResourceGroupName
-------- ----                          -----------------
eastus2  azpstestanchorsaccount-object azps_test_group
```

List Object Anchors Accounts by Resource Group.

### Example 3: Retrieve an Object Anchors Account.
```powershell
Get-AzMixedRealityObjectAnchorsAccount -Name azpstestanchorsaccount-object -ResourceGroupName azps_test_group
```

```output
Location Name                          ResourceGroupName
-------- ----                          -----------------
eastus2  azpstestanchorsaccount-object azps_test_group
```

Retrieve an Object Anchors Account.