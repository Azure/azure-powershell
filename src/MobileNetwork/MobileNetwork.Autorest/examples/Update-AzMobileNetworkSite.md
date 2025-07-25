### Example 1: Updates site tags.
```powershell
Update-AzMobileNetworkSite -MobileNetworkName azps-mn -SiteName azps-mn-site -ResourceGroupName azps_test_group -Tag @{"site"="123"}
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-site azps_test_group   Succeeded
```

Updates site tags.