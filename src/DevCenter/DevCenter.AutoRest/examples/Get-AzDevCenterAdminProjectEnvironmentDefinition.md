### Example 1: List environment definitions in a project catalog
```powershell
Get-AzDevCenterAdminProjectEnvironmentDefinition -ProjectName DevProject -CatalogName CentralCatalog -ResourceGroupName testRg
```
This command lists the environment definitions in a project catalog. 

### Example 2: Get a project environment definition 
```powershell
Get-AzDevCenterAdminProjectEnvironmentDefinition -ProjectName DevProject -CatalogName CentralCatalog -ResourceGroupName testRg -EnvironmentDefinitionName envDefName
```
This command gets the project environment definition "envDefName". 

### Example 3: Get a project environment definition using InputObject
```powershell
$environmentDefinition = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"; "EnvironmentDefinitionName"="envDefName"}
$environmentDefinition = Get-AzDevCenterAdminProjectEnvironmentDefinition -InputObject $environmentDefinition
```
This command gets the project environment definition "envDefName" using InputObject. 
