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

Location      Name            Type
--------      ----            ----
australiaeast azps_test_cloud Microsoft.AVS/privateClouds
```

List private cloud under resource group

### Example 3: Get private cloud
```powershell
PS C:\> Get-AzVMwarePrivateCloud -ResourceGroupName azps_test_group -Name azps_test_cloud

Location      Name            Type
--------      ----            ----
australiaeast azps_test_cloud Microsoft.AVS/privateClouds
```

Get private cloud

### Example 4: Get private cloud
```powershell
PS C:\> Get-AzVMwarePrivateCloud -InputObject "/subscriptions/ba75e79b-dd95-4025-9dbf-3a7ae8dff2b5/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud"

Location      Name            Type
--------      ----            ----
australiaeast azps_test_cloud Microsoft.AVS/privateClouds
```

Get private cloud