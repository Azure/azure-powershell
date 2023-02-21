### Example 1: Gets the upgrade graph of an Appliance with a specified resource group and name and specific release train.
```powershell
Get-AzResourceConnectorBridgeUpgradeGraph -ResourceGroupName azps_test_group -Name azps-resource-bridge -UpgradeGraph Stable
```

```output
Name   ResourceGroupName
----   -----------------
stable azps_test_group
```

Gets the upgrade graph of an Appliance with a specified resource group and name and specific release train.