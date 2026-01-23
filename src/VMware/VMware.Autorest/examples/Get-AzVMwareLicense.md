### Example 1: Get a VMware License
```powershell
Get-AzVMwareLicense -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name           Type                                 ResourceGroupName Kind           ProvisioningState
----           ----                                 ----------------- ----           -----------------
VmwareFirewall Microsoft.AVS/privateClouds/licenses azps_test_group   VmwareFirewall Succeeded
```

Gets all VMware Licenses within the private cloud and resource group.