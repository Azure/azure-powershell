### Example 1: {{ Add title here }}
```powershell
Get-AzSphereImage -CatalogName MyCatalog1 -ResourceGroupName ResourceGroup1
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDa 
                                                                                                                                                       taLastMo 
                                                                                                                                                       difiedBy 
                                                                                                                                                       Type     
----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ -------- 
fa0bdab1-42bc-4871-84d5-fa05c8c0c895
5f05300e-b0e0-47d5-8255-e4bddb2ddd81
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
Get-AzSphereImage -CatalogName MyCatalog1 -ResourceGroupName ResourceGroup1 -Name fa0bdab1-42bc-4871-84d5-fa05c8c0c895
```

```output
ComponentId                  : d851b4e3-ee3c-4268-8aa4-d72ae48311fa
Description                  : 
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/ResourceGroup1/providers/Microsoft.AzureSphere/catalogs/MyCat 
                               alog1/images/fa0bdab1-42bc-4871-84d5-fa05c8c0c895
ImageId                      : fa0bdab1-42bc-4871-84d5-fa05c8c0c895
ImageName                    : 
ImageType                    : Applications
Name                         : fa0bdab1-42bc-4871-84d5-fa05c8c0c895
PropertiesImage              : Random test Image ab3d
ProvisioningState            : Succeeded
RegionalDataBoundary         : None
ResourceGroupName            : ResourceGroup1
RetryAfter                   : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/images
Uri                          : https://as3imgptint003.blob.core.windows.net/9611b24a-5064-456b-adea-c6761b858fe3/imagesaks/fa0bdab1-42bc-4871-84d5-fa05c8c0c895 
                               ?skoid=8ae308e5-766c-490c-849e-3ea5928ddb9f&sktid=72f988bf-86f1-41af-91ab-2d7cd011db47&skt=2023-08-16T09%3A36%3A31Z&ske=2023-08- 
                               16T10%3A41%3A31Z&sks=b&skv=2021-12-02&sv=2021-12-02&spr=https,http&se=2023-08-16T17%3A41%3A31Z&sr=b&sp=r&sig=fTnp%2Foi5%2FlYj6w2 
                               9dVF%2FhDp4CYr1qgBrg5eMV5OSLMw%3D
```

{{ Add description here }}

