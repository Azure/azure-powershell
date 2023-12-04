### Example 1: Create an environment by endpoint
```powershell
$functionAppParameters = @{"name" = "testfuncApp" }
$currentDate = Get-Date
$dateIn8Months = $currentDate.AddMonths(8)

New-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -Name "envtest" -ProjectName DevProject -CatalogName CentralCatalog -EnvironmentDefinitionName FunctionApp -EnvironmentType DevTest -Parameter $functionAppParameters -ExpirationDate $dateIn8Months
```
This command creates an environment named envtest" to the project "DevProject".

### Example 2: Create an environment by dev center
```powershell
$currentDate = Get-Date
$dateIn8Months = $currentDate.AddMonths(8)

New-AzDevCenterUserEnvironment -DevCenterName Contoso -Name "envtest" -ProjectName DevProject -CatalogName CentralCatalog -EnvironmentDefinitionName Sandbox -EnvironmentType DevTest -ExpirationDate $dateIn8Months
```
This command creates an environment named envtest" to the project "DevProject".

### Example 3: Create an environment by endpoint and InputObject
```powershell
$envInput = @{"UserId" = "me"; "ProjectName" = "DevProject"; "EnvironmentName" = "envtest" }
$currentDate = Get-Date
$dateIn8Months = $currentDate.AddMonths(8)

New-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $envInput -CatalogName CentralCatalog -EnvironmentDefinitionName Sandbox -EnvironmentType DevTest -ExpirationDate $dateIn8Months
```
This command creates an environment named envtest" to the project "DevProject".

### Example 4: Create an environment by dev center and InputObject
```powershell
$functionAppParameters = @{"name" = "testfuncApp" }
$envInput = @{"UserId" = "me"; "ProjectName" = "DevProject"; "EnvironmentName" = "envtest" }
$currentDate = Get-Date
$dateIn8Months = $currentDate.AddMonths(8)

New-AzDevCenterUserEnvironment -DevCenterName Contoso -InputObject $envInput -CatalogName CentralCatalog -EnvironmentDefinitionName FunctionApp -EnvironmentType DevTest -Parameter $functionAppParameters -ExpirationDate $dateIn8Months
```
This command creates an environment named envtest" to the project "DevProject".