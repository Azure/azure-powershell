### Example 1: Get information about the specified SIM group by Sub.
```powershell
Get-AzMobileNetworkSimGroup
```

```output
Location Name             ResourceGroupName ProvisioningState
-------- ----             ----------------- -----------------
eastus   azps-mn-simgroup azps_test_group   Succeeded
```

Get information about the specified SIM group by Sub.

### Example 2: Get information about the specified SIM group by ResourceGroup.
```powershell
Get-AzMobileNetworkSimGroup -ResourceGroupName azps_test_group
```

```output
Location Name             ResourceGroupName ProvisioningState
-------- ----             ----------------- -----------------
eastus   azps-mn-simgroup azps_test_group   Succeeded
```

Get information about the specified SIM group by ResourceGroup.

### Example 3: Get information about the specified SIM group.
```powershell
Get-AzMobileNetworkSimGroup -ResourceGroupName azps_test_group -Name azps-mn-simgroup
```

```output
Location Name             ResourceGroupName ProvisioningState
-------- ----             ----------------- -----------------
eastus   azps-mn-simgroup azps_test_group   Succeeded
```

Get information about the specified SIM group.