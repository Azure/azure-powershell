### Example 1: Get environment definition error details
```powershell
Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail -DevCenterName Contoso -CatalogName CentralCatalog -ResourceGroupName testRg -EnvironmentDefinitionName envDefName
```
This command gets the environment definition "envDefName" error details

### Example 3: Get environment definition error details using InputObject
```powershell
$environmentDefinition = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"; "EnvironmentDefinitionName"="envDefName"}
$environmentDefinitionErrorDetail = Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail -InputObject $environmentDefinition
```
This command gets the environment definition "envDefName" error details using InputObject
