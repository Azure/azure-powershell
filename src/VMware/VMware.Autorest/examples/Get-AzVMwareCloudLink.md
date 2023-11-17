### Example 1: List cloud link under resource group
```powershell
Get-AzVMwareCloudLink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```
```output
Name                Type                                   ResourceGroupName
----                ----                                   -----------------
azps_test_cloudlink Microsoft.AVS/privateClouds/cloudLinks azps_test_group
```

List cloud link under resource group

### Example 2: Get cloud link by name in a private cloud
```powershell
Get-AzVMwareCloudLink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -Name azps_test_cloudlink
```
```output
Name                Type                                   ResourceGroupName
----                ----                                   -----------------
azps_test_cloudlink Microsoft.AVS/privateClouds/cloudLinks azps_test_group
```

Get cloud link by name in a private cloud