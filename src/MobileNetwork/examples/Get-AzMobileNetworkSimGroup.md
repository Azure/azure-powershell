### Example 1: Get information about the specified SIM group by Sub.
```powershell
Get-AzMobileNetworkSimGroup
```

```output
<<<<<<< HEAD
Location Name             ResourceGroupName ProvisioningState IdentityType
-------- ----             ----------------- ----------------- ------------
eastus   azps-mn-simgroup azps_test_group   Succeeded         UserAssigned
=======
Location Name             ResourceGroupName ProvisioningState
-------- ----             ----------------- -----------------
eastus   azps-mn-simgroup azps_test_group   Succeeded
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Get information about the specified SIM group by Sub.

### Example 2: Get information about the specified SIM group by ResourceGroup.
```powershell
Get-AzMobileNetworkSimGroup -ResourceGroupName azps_test_group
```

```output
<<<<<<< HEAD
Location Name             ResourceGroupName ProvisioningState IdentityType
-------- ----             ----------------- ----------------- ------------
eastus   azps-mn-simgroup azps_test_group   Succeeded         UserAssigned
=======
Location Name             ResourceGroupName ProvisioningState
-------- ----             ----------------- -----------------
eastus   azps-mn-simgroup azps_test_group   Succeeded
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Get information about the specified SIM group by ResourceGroup.

### Example 3: Get information about the specified SIM group.
```powershell
Get-AzMobileNetworkSimGroup -ResourceGroupName azps_test_group -Name azps-mn-simgroup
```

```output
<<<<<<< HEAD
Location Name             ResourceGroupName ProvisioningState IdentityType
-------- ----             ----------------- ----------------- ------------
eastus   azps-mn-simgroup azps_test_group   Succeeded         UserAssigned
=======
Location Name             ResourceGroupName ProvisioningState
-------- ----             ----------------- -----------------
eastus   azps-mn-simgroup azps_test_group   Succeeded
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Get information about the specified SIM group.