### Example 1: Creates or updates a SIM group.
```powershell
New-AzMobileNetworkSimGroup -Name azps-mn-simgroup -ResourceGroupName azps_test_group -Location eastus -MobileNetworkId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn"
```

```output
Location Name             ResourceGroupName ProvisioningState
-------- ----             ----------------- -----------------
eastus   azps-mn-simgroup azps_test_group   Succeeded
```

Creates or updates a SIM group.
You need to create Keyvault, managementiidentity, and give Keyvault some permissions on the ManagementIdentity