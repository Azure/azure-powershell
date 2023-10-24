### Example 1: List environment types in a dev center
```powershell
Get-AzDevCenterAdminEnvironmentType -ResourceGroupName testRg -DevCenterName Contoso
```
This command lists the environment types in the dev center "Contoso" under the resource group "testRg".

### Example 2: Get a dev center environment type 
```powershell
 Get-AzDevCenterAdminEnvironmentType -ResourceGroupName testRg -DevCenterName Contoso -Name DevTest
 ```
This command gets the environment type named "DevTest" in the dev center "Contoso" under the resource group "testRg".

### Example 3: Get a dev center environment type using InputObject
```powershell
$envType = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "EnvironmentTypeName" = "DevTest"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminEnvironmentType -InputObject $envType
 ```
This command gets the environment type named "DevTest" in the dev center "Contoso" under the resource group "testRg".
