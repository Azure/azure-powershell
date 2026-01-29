### Example 1: Create a VMware license
```powershell
New-AzVMwareLicense -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name           Kind           Type                                 ResourceGroupName ProvisioningState
----           ----           ----                                 ----------------- -----------------
VmwareFirewall VmwareFirewall Microsoft.AVS/privateClouds/licenses azps_test_group    Succeeded
```

Creates a new VMware license within the specified private cloud and resource group.