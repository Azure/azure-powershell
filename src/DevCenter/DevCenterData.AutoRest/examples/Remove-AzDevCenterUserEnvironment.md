### Example 1: Delete an environment by endpoint
```powershell
Remove-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -UserId "me"  -Name myEnv
```
This command deletes the environment "myEnv" under the project "DevProject" assigned to the currently signed-in user.

### Example 2: Delete an environment by dev center
```powershell
Remove-AzDevCenterUserEnvironment -DevCenterName Contoso -ProjectName DevProject -UserId "786a823c-8037-48ab-89b8-8599901e67d0" -Name myEnv
```
This command deletes the environment "myEnv" under the project "DevProject" assigned to the user "786a823c-8037-48ab-89b8-8599901e67d0".

### Example 3: Delete an environment by endpoint and InputObject
```powershell
$envInput = @{"UserId" = "786a823c-8037-48ab-89b8-8599901e67d0"; "ProjectName" = "DevProject"; "EnvironmentName" = "myEnv" }
Remove-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $envInput
```
This command deletes the environment "myEnv" under the project "DevProject" assigned to the user "786a823c-8037-48ab-89b8-8599901e67d0".

### Example 4: Delete an environment by dev center and InputObject
```powershell
$envInput = @{"UserId" = "me"; "ProjectName" = "DevProject"; "EnvironmentName" = "myEnv" }
Remove-AzDevCenterUserEnvironment -DevCenterName Contoso -InputObject $envInput
```
This command deletes the environment "myEnv" under the project "DevProject" assigned to the currently signed-in user.

