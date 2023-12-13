### Example 1: Get the outputs on the environment by endpoint
```powershell
Get-AzDevCenterUserEnvironmentOutput -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -EnvironmentName myEnvironment -ProjectName DevProject
```
This command gets the outputs for the environment "myEnvironment". 

### Example 2: Get the outputs on the environment by dev center
```powershell
Get-AzDevCenterUserEnvironmentOutput -DevCenterName Contoso -EnvironmentName myEnvironment -ProjectName DevProject
```
This command gets the outputs for the environment "myEnvironment". 

### Example 3: Get the outputs on the environment by endpoint and InputObject
```powershell
$environmentInput = @{"EnvironmentName" = "myEnvironment"; "UserId" = "me"; "ProjectName" = "DevProject";}
Get-AzDevCenterUserEnvironmentOutput -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $environmentInput
```
This command gets the outputs for the environment "myEnvironment". 

### Example 4: Get the outputs on the environment by dev center and InputObject
```powershell
$environmentInput = @{"EnvironmentName" = "myEnvironment"; "UserId" = "me"; "ProjectName" = "DevProject";}
Get-AzDevCenterUserEnvironmentOutput -DevCenterName Contoso -InputObject $environmentInput
```
This command gets the outputs for the environment "myEnvironment". 
