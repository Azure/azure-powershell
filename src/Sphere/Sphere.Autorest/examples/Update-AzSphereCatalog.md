### Example 1: Update tag
```powershell
Update-AzSphereCatalog -Name test2024 -ResourceGroupName group-test -Tag @{"123"="abc"}
```

```output
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/group-test/providers/Microsoft.AzureSphere/catalogs/test2024
Location                     : global
Name                         : test2024
ProvisioningState            : Succeeded
ResourceGroupName            : group-test
SystemDataCreatedAt          : 2/1/2024 1:51:44 AM
SystemDataCreatedBy          : example@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2/8/2024 1:54:33 AM
SystemDataLastModifiedBy     : example@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "123": "abc"
                               }
TenantId                     : 
Type                         : microsoft.azuresphere/catalogs
```

This command updates tag for specified catalog.

