### Example 1: Updates packet core control planes.
```powershell
Update-AzMobileNetworkPacketCoreControlPlane -PacketCoreControlPlaneName azps-mn-pccp -ResourceGroupName azps_test_group -Tag @{"abc"="123"}
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-pccp azps_test_group   Succeeded
```

Updates packet core control planes.