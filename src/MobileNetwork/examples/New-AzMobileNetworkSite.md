### Example 1: Creates or updates a mobile network site.
```powershell
New-AzMobileNetworkSite -MobileNetworkName azps-mn -Name azps-mn-site -ResourceGroupName azps_test_group -Location eastus -Tag @{"site"="123"}
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-site azps_test_group   Succeeded
```

Creates or updates a mobile network site.
Must be created in the same location as its parent mobile network.