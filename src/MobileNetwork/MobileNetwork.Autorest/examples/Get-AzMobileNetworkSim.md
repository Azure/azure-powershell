### Example 1: List information about the specified SIM by SimGroup.
```powershell
Get-AzMobileNetworkSim -GroupName azps-mn-simgroup -ResourceGroupName azps_test_group
```

```output
Name        ResourceGroupName ProvisioningState
----        ----------------- -----------------
azps-mn-sim azps_test_group   Succeeded
```

List information about the specified SIM by SimGroup.

### Example 2: Get information about the specified SIM by Name.
```powershell
Get-AzMobileNetworkSim -GroupName azps-mn-simgroup -ResourceGroupName azps_test_group -Name azps-mn-sim
```

```output
Name        ResourceGroupName ProvisioningState
----        ----------------- -----------------
azps-mn-sim azps_test_group   Succeeded
```

Get information about the specified SIM by Name.