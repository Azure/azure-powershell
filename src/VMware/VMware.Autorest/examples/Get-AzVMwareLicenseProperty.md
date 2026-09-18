### Example 1: Get a VMware license property
```powershell
Get-AzVMwareLicenseProperty -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Kind           Core EndDate                ProvisioningState BroadcomSiteId BroadcomContractNumber
----           ---- -------                ----------------- -------------- ----------------------
VmwareFirewall   16 12/31/2025 11:59:59 PM Succeeded         123456         123456

```

Gets the detailed properties of VMware licenses within the specified private cloud and resource group