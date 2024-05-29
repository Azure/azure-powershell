### Example 1: Update storage resource.
```powershell
$storageObj = New-AzSpringStorageTypeObject -AccountKey "c/5h******+w==" -AccountName azpssa
Update-AzSpringStorage -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name azps-storage -Property $storageObj
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/storages/azps-storage
Name                         : azps-storage
Property                     : {
                                 "storageType": "StorageAccount",
                                 "accountName": "azpssa"
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

Update storage resource.