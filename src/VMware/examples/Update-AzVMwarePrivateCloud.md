### Example 1: Update size of private cloud by name
```powershell
PS C:\> Update-AzVMwarePrivateCloud -Name azps_test_cloud -ResourceGroupName azps_test_group -ManagementClusterSize 4

Location      Name            Type
--------      ----            ----
australiaeast azps_test_cloud Microsoft.AVS/privateClouds
```

Update size of private cloud by name

### Example 2: Update size of private cloud by input object
```powershell
PS C:\> Get-AzVMwarePrivateCloud -ResourceGroupName azps_test_group -Name azps_test_cloud | Update-AzVMwarePrivateCloud -ManagementClusterSize 4

Location      Name            Type
--------      ----            ----
australiaeast azps_test_cloud Microsoft.AVS/privateClouds
```

Update size of private cloud by input object