### Example 1: List actions on the environment by endpoint
```powershell
Get-AzDevCenterUserEnvironmentAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -EnvironmentName myEnvironment -ProjectName DevProject
```
This command lists the actions on the environment "myEnvironment".

### Example 2: List actions on the environment by dev center
```powershell
Get-AzDevCenterUserEnvironmentAction -DevCenter Contoso -EnvironmentName myEnvironment -ProjectName DevProject
```
This command lists the actions on the environment "myEnvironment".

### Example 3: Get an action on the environment by endpoint
```powershell
Get-AzDevCenterUserEnvironmentAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -EnvironmentName myEnvironment -ProjectName DevProject -ActionName "schedule-default"
```
This command gets the action "schedule-default" for the environment "myEnvironment". 

### Example 4: Get an action on the environment by dev center
```powershell
Get-AzDevCenterUserEnvironmentAction -DevCenter Contoso -EnvironmentName myEnvironment -ProjectName DevProject -ActionName "schedule-default"
```
This command gets the action "schedule-default" for the environment "myEnvironment". 

### Example 5: Get an action on the environment by endpoint and InputObject
```powershell
$environmentInput = @{"EnvironmentName" = "myEnvironment"; "UserId" = "me"; "ProjectName" = "DevProject"; "ActionName" = "schedule-default"}
Get-AzDevCenterUserEnvironmentAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $environmentInput
```
This command gets the action "schedule-default" for the environment "myEnvironment". 

### Example 6: Get an action on the environment by dev center and InputObject
```powershell
$environmentInput = @{"EnvironmentName" = "myEnvironment"; "UserId" = "me"; "ProjectName" = "DevProject"; "ActionName" = "schedule-default"}
Get-AzDevCenterUserEnvironmentAction -DevCenter Contoso -InputObject $environmentInput
```
This command gets the action "schedule-default" for the environment "myEnvironment". 
