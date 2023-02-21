### Example 1: Updates an Appliance with the specified Resource Name in the specified Resource Group and Subscription.
```powershell
Update-AzResourceConnectorBridge -Name azps-resource-bridge -ResourceGroupName azps_test_group -Tag @{"111"="222";"aaa"="bbb"}
```

```output
Name                 Location ProvisioningState ResourceGroupName
----                 -------- ----------------- -----------------
azps-resource-bridge eastus   Succeeded         azps_test_group
```

Updates an Appliance with the specified Resource Name in the specified Resource Group and Subscription.

### Example 2: Updates an Appliance with the specified Resource Name in the specified Resource Group and Subscription.
```powershell
Get-AzResourceConnectorBridge -ResourceGroupName azps_test_group -Name azps-resource-bridge | Update-AzResourceConnectorBridge -Tag @{"111"="222";"aaa"="bbb"}
```

```output
Name                 Location ProvisioningState ResourceGroupName
----                 -------- ----------------- -----------------
azps-resource-bridge eastus   Succeeded         azps_test_group
```

Updates an Appliance with the specified Resource Name in the specified Resource Group and Subscription.