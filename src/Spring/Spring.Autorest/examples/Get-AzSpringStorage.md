### Example 1: Get the storage resource.
```powershell
Get-AzSpringStorage -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/storages/azps-storage
Name                         : azps-storage
Property                     : {
                                 "storageType": "StorageAccount",
                                 "accountName": "azpssa0523"
                               }
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/storages
```

Get the storage resource.