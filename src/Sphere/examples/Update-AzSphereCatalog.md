### Example 1: Update specific catalog with specified resource group
```powershell
Update-AzSphereCatalog -Name 'newCatalog' -ResourceGroupName 'ps1-test' -Tag @{"123"="abc"}
```

```output
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/ps1-test/providers/Microsoft.AzureSphere/catalogs/newCatalog  
Location                     : global
Name                         : newCatalog
ProvisioningState            : Succeeded
ResourceGroupName            : ps1-test
RetryAfter                   : 
SystemDataCreatedAt          : 8/15/2023 3:06:31 AM
SystemDataCreatedBy          : v-jiaji@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/15/2023 3:10:39 AM
SystemDataLastModifiedBy     : v-jiaji@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "123": "abc"
                               }
Type                         : microsoft.azuresphere/catalogs
```

This command updates specific catalog with specified resource group.
