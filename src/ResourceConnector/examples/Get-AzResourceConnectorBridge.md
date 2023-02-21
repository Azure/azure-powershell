### Example 1: List the details of Appliance with a specified subId.
```powershell
Get-AzResourceConnectorBridge
```

```output
Name                 Location ProvisioningState ResourceGroupName
----                 -------- ----------------- -----------------
azps-resource-bridge eastus   Succeeded         azps_test_group
```

List the details of Appliance with a specified subId.

### Example 2: List the details of Appliance with a specified resource group.
```powershell
Get-AzResourceConnectorBridge -ResourceGroupName azps_test_group
```

```output
Name                 Location ProvisioningState ResourceGroupName
----                 -------- ----------------- -----------------
azps-resource-bridge eastus   Succeeded         azps_test_group
```

List the details of Appliance with a specified resource group.

### Example 3: Get the details of an Appliance with a specified resource group and name.
```powershell
Get-AzResourceConnectorBridge -ResourceGroupName azps_test_group -Name azps-resource-bridge
```

```output
Name                 Location ProvisioningState ResourceGroupName
----                 -------- ----------------- -----------------
azps-resource-bridge eastus   Succeeded         azps_test_group
```

Get the details of an Appliance with a specified resource group and name.