### Example 1: Deploy an environment by endpoint
```powershell
$functionAppParameters = @{"name" = "testfuncApp" }

Deploy-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -Name "envtest" -ProjectName DevProject -CatalogName CentralCatalog -EnvironmentDefinitionName FunctionApp -EnvironmentType DevTest -Parameter $functionAppParameters
```
This command deploys an environment named "envtest" to the project "DevProject".

### Example 2: Deploy an environment by dev center
```powershell
Deploy-AzDevCenterUserEnvironment -DevCenter Contoso -Name "envtest" -ProjectName DevProject -CatalogName CentralCatalog -EnvironmentDefinitionName Sandbox -EnvironmentType DevTest
```
This command deploys an environment named "envtest" to the project "DevProject".

### Example 3: Deploy an environment by endpoint and InputObject
```powershell
$envInput = @{"UserId" = "me"; "ProjectName" = "DevProject"; "EnvironmentName" = "envtest" }


Deploy-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $envInput -CatalogName CentralCatalog -EnvironmentDefinitionName Sandbox -EnvironmentType DevTest

```
This command deploys an environment named "envtest" to the project "DevProject".

### Example 4: Deploy an environment by dev center and InputObject
```powershell
$functionAppParameters = @{"name" = "testfuncApp" }
$envInput = @{"UserId" = "me"; "ProjectName" = "DevProject"; "EnvironmentName" = "envtest" }

Deploy-AzDevCenterUserEnvironment -DevCenter Contoso -InputObject $envInput -CatalogName CentralCatalog -EnvironmentDefinitionName FunctionApp -EnvironmentType DevTest -Parameter $functionAppParameters
```
This command deploys an environment named "envtest" to the project "DevProject".
