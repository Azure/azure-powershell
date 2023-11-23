### Example 1: List information about the specified mobile network by Sub.
```powershell
Get-AzMobileNetwork
```

```output
Location Name     ResourceGroupName PublicLandMobileNetworkIdentifierMcc PublicLandMobileNetworkIdentifierMnc
-------- ----     ----------------- ------------------------------------ ------------------------------------
eastus   azps-mn  azps_test_group   001                                  01
eastus   azps-mn2 azps_test_group   001                                  01
```

List information about the specified mobile network by Sub.

### Example 2: List information about the specified mobile network by ResourceGroup.
```powershell
Get-AzMobileNetwork -ResourceGroupName azps_test_group
```

```output
Location Name     ResourceGroupName PublicLandMobileNetworkIdentifierMcc PublicLandMobileNetworkIdentifierMnc
-------- ----     ----------------- ------------------------------------ ------------------------------------
eastus   azps-mn  azps_test_group   001                                  01
eastus   azps-mn2 azps_test_group   001                                  01
```

List information about the specified mobile network by ResourceGroup.

### Example 3: Get information about the specified mobile network.
```powershell
Get-AzMobileNetwork -ResourceGroupName azps_test_group -Name azps-mn
```

```output
Location Name    ResourceGroupName PublicLandMobileNetworkIdentifierMcc PublicLandMobileNetworkIdentifierMnc
-------- ----    ----------------- ------------------------------------ ------------------------------------
eastus   azps-mn azps_test_group   001                                  01
```

Get information about the specified mobile network.