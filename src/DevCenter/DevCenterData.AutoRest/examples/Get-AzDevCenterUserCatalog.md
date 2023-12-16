### Example 1: List catalogs by endpoint
```powershell
Get-AzDevCenterUserCatalog -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject
```
This command lists catalogs in the project "DevProject".

### Example 2: List catalogs by dev center
```powershell
Get-AzDevCenterUserCatalog -DevCenterName Contoso -ProjectName DevProject
```
This command lists catalogs in the project "DevProject".

### Example 3: Get a catalog by endpoint
```powershell
Get-AzDevCenterUserCatalog -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -CatalogName CentralCatalog 
```
This command gets a catalog named "CentralCatalog" in the project "DevProject".

### Example 4: Get a catalog by dev center
```powershell
Get-AzDevCenterUserCatalog -DevCenterName Contoso -ProjectName DevProject -CatalogName CentralCatalog 
```
This command gets a catalog named "CentralCatalog" in the project "DevProject".

### Example 5: Get a catalog by endpoint and InputObject
```powershell
$catalogInput = @{"CatalogName" = "CentralCatalog"; "ProjectName" =" DevProject" }
Get-AzDevCenterUserCatalog -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $catalogInput
```
This command gets a catalog named "CentralCatalog" in the project "DevProject".

### Example 6: Get a catalog by dev center and InputObject
```powershell
$catalogInput = @{"CatalogName" = "CentralCatalog"; "ProjectName" = "DevProject" }
Get-AzDevCenterUserCatalog -DevCenterName Contoso -InputObject $catalogInput 
```
This command gets a catalog named "CentralCatalog" in the project "DevProject".
