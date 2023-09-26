### Example 1: {{ Add title here }}
```powershell
Get-AzSphereDeviceGroup -CatalogName NewCatalog -ProductName MyProd815 -ResourceGroupName ps1-test
```

```output
AllowCrashDumpsCollection    : Disabled
Description                  : test device group
HasDeployment                : False
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/ps1-test/providers/Microsoft.AzureSphere/catalogs/NewCatalog/products/MyProd815/deviceGroup 
                               s/Marketing
Name                         : Marketing
OSFeedType                   : Retail
ProvisioningState            : Succeeded
RegionalDataBoundary         : None
ResourceGroupName            : ps1-test
RetryAfter                   : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products/deviceGroups
UpdatePolicy                 : UpdateAll
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
Get-AzSphereDeviceGroup -CatalogName NewCatalog -Name Marketing -ProductName MyProd815 -ResourceGroupName ps1-test
```

```output
AllowCrashDumpsCollection    : Disabled
Description                  : test device group
HasDeployment                : 
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/ps1-test/providers/Microsoft.AzureSphere/catalogs/NewCatalog/products/MyProd815/deviceGroup 
                               s/Marketing
Name                         : Marketing
OSFeedType                   : Retail
ProvisioningState            : Succeeded
RegionalDataBoundary         : None
ResourceGroupName            : ps1-test
RetryAfter                   : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products/deviceGroups
UpdatePolicy                 : UpdateAll
```

{{ Add description here }}

