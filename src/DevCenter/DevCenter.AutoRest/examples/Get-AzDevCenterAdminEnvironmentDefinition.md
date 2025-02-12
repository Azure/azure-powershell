### Example 1: List environment definitions in a catalog
```powershell
Get-AzDevCenterAdminEnvironmentDefinition -DevCenterName Contoso -CatalogName CentralCatalog -ResourceGroupName testRg
```
This command lists the environment definitions in a catalog. 

### Example 2: Get an environment definition 
```powershell
Get-AzDevCenterAdminEnvironmentDefinition -DevCenterName Contoso -CatalogName CentralCatalog -ResourceGroupName testRg -Name envDefName
```
This command gets the environment definition "envDefName". 

### Example 3: Get an environment definition using InputObject
```powershell
$environmentDefinition = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"; "EnvironmentDefinitionName"="envDefName"}
$environmentDefinition = Get-AzDevCenterAdminEnvironmentDefinition -InputObject $environmentDefinition
```
This command gets the environment definition "envDefName" using InputObject. 
