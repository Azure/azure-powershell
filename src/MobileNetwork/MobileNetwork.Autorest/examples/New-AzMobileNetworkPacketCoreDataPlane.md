### Example 1: Creates or updates a packet core data plane.
```powershell
New-AzMobileNetworkPacketCoreDataPlane -Name azps-mn-pcdp -PacketCoreControlPlaneName azps-mn-pccp -ResourceGroupName azps_test_group -Location eastus -UserPlaneAccessInterfaceIpv4Address 10.0.1.10 -UserPlaneAccessInterfaceIpv4Gateway 10.0.1.1 -UserPlaneAccessInterfaceIpv4Subnet 10.0.1.0/24 -UserPlaneAccessInterfaceName N3
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-pcdp azps_test_group   Succeeded
```

Creates or updates a packet core data plane.
Must be created in the same location as its parent packet core control plane.