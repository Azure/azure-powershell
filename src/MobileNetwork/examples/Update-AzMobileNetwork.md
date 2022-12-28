### Example 1: Updates mobile network tags.
```powershell
Update-AzMobileNetwork -MobileNetworkName azps-mn -ResourceGroupName azps_test_group -Tag @{"123"="abc"}
```

```output
Location Name    ResourceGroupName PublicLandMobileNetworkIdentifierMcc PublicLandMobileNetworkIdentifierMnc
-------- ----    ----------------- ------------------------------------ ------------------------------------
eastus   azps-mn azps_test_group   001                                  01
```

Updates mobile network tags.