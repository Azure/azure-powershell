### Example 1: Deletes an Appliance with the specified Resource Name, Resource Group, and Subscription Id.
```powershell
Remove-AzArcResourceBridge -Name azps-resource-bridge -ResourceGroupName azps_test_group
```

Deletes an Appliance with the specified Resource Name, Resource Group, and Subscription Id.

### Example 2: Deletes an Appliance with the specified Resource Name, Resource Group, and Subscription Id.
```powershell
Get-AzArcResourceBridge -Name azps-resource-bridge -ResourceGroupName azps_test_group | Remove-AzArcResourceBridge
```

Deletes an Appliance with the specified Resource Name, Resource Group, and Subscription Id.