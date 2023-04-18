### Example 1: Updates packet core data planes.
```powershell
Update-AzMobileNetworkPacketCoreDataPlane -PacketCoreControlPlaneName azps-mn-pccp -PacketCoreDataPlaneName azps-mn-pcdp -ResourceGroupName azps_test_group -Tag @{"abc"="123"}
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-pcdp azps_test_group   Succeeded
```

Updates packet core data planes.