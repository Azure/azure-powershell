### Example 1: Reinstall the specified packet core control plane.
```powershell
Deploy-AzMobileNetworkReinstallPacketCoreControlPlane -PacketCoreControlPlaneName azps-mn-pccp -ResourceGroupName azps_test_group
```

Reinstall the specified packet core control plane.
This action will remove any transaction state from the packet core to return it to a known state.
This action will cause a service outage.