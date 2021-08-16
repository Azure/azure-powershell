### Example 1: Create an addon in a private cloud
```powershell
PS C:\> $data = New-AzVMwareAddonVrPropertiesObject -AddonType VR -VrsCount 2
PS C:\> New-AzVMwareAddon -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -Property $data

Name Type
---- ----
vr   Microsoft.AVS/privateClouds/addons
```

Create an addon in a private cloud