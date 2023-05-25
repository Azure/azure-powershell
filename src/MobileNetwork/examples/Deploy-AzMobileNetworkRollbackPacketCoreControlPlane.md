### Example 1: Roll back the specified packet core control plane to the previous version, \"rollbackVersion\".
```powershell
Deploy-AzMobileNetworkRollbackPacketCoreControlPlane -PacketCoreControlPlaneName azps-mn-pccp -ResourceGroupName azps_test_group
```

Roll back the specified packet core control plane to the previous version, \"rollbackVersion\".
Multiple consecutive rollbacks are not possible.
This action may cause a service outage.