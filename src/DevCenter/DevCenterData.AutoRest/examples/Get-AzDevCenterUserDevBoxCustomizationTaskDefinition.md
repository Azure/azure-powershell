### Example 1: List customization tasks by endpoint
```powershell
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject
```
This command lists customization tasks in the project "DevProject".

### Example 2: List customization tasks by dev center
```powershell
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -DevCenterName Contoso -ProjectName DevProject
```
This command lists customization tasks in the project "DevProject".

### Example 3: Get a customization task by endpoint
```powershell
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -TaskName choco -CatalogName MyCatalog
```
This command gets a customization task named "choco" for the catalog "MyCatalog" in the project "DevProject".

### Example 4: Get a customization task by dev center
```powershell
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -DevCenterName Contoso -ProjectName DevProject -TaskName choco -CatalogName MyCatalog
```
This command gets a customization task named "choco" for the catalog "MyCatalog" in the project "DevProject".

### Example 5: Get a customization task by endpoint and InputObject
```powershell
$customizationTaskInput = @{"TaskName" = "choco"; "ProjectName" ="DevProject"; "CatalogName" = "MyCatalog" }
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $customizationTaskInput
```
This command gets a customization task named "choco" for the catalog "MyCatalog" in the project "DevProject".

### Example 6: Get a customization task by dev center and InputObject
```powershell
$customizationTaskInput = @{"TaskName" = "choco"; "ProjectName" = "DevProject"; "CatalogName" = "MyCatalog" }
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -DevCenterName Contoso -InputObject $customizationTaskInput 
```
This command gets a customization task named "choco" for the catalog "MyCatalog" in the project "DevProject".
