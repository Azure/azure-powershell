### Example 1: Collect a diagnostics package for the specified packet core control plane.
```powershell
Trace-AzMobileNetworkCollectPacketCoreControlPlaneDiagnosticPackage -PacketCoreControlPlaneName azps-mn-pccp -ResourceGroupName azps_test_group -StorageAccountBlobUrl https://azpsstorage.blob.core.windows.net/testdiag/test
```

Collect a diagnostics package for the specified packet core control plane.
This action will upload the diagnostics to a storage account.