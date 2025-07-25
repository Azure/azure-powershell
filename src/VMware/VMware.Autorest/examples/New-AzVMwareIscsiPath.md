### Example 1: Create a IscsiPath
```powershell
New-AzVMwareIscsiPath -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/group1/providers/Microsoft.AVS/privateClouds/cloud1/iscsiPaths/default   
Name                         : default
NetworkBlock                 : 192.168.0.0/24
ProvisioningState            : Succeeded
ResourceGroupName            : group1
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AVS/privateClouds/iscsiPaths
```

Create a IscsiPath

