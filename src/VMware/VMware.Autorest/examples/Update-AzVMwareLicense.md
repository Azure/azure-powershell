### Example 1: Update VMware license for a private cloud
```powershell
Update-AzVMwareLicense -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name           Kind           Type                                 ResourceGroupName ProvisioningState
----           ----           ----                                 ----------------- -----------------
VmwareFirewall VmwareFirewall Microsoft.AVS/privateClouds/licenses azps_test_group   Succeeded
```

Updates the VMware license for the specified private cloud.
