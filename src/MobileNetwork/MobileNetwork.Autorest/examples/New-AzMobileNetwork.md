### Example 1: Creates or updates a mobile network.
```powershell
New-AzMobileNetwork -Name azps-mn -ResourceGroupName azps_test_group -Location eastus -PublicLandMobileNetworkIdentifierMcc 001 -PublicLandMobileNetworkIdentifierMnc 01 -Tag @{"china"="move"}
```

```output
Location Name    ResourceGroupName PublicLandMobileNetworkIdentifierMcc PublicLandMobileNetworkIdentifierMnc
-------- ----    ----------------- ------------------------------------ ------------------------------------
eastus   azps-mn azps_test_group   001                                  01
```

Creates or updates a mobile network.