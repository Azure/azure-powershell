<<<<<<< HEAD
### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

=======
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
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
