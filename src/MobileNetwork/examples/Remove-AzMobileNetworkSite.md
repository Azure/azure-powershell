### Example 1: Deletes the specified mobile network site.
```powershell
Remove-AzMobileNetworkSite -MobileNetworkName azps-mn -Name azps-mn-site -ResourceGroupName azps_test_group
```

Deletes the specified mobile network site.
This will also delete any network functions that are a part of this site.