### Example 1: ### Example 1: Create a catalog
```powershell
New-AzSphereCatalog -name test2024 -ResourceGroupName group-test -Location global
```

```output
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/group-test/providers/Microsoft.AzureSphere/catalogs/test2024
Location                     : global
Name                         : test2024
ProvisioningState            : Succeeded
ResourceGroupName            : group-test
RetryAfter                   : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {
                               }
TenantId                     : 11111111-2222-3333-4444-123456789123
Type                         : microsoft.azuresphere/catalogs
```

This command creates a catalog.

