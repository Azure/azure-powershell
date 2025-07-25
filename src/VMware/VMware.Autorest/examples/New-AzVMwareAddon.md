### Example 1: Create an addon in a private cloud
```powershell
$data = New-AzVMwareAddonVrPropertyObject -VrsCount 2
New-AzVMwareAddon -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -Property $data
```
```output
Name Type                               ResourceGroupName
---- ----                               -----------------
vr   Microsoft.AVS/privateClouds/addons azps_test_group
```

Create an addon in a private cloud