### Example 1: List information about the specified packet core data plane by PacketCoreControlPlaneName.
```powershell
Get-AzMobileNetworkPacketCoreDataPlane -PacketCoreControlPlaneName azps-mn-pccp -ResourceGroupName azps_test_group
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-pcdp azps_test_group   Succeeded
```

List information about the specified packet core data plane by PacketCoreControlPlaneName.

### Example 2: Get information about the specified packet core data plane by Name.
```powershell
Get-AzMobileNetworkPacketCoreDataPlane -PacketCoreControlPlaneName azps-mn-pccp -ResourceGroupName azps_test_group -Name azps-mn-pcdp
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-pcdp azps_test_group   Succeeded
```

Get information about the specified packet core data plane by Name.