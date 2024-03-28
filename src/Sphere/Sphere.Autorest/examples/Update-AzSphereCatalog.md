### Example 1: Update tag
```powershell
Update-AzSphereCatalog -Name test2024 -ResourceGroupName joyer-test -Tag @{"123"="abc"}
```

```output
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024
Location                     : global
Name                         : test2024
ProvisioningState            : Succeeded
ResourceGroupName            : joyer-test
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

