### Example 1: Update size of private cloud by name
```powershell
Update-AzVMwarePrivateCloud -Name azps_test_cloud -ResourceGroupName azps_test_group
```
```output
Location      Name            Type                        ResourceGroupName
--------      ----            ----                        -----------------
australiaeast azps_test_cloud Microsoft.AVS/privateClouds azps_test_group
```

Update size of private cloud by name

### Example 2: Update size of private cloud
```powershell
Get-AzVMwarePrivateCloud -ResourceGroupName azps_test_group -Name azps_test_cloud | Update-AzVMwarePrivateCloud 
```
```output
Location      Name            Type                        ResourceGroupName
--------      ----            ----                        -----------------
australiaeast azps_test_cloud Microsoft.AVS/privateClouds azps_test_group
```

Update size of private cloud