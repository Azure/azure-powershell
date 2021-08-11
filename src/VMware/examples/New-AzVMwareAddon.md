### Example 1: Create a addon in a private cloud
```powershell
PS C:\> $data = New-AzVMwareAddonVrPropertiesObject -AddonType VR -VrsCount 2
PS C:\> New-AzVMwareAddon -Name vr -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -Property $data

Name Type
---- ----
vr   Microsoft.AVS/privateClouds/addons
```

Create a addon in a private cloud