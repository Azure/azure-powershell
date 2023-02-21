### Example 1: Deletes an Appliance with the specified Resource Name, Resource Group, and Subscription Id.
```powershell
Remove-AzResourceConnectorBridge -Name azps-resource-bridge -ResourceGroupName azps_test_group
```

Deletes an Appliance with the specified Resource Name, Resource Group, and Subscription Id.

### Example 2: Deletes an Appliance with the specified Resource Name, Resource Group, and Subscription Id.
```powershell
Get-AzResourceConnectorBridge -Name azps-resource-bridge -ResourceGroupName azps_test_group | Remove-AzResourceConnectorBridge
```

Deletes an Appliance with the specified Resource Name, Resource Group, and Subscription Id.