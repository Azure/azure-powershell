### Example 1: List private cloud under subscription
```powershell
PS C:\> Get-AzVMwarePrivateCloud

Location      Name            Type
--------      ----            ----
australiaeast azps_test_cloud Microsoft.AVS/privateClouds
```

List private cloud under subscription

### Example 2: List private cloud under resource group
```powershell
PS C:\> Get-AzVMwarePrivateCloud -ResourceGroupName azps_test_group

Location      Name            Type                        ResourceGroupName
--------      ----            ----                        -----------------
australiaeast azps_test_cloud Microsoft.AVS/privateClouds azps_test_group
```

List private cloud under resource group

### Example 3: Get a private cloud by name
```powershell
PS C:\> Get-AzVMwarePrivateCloud -ResourceGroupName azps_test_group -Name azps_test_cloud

Location      Name            Type                        ResourceGroupName
--------      ----            ----                        -----------------
australiaeast azps_test_cloud Microsoft.AVS/privateClouds azps_test_group
```

Get a private cloud by name