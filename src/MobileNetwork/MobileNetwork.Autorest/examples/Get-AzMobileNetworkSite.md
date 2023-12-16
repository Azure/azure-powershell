### Example 1: List information about the specified mobile network site by MobileNetwork Name.
```powershell
Get-AzMobileNetworkSite -ResourceGroupName azps_test_group -MobileNetworkName azps-mn
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-site azps_test_group   Succeeded
```

List information about the specified mobile network site by MobileNetwork Name.

### Example 2: Get information about the specified mobile network site.
```powershell
Get-AzMobileNetworkSite -ResourceGroupName azps_test_group -MobileNetworkName azps-mn -Name azps-mn-site
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-site azps_test_group   Succeeded
```

Get information about the specified mobile network site.