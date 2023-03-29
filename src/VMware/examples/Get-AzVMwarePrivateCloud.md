### Example 1: List private cloud under subscription
```powershell
Get-AzVMwarePrivateCloud
```
```output
Location      Name            Type
--------      ----            ----
australiaeast azps_test_cloud Microsoft.AVS/privateClouds
```

List private cloud under subscription

### Example 2: List private cloud under resource group
```powershell
Get-AzVMwarePrivateCloud -ResourceGroupName azps_test_group
```
```output
Location      Name            Type                        ResourceGroupName
--------      ----            ----                        -----------------
australiaeast azps_test_cloud Microsoft.AVS/privateClouds azps_test_group
```

List private cloud under resource group

### Example 3: Get a private cloud by name
```powershell
Get-AzVMwarePrivateCloud -ResourceGroupName azps_test_group -Name azps_test_cloud
```
```output
Location      Name            Type                        ResourceGroupName
--------      ----            ----                        -----------------
australiaeast azps_test_cloud Microsoft.AVS/privateClouds azps_test_group
```

Get a private cloud by name