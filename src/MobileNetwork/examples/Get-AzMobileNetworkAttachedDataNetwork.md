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
### Example 1: List information about the specified attached data network by PacketCoreControlPlaneName and PacketCoreDataPlaneName.
```powershell
Get-AzMobileNetworkAttachedDataNetwork -PacketCoreControlPlaneName azps=mn-pccp -PacketCoreDataPlaneName azps-mn-pcdp -ResourceGroupName azps_test_group
```

```output
Location Name        ResourceGroupName ProvisioningState
-------- ----        ----------------- -----------------
eastus   azps-mn-adn azps_test_group   Succeeded
```

List information about the specified attached data network by PacketCoreControlPlaneName and PacketCoreDataPlaneName.

### Example 2: Get information about the specified attached data network by Name.
```powershell
Get-AzMobileNetworkAttachedDataNetwork -PacketCoreControlPlaneName azps=mn-pccp -PacketCoreDataPlaneName azps-mn-pcdp -ResourceGroupName azps_test_group -Name azps-mn-adn
```

```output
Location Name        ResourceGroupName ProvisioningState
-------- ----        ----------------- -----------------
eastus   azps-mn-adn azps_test_group   Succeeded
```

Get information about the specified attached data network by Name.
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
